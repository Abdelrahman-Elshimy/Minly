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
    public class RequestStarController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RequestStarController> _logger;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public RequestStarController(IUnitOfWork unitOfWork, ILogger<RequestStarController> logger,
            IMapper mapper, DatabaseContext context)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("RequestsOfStar")]
        public async Task<IActionResult> RequestsOfStar(int id)
        {
            var RequestStars = await _unitOfWork.RequestStars.GetAll(q => q.StarId == id, include: q => q.Include(x => x.Star));
            var results = _mapper.Map<IList<RequestStarDTO>>(RequestStars);
            return Ok(results);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("RequestsOfStarStillNotDone")]
        public async Task<IActionResult> RequestsOfStarStillNotDone(int id)
        {
            var RequestStars = await _unitOfWork.RequestStars.GetAll(q => q.StarId == id && q.Status == false, include: q => q.Include(x => x.Star));
            var results = _mapper.Map<IList<RequestStarDTO>>(RequestStars);
            return Ok(results);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("RequestsOfStarDone")]
        public async Task<IActionResult> RequestsOfStarDone(int id)
        {
            var RequestStars = await _unitOfWork.RequestStars.GetAll(q => q.StarId == id && q.Status == true, include: q => q.Include(x => x.Star));
            var results = _mapper.Map<IList<RequestStarDTO>>(RequestStars);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetRequestStar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRequestStar(int id)
        {
            var RequestStar = await _unitOfWork.RequestStars.Get(q => q.Id == id, include: q => q.Include(x => x.ApiUser).Include(y => y.Star));
            var result = _mapper.Map<RequestStarDTO>(RequestStar);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles = "User")]
        [Authorize]
        public async Task<IActionResult> CreateRequestStar([FromBody] CreateRequestStarDTO createRequestStar)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateRequestStar)}");
                return BadRequest(ModelState);
            }

            var checkStar = await _unitOfWork.RequestStars.Get(q => q.StarId == createRequestStar.StarId && q.ApiUserId == createRequestStar.ApiUserId);
            var RequestStar = _mapper.Map<RequestStar>(createRequestStar);
            if (checkStar != null)
            {
                return BadRequest(new { Message = "Requested", StatusCode = 400 });
            }
            else
            {
                RequestStar.Payed = false;
                await _unitOfWork.RequestStars.Insert(RequestStar);
                await _unitOfWork.Save();

            }
            return CreatedAtRoute("GetRequestStar", new { id = RequestStar.Id }, RequestStar);
        }

        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("AcceptRequestStar")]
        public async Task<IActionResult> AcceptRequestStar(int id)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(AcceptRequestStar)}");
                return BadRequest(ModelState);
            }


            var RequestStar = await _unitOfWork.RequestStars.Get(q => q.Id == id);
            if (RequestStar == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(AcceptRequestStar)}");
                return BadRequest("Submitted data is invalid");
            }

            RequestStar.Status = true;

            _unitOfWork.RequestStars.Update(RequestStar);
            await _unitOfWork.Save();

            return Accepted(new { Message = "Accepted Successfully", StatusCode = 202 });

        }

        //[Authorize]
        //[HttpDelete("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> DeleteRequestStar(int id)
        //{
        //    if (id < 1)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteRequestStar)}");
        //        return BadRequest();
        //    }

        //    var RequestStar = await _unitOfWork.RequestStars.Get(q => q.Id == id);
        //    if (RequestStar == null)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteRequestStar)}");
        //        return BadRequest("Submitted data is invalid");
        //    }

        //    await _unitOfWork.RequestStars.Delete(id);
        //    await _unitOfWork.Save();

        //    return NoContent();

        //}
    }
}
