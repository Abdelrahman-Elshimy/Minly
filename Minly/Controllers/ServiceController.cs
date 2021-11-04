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
    public class ServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ServiceController> _logger;
        private readonly IMapper _mapper;

        public ServiceController(IUnitOfWork unitOfWork, ILogger<ServiceController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetServices([FromQuery] RequestParams requestParams)
        {
            var Services = await _unitOfWork.Services.GetPagedList(requestParams, include: q => q.Include(x => x.Stars));
            var results = _mapper.Map<IList<GETServiceDTO>>(Services);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetService")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetService(int id)
        {
            var Service = await _unitOfWork.Services.Get(q => q.Id == id, include: q => q.Include(x => x.Stars));
            var result = _mapper.Map<GETServiceDTO>(Service);
            return Ok(result);
        }

        //[Authorize(Roles = "Administrator")]
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> CreateService([FromBody] ServiceDTO ServiceDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogError($"Invalid POST attempt in {nameof(CreateService)}");
        //        return BadRequest(ModelState);
        //    }

        //    var Service = _mapper.Map<Service>(ServiceDTO);
        //    await _unitOfWork.Services.Insert(Service);
        //    await _unitOfWork.Save();

        //    return CreatedAtRoute("GetService", new { id = Service.Id }, Service);
        //}

        //[Authorize]
        //[HttpPut("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> UpdateService(int id, [FromBody] UpdateServiceDTO ServiceDTO)
        //{
        //    if (!ModelState.IsValid || id < 1)
        //    {
        //        _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateService)}");
        //        return BadRequest(ModelState);
        //    }


        //    var Service = await _unitOfWork.Services.Get(q => q.Id == id);
        //    if (Service == null)
        //    {
        //        _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateService)}");
        //        return BadRequest("Submitted data is invalid");
        //    }

        //    _mapper.Map(ServiceDTO, Service);
        //    _unitOfWork.Services.Update(Service);
        //    await _unitOfWork.Save();

        //    return NoContent();

        //}

        //[Authorize]
        //[HttpDelete("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> DeleteService(int id)
        //{
        //    if (id < 1)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteService)}");
        //        return BadRequest();
        //    }

        //    var Service = await _unitOfWork.Services.Get(q => q.Id == id);
        //    if (Service == null)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteService)}");
        //        return BadRequest("Submitted data is invalid");
        //    }

        //    await _unitOfWork.Services.Delete(id);
        //    await _unitOfWork.Save();

        //    return NoContent();

        //}
    }
}
