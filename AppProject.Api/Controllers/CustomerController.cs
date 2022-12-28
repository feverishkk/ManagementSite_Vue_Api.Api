using Application.Interfaces;
using Application.ViewModels;
using CommonDatabase.Models.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace AppProject.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogRepository _logRepository;

        public CustomerController(ICustomerRepository customerRepository, ILogRepository logRepository)
        {
            _customerRepository = customerRepository;
            _logRepository = logRepository;
        }

        /// <summary>
        /// 모든 고객들의 정보를 가져온다.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var result = _customerRepository.GetAllCustomers();

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 특정 고객의 정보를 가져온다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCustomerById(string id)
        {
            try
            {
                var result = _customerRepository.GetCustomerById(id);
                if (result is null)
                {
                    return BadRequest("There is no such user");
                }
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        
        /// <summary>
        /// 고객들의 장비정보를 가져온다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCustomerEquipment(string id)
        {
            try
            {
                if (id is null || id is "")
                {
                    return BadRequest("Id cannot be null");
                }
                var result = _customerRepository.GetCustomerEquipment(id);

                if (result is null)
                {
                    return BadRequest("There is no such user");
                }

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 고객의 인게임 정보를 가져온다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCustomerInGameInfo(string id)
        {
            try
            {
                if (id is null)
                {
                    return NotFound();
                }
                var result = _customerRepository.GetCustomersInGameInfo(id);

                if (result is null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 고객의 장비를 업데이트 해준다.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateCustomerEquipment([FromBody] UpdateCustomerEquipmentViewModel? model = null)
        {
            try
            {
                if (model is null|| model.SelectedItem < 0 || string.IsNullOrEmpty(model.ManagerId) ||
                     string.IsNullOrEmpty(model.CustomerId) || string.IsNullOrEmpty(model.ItemName))
                {
                    return BadRequest("Id cannot be null or empty");
                }

                var result = _customerRepository.UpdateCustomerEquipment(model);

                _logRepository.LogForCRUD(model.CustomerId, model.ManagerId, model.ItemName, 
                                          model.SelectedItem);

                return Ok(result);
            }
            catch
            {
                return BadRequest("Something Went Wrong...");
            }
        }

    }
}
