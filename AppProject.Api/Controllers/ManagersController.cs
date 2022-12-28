using Application.Interfaces;
using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppProject.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerRepository _managerRepository;
        public ManagersController(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        /// <summary>
        /// 모든 매니저들을 다 들고 온다.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetAllMangers()
        {
            try
            {
                var result = _managerRepository.GetAllManagers();

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 매니저 삭제
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteManger(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("There are no such user.");
                }

                _managerRepository.DeleteManager(id);

                return Ok();    
            }
            catch
            {
                return NotFound();
            }
        }

        /// <summary>
        /// 매니저 정보를 들고 온다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetManagerById(int id)
        {
            try
            {
                var result = _managerRepository.GetManagerById(id);

                return Ok(result);
            }
            catch
            {
                return NotFound("There are no such user");
            }
        }

        /// <summary>
        /// 매니저 정보 수정
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateManagerInfo([FromBody] UpdateManagerInfo model)
        {
            try
            {
                if (model is null || model.Id < 0)
                {
                    return BadRequest("Something wrong..");
                }

                var result = _managerRepository.UpdateManagerInfo(model);

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 매니저 Role을 가지고 온다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetManagerRole(int id)
        {
            try
            {
                var result = _managerRepository.GetManagerRole(id);

                return Ok(result);
            }
            catch
            {
                return BadRequest("");
            }
        }

        /// <summary>
        /// 매니저의 Role 업데이트 가능.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="selectedRole"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult UpdateManagerRole([FromBody] UpdateManagerRoleViewModel model)
        {
            //if(model.Id < 0 || string.IsNullOrEmpty(model.SelectedRole))
            //{
            //    return BadRequest("Something Wrong.. Please try again!");
            //}
            try
            {
                //var result = _managerRepository.UpdateManagerRole(model);
                var result = _managerRepository.UpdateManagerRole(model);
                return Ok();
            }
            catch
            {
                return BadRequest("");
            }
        }

        
    }
}
