using Application.Interfaces.GetItems;
using CommonDatabase.DapperHelperContext.Interfaces;
using CommonDatabase.Models.Accessories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppProject.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccController : ControllerBase
    {
        private readonly ICommonBeltRepository _accRepository;

        public AccController(ICommonBeltRepository accRepository)
        {
            _accRepository = accRepository;
        }

        [HttpGet]
        public IActionResult GetAccItem()
        {
            try
            {
                return NotFound();  
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult GetAllBelt()
        {
            try
            {
                var result = _accRepository.GetAllBelt();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateBelt(Belt belt)
        {
            try
            {
                var result = _accRepository.CreateBelt(belt);

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult UpdateBelt(Belt belt)
        {
            try
            {
                var result = _accRepository.UpdateBelt(belt);

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult DeleteBelt(int beltId)
        {
            try
            {
                var result = _accRepository.DeleteBelt(beltId);

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult SearchByName(string beltName)
        {
            try
            {
                var result = _accRepository.SearchBeltByName(beltName);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
