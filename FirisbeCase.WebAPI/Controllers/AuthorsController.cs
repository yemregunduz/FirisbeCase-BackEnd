using FirisbeCase.Application.Features.Authors.Commands;
using FirisbeCase.Application.Features.Authors.Models;
using FirisbeCase.Application.Features.Authors.Queries;
using FirisbeCase.Core.DynamicQuery;
using FirisbeCase.Core.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirisbeCase.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : BaseController
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateAuthorModel createAuthorModel )
        {
            CreateAuthorCommand createAuthorCommand = new() { CreateAuthorModel = createAuthorModel };
            var result = await Mediator.Send(createAuthorCommand);
            if (result.Success)
            {
                return Created("", result);
            }
            return BadRequest(result);
        }
        [HttpGet("get-author-list")]
        public async Task<IActionResult> GetList([FromQuery] ListRequestParameter listRequestParameter)
        {
            GetAuthorListQuery getAuthorListQuery = new() { ListRequestParameter = listRequestParameter };
            var result = await Mediator.Send(getAuthorListQuery);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("get-author-list-by-dynamic-query")]
        public async Task<IActionResult> GetListByDynamicQuery([FromQuery] ListRequestParameter listRequestParameter, [FromBody] Dynamic dynamic)
        {
            GetAuthorListByDynamicQuery getAuthorListByDynamicQuery = new() { ListRequestParameter = listRequestParameter, Dynamic = dynamic };
            var result = await Mediator.Send(getAuthorListByDynamicQuery);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
