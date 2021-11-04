using AutoMapper;
using Minly.Core.DTOs;
using Minly.Core.IRepository;
using Minly.Core.Models;
using Minly.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Minly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarRateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StarRateController> _logger;
        private readonly IMapper _mapper;

        public StarRateController(IUnitOfWork unitOfWork, ILogger<StarRateController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStarRates([FromQuery] RequestParams requestParams)
        {
            var StarRates = await _unitOfWork.StarRates.GetPagedList(requestParams, include: q => q.Include(x => x.ApiUser).Include(y => y.Star));
            var results = _mapper.Map<IList<StarRateDTO>>(StarRates);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetStarRate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStarRate(int id)
        {
            var StarRate = await _unitOfWork.StarRates.Get(q => q.Id == id, include: q => q.Include(x => x.ApiUser).Include(y => y.Star));
            var result = _mapper.Map<StarRateDTO>(StarRate);
            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles = "User")]
        [Authorize]
        public async Task<IActionResult> CreateStarRate([FromBody] CreateStarRate createStarRate)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateStarRate)}");
                return BadRequest(ModelState);
            }

            var checkStar = await _unitOfWork.StarRates.Get(q => q.StarId == createStarRate.StarId && q.ApiUserId == createStarRate.ApiUserId);
            var StarRate = _mapper.Map<StarRate>(createStarRate);
            if (checkStar != null)
            {
                checkStar.Rate = createStarRate.Rate;
                _unitOfWork.StarRates.Update(checkStar);
                await _unitOfWork.Save();
            }

            else
            {
                await _unitOfWork.StarRates.Insert(StarRate);
                await _unitOfWork.Save();

            }
            var myStarRates = await _unitOfWork.StarRates.GetAll(q => q.StarId == createStarRate.StarId);
            double sum = _unitOfWork.GetRatesOfStars();
            var count = myStarRates.Count;
            var newRate = sum / count;
            var myStar = await _unitOfWork.Stars.Get(q => q.Id == createStarRate.StarId);
            myStar.Rate = newRate;
            _unitOfWork.Stars.Update(myStar);
            await _unitOfWork.Save();
            return CreatedAtRoute("GetStarRate", new { id = StarRate.Id }, StarRate);


        }

        //[Authorize]
        //[HttpPut("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> UpdateStarRate(int id, [FromBody] UpdateStarRateDTO StarRateDTO)
        //{
        //    if (!ModelState.IsValid || id < 1)
        //    {
        //        _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateStarRate)}");
        //        return BadRequest(ModelState);
        //    }


        //    var StarRate = await _unitOfWork.StarRates.Get(q => q.Id == id);
        //    if (StarRate == null)
        //    {
        //        _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateStarRate)}");
        //        return BadRequest("Submitted data is invalid");
        //    }

        //    _mapper.Map(StarRateDTO, StarRate);
        //    _unitOfWork.StarRates.Update(StarRate);
        //    await _unitOfWork.Save();

        //    return NoContent();

        //}

        //[Authorize]
        //[HttpDelete("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> DeleteStarRate(int id)
        //{
        //    if (id < 1)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteStarRate)}");
        //        return BadRequest();
        //    }

        //    var StarRate = await _unitOfWork.StarRates.Get(q => q.Id == id);
        //    if (StarRate == null)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteStarRate)}");
        //        return BadRequest("Submitted data is invalid");
        //    }

        //    await _unitOfWork.StarRates.Delete(id);
        //    await _unitOfWork.Save();

        //    return NoContent();

        //}
    }
}
