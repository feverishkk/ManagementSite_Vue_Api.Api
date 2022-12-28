using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Net.Http.Headers;

namespace AppProject.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserRepository _userRepository;
        private readonly IAuthRepository _authRepository;

        public ApplicationUserController(IApplicationUserRepository userRepository, 
                                         IAuthRepository authRepository)
        {
            _userRepository = userRepository;
            _authRepository = authRepository;
        }

        /// <summary>
        /// DB에 있는 유저와 로그인하려는 유저를 대조한다.
        /// </summary>
        /// <param name="loginCredentials"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private IList<LoginViewModel> AuthenticateUser(LoginViewModel loginCredentials)
        {
            var result = _userRepository.Login(loginCredentials);
            if (result.Count() < 1)
            {
                throw new Exception("Wrong Here");
            }
            return (IList<LoginViewModel>)result;
        }

        /// <summary>
        /// 로그인 된 유저를 가져와 준다.
        /// </summary>
        /// <returns></returns>
        public new IActionResult GetUser()
        {
            try
            {
                var header = Request.Headers["Authorization"].ToString();

                string accessToken = header[7..];

                //var user = User.FindFirst(ClaimTypes.NameIdentifier);
                //var jwt = Request.Cookies[nameof(accessToken)];
                var token = _authRepository.ValidateToken(accessToken);
                
                return Ok(token);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 로그인
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> LoginAsync([FromBody] LoginViewModel model)
        {
            try
            {
                IActionResult response = Unauthorized();

                if (model is null || !ModelState.IsValid)
                {
                    return NotFound();
                }

                var result = AuthenticateUser(model);

                var tokenString = _authRepository.GenerateJWTToken(model);

                Response.Cookies.Append(key: "jwt", value: tokenString, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.None
                });

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme,
                                                  ClaimTypes.Name, ClaimTypes.Role);

                identity.AddClaim(new Claim(ClaimTypes.Name, model.Email));
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity),
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        AllowRefresh = true,
                        ExpiresUtc = DateTime.UtcNow.AddDays(1)
                    });

                response = Ok(new
                {
                    token = tokenString,
                    userDetails = result,
                });

                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 로그아웃
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task Logout()
        {
            Request.Headers.Remove("Authorization");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        /// <summary>
        /// 회원가입
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            try
            {
                if (model is null || !ModelState.IsValid)
                {
                    return NotFound();
                }

                var checkExistEmail = _userRepository.IsExistUser(model.Email);

                if (checkExistEmail is false)
                {
                    return BadRequest("Email already Exist!");
                }

                var result = _userRepository.Register(model);
                if (result == null)
                {
                    return BadRequest("Something Wrong");
                }

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 유저 정보 변경
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateUserInfo(UpdateUserInfoViewModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Email) || model.Password != model.ConfirmPassword)
                {
                    return BadRequest("something wrong");
                }

                var result = _userRepository.UpdateUserInfomation(model);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        
    }
}
