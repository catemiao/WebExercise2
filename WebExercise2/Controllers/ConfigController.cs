using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebExercise2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetConfig()
        {
            // 使用 GetSection 讀取 DemoUser
            var demoUser = _configuration.GetSection("DemoUser").Get<DemoUser>();

            // 使用 GetValue 讀取 ConfigValue 和 DemoUrl
            var configValue = _configuration.GetValue<string>("ConfigValue");
            var googleUrl = _configuration.GetValue<string>("DemoUrl:Google");

            // 準備結果
            var result = new
            {
                demoUser.Name,
                demoUser.PhoneNumber,
                demoUser.Address,
                demoUser.Email,
                demoUser.Age,
                demoUser.IsActive
            };

            return Ok(result + Environment.NewLine + configValue + Environment.NewLine + googleUrl);
        }
    }

    public class DemoUser
    {
        public string? Name { get; set; }
        public PhoneNumber? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
    }

    public class PhoneNumber
    {
        public string? Tel { get; set; }
        public string? Phone { get; set; }
    }

}
