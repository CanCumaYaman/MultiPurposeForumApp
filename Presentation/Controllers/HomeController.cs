
using Business.Abstract;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IAuthService _authService;
        public HomeController(ILogger<HomeController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public IActionResult Questions()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Articles()
        {

            return View();
        }
        [HttpGet]
        public IActionResult About()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public IActionResult RegisterConfirm(UserForRegisterDto userForRegisterDto)
        {
            _authService.Register(userForRegisterDto, userForRegisterDto.Password);

            return View("Index");
        }
        [HttpPost]
        public IActionResult LoginConfirm(UserForLoginDto userForLoginDto)
        {

            
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return View("Login");
                
            }
            var result = _authService.CreateAccessToken(userToLogin.Data);

            if (result.Success)
            {
                return View("Main");
            }
            return View("Main");


        }
        [HttpGet]
        public IActionResult Main()
        {

            return View();
        }
    }
}
