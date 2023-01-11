using FirisbeCase.Application.Features.Books.Commands;
using FirisbeCase.Application.Features.Books.Models;
using FirisbeCase.Application.Features.Books.Queries;
using FirisbeCase.Core.DynamicQuery;
using FirisbeCase.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FirisbeCase.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateBookModel createBookModel)
        {
            CreateBookCommand createAuthorCommand = new() { CreateBookModel = createBookModel };
            var result = await Mediator.Send(createAuthorCommand);
            if (result.Success)
            {
                return Created("", result);
            }
            return BadRequest(result);
        }
        [HttpGet("get-book-list")]
        public async Task<IActionResult> GetList([FromQuery] ListRequestParameter listRequestParameter)
        {
            GetBookListQuery getBookListQuery = new() { ListRequestParameter = listRequestParameter};
            var result = await Mediator.Send(getBookListQuery);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);  
        }
        [HttpPost("get-book-list-by-dynamic-query")]
        public async Task<IActionResult> GetListByDynamicQuery([FromQuery] ListRequestParameter listRequestParameter,[FromBody] Dynamic dynamic)
        {
            GetBookListByDynamicQuery getBookListByDynamicQuery = new() { ListRequestParameter = listRequestParameter, Dynamic = dynamic };
            var result = await Mediator.Send(getBookListByDynamicQuery);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
