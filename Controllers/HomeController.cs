using Microsoft.AspNetCore.Mvc;
using JsonWebToken_API.Models;
using Microsoft.AspNetCore.Authorization;

namespace JsonWebToken_API.Controllers
{
    [ApiController]
 
    public class HomeController : ControllerBase
    {
     
        [HttpGet]
        [Authorize]
        [Route("[controller]")]
       
        public IActionResult Home(string FullName)
        {
            ResultModel<List<CommonModel>> result = new ResultModel<List<CommonModel>>();
            bool code = false;
            string msg = "";
            if (FullName == null)
            {
                code = true;
                msg = "Hello World";
            }
            else
            {
                code = true;
                msg = "Hello " + FullName;
            }
            result.Code = code;
            result.Message = msg;
            return Ok(result);

        }

      
    }
}
