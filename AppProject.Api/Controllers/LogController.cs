using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppProject.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogRepository _logRepository;

        public LogController(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        /// <summary>
        /// 로그 출력
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllLog()
        {
            try
            {
                var result = _logRepository.GetAllLog();

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
