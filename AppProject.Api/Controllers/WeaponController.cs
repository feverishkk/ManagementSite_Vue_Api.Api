using Application.Interfaces;
using Application.Interfaces.GetItems;
using CommonDatabase.DapperHelperContext.Interfaces;
using CommonDatabase.Models.Weapons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppProject.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly ICommonOneHandSwordRepository _oneHandSwordRepository;
        private readonly IWeaponRepository _weaponRepository;

        public WeaponController(ICommonOneHandSwordRepository oneHandSwordRepository, 
                                IWeaponRepository weaponRepository)
        {
            _oneHandSwordRepository = oneHandSwordRepository;
            _weaponRepository = weaponRepository;
        }

        [HttpGet]
        public IActionResult GetOneHandSword()
        {
            try
            {
                var ressult = _oneHandSwordRepository.GetAllOneHandSword();

                return Ok(ressult);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateOneHandSword(OneHandSword oneHandSword)
        {
            try
            {
                var result = _oneHandSwordRepository.CreateOneHandSword(oneHandSword);

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult UpdateOneHandSword(OneHandSword oneHandSword)
        {
            try
            {
                var result = _oneHandSwordRepository.UpdateOneHandSword(oneHandSword);

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult DeleteOneHandSword(int oneHandSwordId)
        {
            try
            {
                var result = _oneHandSwordRepository.DeleteOneHandSword(oneHandSwordId);

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult SearchByName(string oneHandSwordName)
        {
            try
            {
                var result = _oneHandSwordRepository.SearchOneHandSwordByName(oneHandSwordName);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

    }
}
