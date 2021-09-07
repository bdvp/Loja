namespace Loja.Service.Api.Cliente.Controllers
{
    using Loja.Domain.Core.ValueObject;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        // TODO : refatorar essa classe
        protected new IActionResult Response(Result result)
        {
            if (result == null || result.HasError)
            {
                return CreateErrorResponse(result);
            }

            return Ok(new
            {
                success = true
            });
        }

        protected new IActionResult Response<T>(Result<T> result)
        {
            if (result == null || result.HasError)
            {
                return CreateErrorResponse(result);
            }

            return Ok(new
            {
                success = true,
                data = result.Value
            });
        }

        private BadRequestObjectResult CreateErrorResponse(Result result)
        {
            return BadRequest(new
            {
                success = false,
                errors = result?.Error ?? new Result().Error
            });
        }
    }
}
