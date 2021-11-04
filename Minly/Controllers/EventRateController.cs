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
    public class EventRateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EventRateController> _logger;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public EventRateController(IUnitOfWork unitOfWork, ILogger<EventRateController> logger,
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
        public async Task<IActionResult> GetEventRates([FromQuery] RequestParams requestParams)
        {
            var EventRates = await _unitOfWork.EventRates.GetPagedList(requestParams, include: q => q.Include(x => x.ApiUser).Include(y => y.Event));
            var results = _mapper.Map<IList<EventRateDTO>>(EventRates);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetEventRate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEventRate(int id)
        {
            var EventRate = await _unitOfWork.EventRates.Get(q => q.Id == id, include: q => q.Include(x => x.ApiUser).Include(y => y.Event));
            var result = _mapper.Map<EventRateDTO>(EventRate);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles = "User")]
        [Authorize]
        public async Task<IActionResult> CreateEventRate([FromBody] CreateEventRate createEventRate)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateEventRate)}");
                return BadRequest(ModelState);
            }

            var checkEvent = await _unitOfWork.EventRates.Get(q => q.EventId == createEventRate.EventId && q.ApiUserId == createEventRate.ApiUserId);
            var EventRate = _mapper.Map<EventRate>(createEventRate);
            if (checkEvent != null)
            {
                checkEvent.Rate = createEventRate.Rate;
                _unitOfWork.EventRates.Update(checkEvent);
                await _unitOfWork.Save();
            }
            else
            {
                await _unitOfWork.EventRates.Insert(EventRate);
                await _unitOfWork.Save();
                
            }
            var myEventRates = await _unitOfWork.EventRates.GetAll(q => q.EventId == createEventRate.EventId);
            double sum = _unitOfWork.GetRatesOfEvents();
            var count = myEventRates.Count;
            var newRate = sum / count;
            var myEvent = await _unitOfWork.Events.Get(q => q.Id == createEventRate.EventId);
            myEvent.Rate = newRate;
            _unitOfWork.Events.Update(myEvent);
            await _unitOfWork.Save();
            return CreatedAtRoute("GetEventRate", new { id = EventRate.Id }, EventRate);


        }

        //[Authorize]
        //[HttpPut("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> UpdateEventRate(int id, [FromBody] UpdateEventRateDTO EventRateDTO)
        //{
        //    if (!ModelState.IsValid || id < 1)
        //    {
        //        _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateEventRate)}");
        //        return BadRequest(ModelState);
        //    }


        //    var EventRate = await _unitOfWork.EventRates.Get(q => q.Id == id);
        //    if (EventRate == null)
        //    {
        //        _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateEventRate)}");
        //        return BadRequest("Submitted data is invalid");
        //    }

        //    _mapper.Map(EventRateDTO, EventRate);
        //    _unitOfWork.EventRates.Update(EventRate);
        //    await _unitOfWork.Save();

        //    return NoContent();

        //}

        //[Authorize]
        //[HttpDelete("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> DeleteEventRate(int id)
        //{
        //    if (id < 1)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteEventRate)}");
        //        return BadRequest();
        //    }

        //    var EventRate = await _unitOfWork.EventRates.Get(q => q.Id == id);
        //    if (EventRate == null)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteEventRate)}");
        //        return BadRequest("Submitted data is invalid");
        //    }

        //    await _unitOfWork.EventRates.Delete(id);
        //    await _unitOfWork.Save();

        //    return NoContent();

        //}
    }
}
