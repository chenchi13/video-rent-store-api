using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Prometheus;
using VideoRentStore.API.Areas.Identity.Data;
using VideoRentStore.API.Models;

namespace VideoRentStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private Counter counter = Metrics.CreateCounter("myLoginCounter", "some help about this");

        //private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public AccountsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //logger.Trace("Attempted login.");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    counter.Inc();
                    //logger.Trace("User {username} logged in.", model.Username);
                    return Ok(new { model.Username });
                }
                else
                {
                    //logger.Trace("Invalid login attempt.");
                    return BadRequest(result);
                }
            }

            //logger.Trace("Login attempt failed because of bad model state.");
            return BadRequest();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //logger.Trace("Attempted new user registration.");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    //logger.Trace("New user with ID {userId} registered and logged in.", user.Id);
                    return Ok(new { user.UserName });
                }
                else
                {
                    //logger.Trace("Registration attempt failed with errors: {errors}.", result.Errors.Select(e => e.Code));
                    return BadRequest(result);
                }
            }

            //logger.Trace("Registration attempt failed because of bad model state.");
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            if (_signInManager.IsSignedIn(User))
            {
                string id = _userManager.GetUserId(User);
                string username = _userManager.GetUserName(User);
                await _signInManager.SignOutAsync();
                //logger.Trace("User {username} with ID {id} logged out.", username, id);
            }
            return Ok();
        }
    }
}