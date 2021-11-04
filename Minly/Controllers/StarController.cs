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
    public class StarController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StarController> _logger;
        private readonly IMapper _mapper;

        public StarController(IUnitOfWork unitOfWork, ILogger<StarController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStars([FromQuery] RequestParams requestParams)
        {
            var Stars = await _unitOfWork.Stars.GetPagedList(requestParams, include: q => q.Include(x => x.Services).Include(y => y.Categories).Include(r => r.StarRates));
            var results = _mapper.Map<IList<StarDTO>>(Stars);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetStar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStar(int id)
        {
            var Star = await _unitOfWork.Stars.Get(q => q.Id == id, include: q => q.Include(x => x.Services).Include(y => y.Categories).Include(r => r.StarRates));
            var result = _mapper.Map<StarDTO>(Star);
            return Ok(result);
        }

        //[Authorize(Roles = "Administrator")]
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> CreateStar([FromBody] StarDTO StarDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogError($"Invalid POST attempt in {nameof(CreateStar)}");
        //        return BadRequest(ModelState);
        //    }

        //    var Star = _mapper.Map<Star>(StarDTO);
        //    await _unitOfWork.Stars.Insert(Star);
        //    await _unitOfWork.Save();

        //    return CreatedAtRoute("GetStar", new { id = Star.Id }, Star);
        //}

        //[Authorize]
        //[HttpPut("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> UpdateStar(int id, [FromBody] UpdateStarDTO StarDTO)
        //{
        //    if (!ModelState.IsValid || id < 1)
        //    {
        //        _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateStar)}");
        //        return BadRequest(ModelState);
        //    }


        //    var Star = await _unitOfWork.Stars.Get(q => q.Id == id);
        //    if (Star == null)
        //    {
        //        _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateStar)}");
        //        return BadRequest("Submitted data is invalid");
        //    }

        //    _mapper.Map(StarDTO, Star);
        //    _unitOfWork.Stars.Update(Star);
        //    await _unitOfWork.Save();

        //    return NoContent();

        //}

        //[Authorize]
        //[HttpDelete("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> DeleteStar(int id)
        //{
        //    if (id < 1)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteStar)}");
        //        return BadRequest();
        //    }

        //    var Star = await _unitOfWork.Stars.Get(q => q.Id == id);
        //    if (Star == null)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteStar)}");
        //        return BadRequest("Submitted data is invalid");
        //    }

        //    await _unitOfWork.Stars.Delete(id);
        //    await _unitOfWork.Save();

        //    return NoContent();

        //}
    }
}
