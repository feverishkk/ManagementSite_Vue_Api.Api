using Application.Interfaces.GetItems;
using CommonDatabase.DapperHelperContext.DapperHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppProject.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GetItemController : ControllerBase
    {
        private readonly IWeaponRepository _weaponRepository;
        private readonly IArmorRepository _armorRepository;
        private readonly IBeltRepository _beltRepository;
        private readonly IBootsRepository _bootsRepository;
        private readonly ICapeRepository _capeRepository;
        private readonly IEarRingRepository _earRingRepository;
        private readonly IGlobeRepository _globeRepository;
        private readonly IGuardRepository _guardRepository;
        private readonly IHelmetRepository _helmetRepository;
        private readonly INecklessRepository _necklessRepository;
        private readonly IRingOneRepository _ringOneRepository;
        private readonly IRingTwoRepository _ringTwoRepository;
        private readonly ITShirtRepository _tShirtRepository;

        public GetItemController(IWeaponRepository weaponRepository, IArmorRepository armorRepository,
                                 IBeltRepository beltRepository, ICapeRepository capeRepository,
                                 IEarRingRepository earRingRepository, IGlobeRepository globeRepository,
                                 IHelmetRepository helmetRepository, INecklessRepository necklessRepository,
                                 IRingOneRepository ringOneRepository, IRingTwoRepository ringTwoRepository,
                                 ITShirtRepository tShirtRepository, IBootsRepository bootsRepository, 
                                 IGuardRepository guardRepository)
        {
            _weaponRepository = weaponRepository;
            _armorRepository = armorRepository;
            _beltRepository = beltRepository;
            _capeRepository = capeRepository;
            _earRingRepository = earRingRepository;
            _helmetRepository = helmetRepository;
            _necklessRepository = necklessRepository;
            _globeRepository = globeRepository;
            _ringOneRepository = ringOneRepository;
            _ringTwoRepository = ringTwoRepository;
            _tShirtRepository = tShirtRepository;
            _bootsRepository = bootsRepository;
            _guardRepository = guardRepository;
        }
        /// <summary>
        /// 아이템 리스트를 가져온다.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult GetAllWeapons()
        {
            try
            {
                var reuslt = _weaponRepository.GetAll();
                return Ok(reuslt);
            }
            catch
            {
                return BadRequest("Something went Wrong...");
            }
        }

        [HttpGet]
        public IActionResult GetAllArmors()
        {
            try
            {
                var reuslt = _armorRepository.GetAll();
                return Ok(reuslt);
            }
            catch
            {
                return BadRequest("Something went Wrong...");
            }
        }

        [HttpGet]
        public IActionResult GetAllBelts()
        {
            try
            {
                var reuslt = _beltRepository.GetAll();
                return Ok(reuslt);
            }
            catch
            {
                return BadRequest("Something went Wrong...");
            }
        }

        [HttpGet]
        public IActionResult GetAllBoots()
        {
            try
            {
                var reuslt = _bootsRepository.GetAll();
                return Ok(reuslt);
            }
            catch
            {
                return BadRequest("Something went Wrong...");
            }
        }

        [HttpGet]
        public IActionResult GetAllCapes()
        {
            try
            {
                var reuslt = _capeRepository.GetAll();
                return Ok(reuslt);
            }
            catch
            {
                return BadRequest("Something went Wrong...");
            }
        }

        [HttpGet]
        public IActionResult GetAllEarRings()
        {
            try
            {
                var reuslt = _earRingRepository.GetAll();
                return Ok(reuslt);
            }
            catch
            {
                return BadRequest("Something went Wrong...");
            }
        }

        [HttpGet]
        public IActionResult GetAllGlobes()
        {
            try
            {
                var reuslt = _globeRepository.GetAll();
                return Ok(reuslt);
            }
            catch
            {
                return BadRequest("Something went Wrong...");
            }
        }

        [HttpGet]
        public IActionResult GetAllGuards()
        {
            try
            {
                var reuslt = _guardRepository.GetAll();
                return Ok(reuslt);
            }
            catch
            {
                return BadRequest("Something went Wrong...");
            }
        }

        [HttpGet]
        public IActionResult GetAllHelmets()
        {
            try
            {
                var reuslt = _helmetRepository.GetAll();
                return Ok(reuslt);
            }
            catch
            {
                return BadRequest("Something went Wrong...");
            }
        }

        [HttpGet]
        public IActionResult GetAllNeckless()
        {
            try
            {
                var reuslt = _necklessRepository.GetAll();
                return Ok(reuslt);
            }
            catch
            {
                return BadRequest("Something went Wrong...");
            }
        }

        [HttpGet]
        public IActionResult GetAllRingOne()
        {
            try
            {
                var reuslt = _ringOneRepository.GetAll();
                return Ok(reuslt);
            }
            catch
            {
                return BadRequest("Something went Wrong...");
            }
        }

        [HttpGet]
        public IActionResult GetAllRingTwo()
        {
            try
            {
                var reuslt = _ringTwoRepository.GetAll();
                return Ok(reuslt);
            }
            catch
            {
                return BadRequest("Something went Wrong...");
            }
        }

        [HttpGet]
        public IActionResult GetAllTShirt()
        {
            try
            {
                var reuslt = _tShirtRepository.GetAll();
                return Ok(reuslt);
            }
            catch
            {
                return BadRequest("Something went Wrong...");
            }
        }
    }
}
