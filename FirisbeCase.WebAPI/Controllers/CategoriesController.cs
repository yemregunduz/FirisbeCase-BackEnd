using FirisbeCase.Application.Features.Categories.Commands;
using FirisbeCase.Application.Features.Categories.Models;
using FirisbeCase.Application.Features.Categories.Queries;
using FirisbeCase.Core.DynamicQuery;
using FirisbeCase.Core.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirisbeCase.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryModel createCategoryModel)
        {
            CreateCategoryCommand createCategorycommand = new() { CreateCategoryModel = createCategoryModel };
            var result = await Mediator.Send(createCategorycommand);
            if (result.Success)
            {
                return Created("", result);
            }
            return BadRequest(result);
        }
        [HttpGet("get-category-list")]
        public async Task<IActionResult> GetList([FromQuery] ListRequestParameter listRequestParameter)
        {
            GetCategoryListQuery getCategoryListQuery = new() { ListRequestParameter = listRequestParameter };
            var result = await Mediator.Send(getCategoryListQuery);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("get-category-list-by-dynamic-query")]
        public async Task<IActionResult> GetListByDynamicQuery([FromQuery] ListRequestParameter listRequestParameter, [FromBody] Dynamic dynamic)
        {
            GetCategoryListByDynamicQuery getCategoryListByDynamicQuery = new() { ListRequestParameter = listRequestParameter, Dynamic = dynamic };
            var result = await Mediator.Send(getCategoryListByDynamicQuery);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }

}
