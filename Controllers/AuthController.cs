using Microsoft.AspNetCore.Mvc;
using JsonWebToken_API.Helpers;
using JsonWebToken_API.Models;
using Newtonsoft.Json;

namespace JsonWebToken_API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;
        private IConfiguration configuration;
        public AuthController(ILogger<AuthController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            configuration = iConfig;
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult Jwt(string nip)
        {
            return new ObjectResult(JwtToken.GenerateJwtToken(nip));
        }

        [HttpGet]
        [Route("[controller]/getToken")]
        public AuthModel<CommonModel> getToken(string nip)
        {
            AuthModel<CommonModel> result = new AuthModel<CommonModel>();
            result.Code = true;
            result.Message = "Berhasil Mengambil Token";
            tokenValue resultToken = JsonConvert.DeserializeObject<tokenValue>(JsonConvert.SerializeObject(Jwt(nip)));
            string val = resultToken.Value;
            result.Token = val;

            return result;
        }

}
}