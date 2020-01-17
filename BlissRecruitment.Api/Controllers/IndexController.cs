using Microsoft.AspNetCore.Mvc;

namespace BlissRecruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Running Api";
        }
    }
}
