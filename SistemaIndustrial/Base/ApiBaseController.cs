using Microsoft.AspNetCore.Mvc;
using SistemaIndustrial.Services.ViewModels.ResponseResult;

namespace SistemaIndustrial.Base
{
    public class ApiBaseController : ControllerBase
    {
        protected ApiBaseController()
        {
        }

        protected new IActionResult Response(object result = null)
        {
            if (result != null)
            {
                if (result is Dictionary<string, string>)
                {
                    return ResponseBadRequest(result);
                }

                return OkResponse(result);
            }

            return BadRequest();
        }

        protected new IActionResult ResponseBadRequest(object result)
        {
            var dtoResult = result as Dictionary<string, string>;

            new ActionContext().HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            return new JsonResult(new
            {
                success = false,
                data = dtoResult.Select(a => new { ErrorCode = a.Key, Message = a.Value })
            });
        }

        protected new IActionResult OkResponse(object result = null)
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        protected new IActionResult OkResponse<T>(ResponseResult<T> result)
        {
            return Ok(result);
        }
    }
}
