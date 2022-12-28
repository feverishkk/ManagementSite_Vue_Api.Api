using CommonDatabase.DapperHelperContext.DapperHelper;
using CommonDatabase.DapperHelperContext.Interfaces;
using CommonDatabase.Models.Equipment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppProject.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EqpController : ControllerBase
    {
        private readonly ICommonArmorRepository _eqpRepository;

        public EqpController(ICommonArmorRepository eqpRepository)
        {
            _eqpRepository = eqpRepository;
        }

        [HttpGet]
        public IActionResult GetAllArmors()
        {
            try
            {
                var result = _eqpRepository.GetAllArmor();
                return Ok(result); 
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateArmor(Armor armor)
        {
            try
            {
                var result = _eqpRepository.CreateArmor(armor);

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult UpdateArmor(Armor armor)
        {
            try
            {
                var result = _eqpRepository.UpdateArmor(armor);

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult DeleteArmor(int armorId)
        {
            try
            {
                var result = _eqpRepository.DeleteArmor(armorId);

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult SearchByName(string armorName)
        {
            try
            {
                var result = _eqpRepository.SearchArmorByName(armorName);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
