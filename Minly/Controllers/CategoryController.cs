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
using System;

namespace Minly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CategoryController> _logger;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, ILogger<CategoryController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategories([FromQuery] RequestParams requestParams)
        {
            try
            {
                var Categorys = await _unitOfWork.Categories.GetPagedList(requestParams, include: q => q.Include(x => x.Stars));
                var results = _mapper.Map<IList<GETCategoryDTO>>(Categorys);
                if(results.Count == 0) {
                    var error = new Error
                    {
                        Message = "No Categories Founded",
                        StatusCode = 500
                    };
                    return Problem(error.ToString());
                }
                return Ok(results);
            }catch (Exception ex)
            {
                var error = new Error
                {
                    Message = "Failed operation get categories",
                    StatusCode = 500
                };
                return Problem(error.ToString());
            }
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategory(int id)
        {
            try
            {
                
                var Category = await _unitOfWork.Categories.Get(q => q.Id == id, include: q => q.Include(x => x.Stars));
                var result = _mapper.Map<GETCategoryDTO>(Category);
                if(result == null)
                {
                    var error = new Error
                    {
                        Message = "No Category With this Id",
                        StatusCode = 500
                    };
                    return Problem(error.ToString());
                }
                return Ok(result);
            }catch (Exception ex)
            {
                var error = new Error
                {
                    Message = "Failed operation get categories",
                    StatusCode = 500
                };
                return Problem(error.ToString());
    }
}

        //[Authorize(Roles = "Administrator")]
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO CategoryDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogError($"Invalid POST attempt in {nameof(CreateCategory)}");
        //        return BadRequest(ModelState);
        //    }

        //    var Category = _mapper.Map<Category>(CategoryDTO);
        //    await _unitOfWork.Categorys.Insert(Category);
        //    await _unitOfWork.Save();

        //    return CreatedAtRoute("GetCategory", new { id = Category.Id }, Category);
        //}

        //[Authorize]
        //[HttpPut("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDTO CategoryDTO)
        //{
        //    if (!ModelState.IsValid || id < 1)
        //    {
        //        _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCategory)}");
        //        return BadRequest(ModelState);
        //    }


        //    var Category = await _unitOfWork.Categorys.Get(q => q.Id == id);
        //    if (Category == null)
        //    {
        //        _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCategory)}");
        //        return BadRequest("Submitted data is invalid");
        //    }

        //    _mapper.Map(CategoryDTO, Category);
        //    _unitOfWork.Categorys.Update(Category);
        //    await _unitOfWork.Save();

        //    return NoContent();

        //}

        //[Authorize]
        //[HttpDelete("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> DeleteCategory(int id)
        //{
        //    if (id < 1)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCategory)}");
        //        return BadRequest();
        //    }

        //    var Category = await _unitOfWork.Categorys.Get(q => q.Id == id);
        //    if (Category == null)
        //    {
        //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCategory)}");
        //        return BadRequest("Submitted data is invalid");
        //    }

        //    await _unitOfWork.Categorys.Delete(id);
        //    await _unitOfWork.Save();

        //    return NoContent();

        //}
    }
}
