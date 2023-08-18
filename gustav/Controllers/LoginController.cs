using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gustav.Models;
using gustav.Services.LoginService;
using Microsoft.AspNetCore.Mvc;

namespace gustav.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Login model)
        {
            if (model.Password != model.RepeatPassword)
            {
                //SweetAlert
            }
            model.CreatedTimestamp = DateTime.Now;
            await _loginService.CreateAsync(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var model = await _loginService.GetModelAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, Login loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }
            await _loginService.UpdateAsync(id, loginModel);
            
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == "" || id == null)
            {
                return BadRequest();
            }
            await _loginService.DeleteAsync(id);

            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Restore(string id)
        {
            if (id == "" || id == null)
            {
                return BadRequest();
            }
            await _loginService.RestoreAsync(id);

            return Ok();
        }

        //[HttpPost]
        //public async Task<string> Paginate(Login model)
        //{
        //    var data = await _loginService.GetPagination(model);

        //    return data;
        //}

    }
}

