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
    public class EventController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EventController> _logger;
        private readonly IMapper _mapper;

        public EventController(IUnitOfWork unitOfWork, ILogger<EventController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEvents([FromQuery] RequestParams requestParams)
        {
            var Events = await _unitOfWork.Events.GetPagedList(requestParams, include: q => q.Include(x => x.EventMemberships).Include(y => y.EventVideos).Include(z => z.Sponsors).Include(v => v.EventType).Include(r => r.EventRates));
            var results = _mapper.Map<IList<EventDTO>>(Events);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetEvent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEvent(int id)
        {
            var Event = await _unitOfWork.Events.Get(q => q.Id == id, include: q => q.Include(x => x.EventMemberships).Include(y => y.EventVideos).Include(z => z.Sponsors).Include(v => v.EventType).Include(r => r.EventRates));
            var result = _mapper.Map<EventDTO>(Event);
            return Ok(result);
        }

        //[Authorize(Roles = "Administrator")]
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> CreateEvent([FromBody] EventDTO EventDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogError($"Invalid POST attempt in {nameof(CreateEvent)}");
        //        return BadRequest(ModelState);
        //    }

        //    var Event = _mapper.Map<Event>(EventDTO);
        //    await _unitOfWork.Events.Insert(Event);
        //    await _unitOfWork.Save();

        //    return CreatedAtRoute("GetEvent", new { id = Event.Id }, Event);
        //}

        //[Authorize]
        //[HttpPut("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> UpdateEvent(int id, [FromBody] UpdateEventDTO EventDTO)
        //{
        //    if (!ModelState.IsValid || id < 1)
        //    {
        //        _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateEvent)}");
        //        return BadRequest(ModelState);
        //    }


        //    var Event = await _unitOfWork.Events.Get(q => q.Id == id);
        //    if (Event == null)
        //    {
        //        _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateEvent)}");
        //        return BadRequest("Submitted data is invalid");
        //    }

        //    _mapper.Map(EventDTO, Event);
        //    _unitOfWork.Events.Update(Event);
        //    await _unitOfWork.Save();

        //    return NoContent();

        //}

        //[Authorize]
        //[HttpDelete("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> DeleteEvent(int id)
        //{
        //    if (id < 1)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteEvent)}");
        //        return BadRequest();
        //    }

        //    var Event = await _unitOfWork.Events.Get(q => q.Id == id);
        //    if (Event == null)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteEvent)}");
        //        return BadRequest("Submitted data is invalid");
        //    }

        //    await _unitOfWork.Events.Delete(id);
        //    await _unitOfWork.Save();

        //    return NoContent();

        //}
    }
}
