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
    public class RequestEventController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RequestEventController> _logger;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public RequestEventController(IUnitOfWork unitOfWork, ILogger<RequestEventController> logger,
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
        [Route("RequestsOfEvent")]
        public async Task<IActionResult> RequestsOfEvent(int id)
        {
            var RequestEvents = await _unitOfWork.RequestEvents.GetAll(q => q.EventId == id, include: q => q.Include(x => x.Event));
            var results = _mapper.Map<IList<RequestEventDTO>>(RequestEvents);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetRequestEvent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRequestEvent(int id)
        {
            var RequestEvent = await _unitOfWork.RequestEvents.Get(q => q.Id == id, include: q => q.Include(x => x.ApiUser).Include(y => y.Event));
            var result = _mapper.Map<RequestEventDTO>(RequestEvent);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles = "User")]
        [Authorize]
        public async Task<IActionResult> CreateRequestEvent([FromBody] CreateRequestEventDTO createRequestEvent)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateRequestEvent)}");
                return BadRequest(ModelState);
            }

            var checkEvent = await _unitOfWork.RequestEvents.Get(q => q.EventId == createRequestEvent.EventId && q.ApiUserId == createRequestEvent.ApiUserId);
            var RequestEvent = _mapper.Map<RequestEvent>(createRequestEvent);
            if (checkEvent != null)
            {
                return BadRequest(new { Message = "Requested", StatusCode = 400 });
            }
            else
            {
                await _unitOfWork.RequestEvents.Insert(RequestEvent);
                await _unitOfWork.Save();

            }
            return CreatedAtRoute("GetRequestEvent", new { id = RequestEvent.Id }, RequestEvent);
        }

        //[Authorize]
        //[HttpPut("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> UpdateRequestEvent(int id, [FromBody] UpdateRequestEventDTO RequestEventDTO)
        //{
        //    if (!ModelState.IsValid || id < 1)
        //    {
        //        _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateRequestEvent)}");
        //        return BadRequest(ModelState);
        //    }


        //    var RequestEvent = await _unitOfWork.RequestEvents.Get(q => q.Id == id);
        //    if (RequestEvent == null)
        //    {
        //        _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateRequestEvent)}");
        //        return BadRequest("Submitted data is invalid");
        //    }

        //    _mapper.Map(RequestEventDTO, RequestEvent);
        //    _unitOfWork.RequestEvents.Update(RequestEvent);
        //    await _unitOfWork.Save();

        //    return NoContent();

        //}

        //[Authorize]
        //[HttpDelete("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> DeleteRequestEvent(int id)
        //{
        //    if (id < 1)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteRequestEvent)}");
        //        return BadRequest();
        //    }

        //    var RequestEvent = await _unitOfWork.RequestEvents.Get(q => q.Id == id);
        //    if (RequestEvent == null)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteRequestEvent)}");
        //        return BadRequest("Submitted data is invalid");
        //    }

        //    await _unitOfWork.RequestEvents.Delete(id);
        //    await _unitOfWork.Save();

        //    return NoContent();

        //}
    }
}
