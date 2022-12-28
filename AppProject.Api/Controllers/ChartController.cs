using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppProject.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly IChartRepository _chartRepository;

        public ChartController(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }


        /// <summary>
        /// 성별 기준 차트
        /// Pie Chart
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCustomerGender()
        {
            try
            {
                var result = _chartRepository.GetCustomerGender();

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 길드 분포
        /// Bar Chart
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetGuildProperty()
        {
            try
            {
                var result = _chartRepository.GetGuildProperty();

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 가입날짜 순
        /// Line Chart
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMemberSince()
        {
            try
            {
                var result = _chartRepository.GetMemberSince();

                return Ok(result);

            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 선호하는 결제 회사
        /// Bar Chart
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetPreferPayment()
        {
            try
            {
                var result = _chartRepository.GetPreferPayment();

                return Ok(result);

            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
