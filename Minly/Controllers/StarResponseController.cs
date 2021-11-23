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
    public class StarResponseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StarResponseController> _logger;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public StarResponseController(IUnitOfWork unitOfWork, ILogger<StarResponseController> logger,
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
        [Route("ResponsesofRequestStar")]
        public async Task<IActionResult> ResponsesofRequestStar(int id)
        {
            var StarResponses = await _unitOfWork.StarResponses.GetAll(q => q.RequestStarId == id, include: q => q.Include(x => x.RequestStar));
            var results = _mapper.Map<IList<StarResponseDTO>>(StarResponses);
            return Ok(results);
        }



        [HttpGet("{id:int}", Name = "GetStarResponse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStarResponse(int id)
        {
            var StarResponse = await _unitOfWork.StarResponses.Get(q => q.Id == id, include: q => q.Include(x => x.RequestStar));
            var result = _mapper.Map<StarResponseDTO>(StarResponse);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles = "User")]
        [Authorize]
        public async Task<IActionResult> CreateStarResponse([FromBody] CreateStarResponseDTO createStarResponse)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateStarResponse)}");
                return BadRequest(ModelState);
            }

            var checkEvent = await _unitOfWork.StarResponses.Get(q => q.RequestStarId == createStarResponse.RequestStarId);
            var StarResponse = _mapper.Map<StarResponse>(createStarResponse);
            if (checkEvent != null)
            {
                return BadRequest(new { Message = "Responsed", StatusCode = 400 });
            }
            else
            {
                var checkRequestStar = await _unitOfWork.RequestStars.Get(q => q.Id == createStarResponse.RequestStarId);
                if(checkRequestStar != null)
                {
                    checkRequestStar.Payed = true;
                    checkRequestStar.Status = true;
                    _unitOfWork.RequestStars.Update(checkRequestStar);
                    await _unitOfWork.Save();
                }
                await _unitOfWork.StarResponses.Insert(StarResponse);
                await _unitOfWork.Save();

            }
            return CreatedAtRoute("GetStarResponse", new { id = StarResponse.Id }, StarResponse);
        }

        //[Authorize]
        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Route("AcceptStarResponse")]
        //public async Task<IActionResult> AcceptStarResponse(int id)
        //{
        //    if (!ModelState.IsValid || id < 1)
        //    {
        //        _logger.LogError($"Invalid UPDATE attempt in {nameof(AcceptStarResponse)}");
        //        return BadRequest(ModelState);
        //    }


        //    var StarResponse = await _unitOfWork.StarResponses.Get(q => q.Id == id);
        //    if (StarResponse == null)
        //    {
        //        _logger.LogError($"Invalid UPDATE attempt in {nameof(AcceptStarResponse)}");
        //        return BadRequest("Submitted data is invalid");
        //    }

        //    StarResponse.Status = true;

        //    _unitOfWork.StarResponses.Update(StarResponse);
        //    await _unitOfWork.Save();

        //    return Accepted(new { Message = "Accepted Successfully", StatusCode = 202 });

        //}

        //[Authorize]
        //[HttpDelete("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> DeleteStarResponse(int id)
        //{
        //    if (id < 1)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteStarResponse)}");
        //        return BadRequest();
        //    }

        //    var StarResponse = await _unitOfWork.StarResponses.Get(q => q.Id == id);
        //    if (StarResponse == null)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteStarResponse)}");
        //        return BadRequest("Submitted data is invalid");
        //    }

        //    await _unitOfWork.StarResponses.Delete(id);
        //    await _unitOfWork.Save();

        //    return NoContent();

        //}
    }
}
