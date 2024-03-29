using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using authentication_repo.Models;
using authentication_repo.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models;
using TheBookCave.Models.ViewModels;
using TheBookCave.Services;

namespace TheBookCave.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminUserController : Controller
    {
        private AdminUserService _adminUserService;
        private UserService _UserService;
        private ConvertService _convertService;
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _signInMager;

    
        public AdminUserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) {
            _userManger =  userManager;
            _signInMager =  signInManager;
            _adminUserService = new AdminUserService();
            _convertService = new ConvertService();
            _UserService = new UserService();
        }
        
        public IActionResult index()
        {
            var userList = _adminUserService.getAllUsers();
            return View(userList);
        }

        [HttpPost]
        public IActionResult index(string searchString)
        {
            var searchResult = _adminUserService.getSearchResult(searchString);
            return View(searchResult);
        }

        public IActionResult userDetails(string id)
        {
            var user = _UserService.getUser(id);
            return View(user);
        }

        
        public IActionResult editUser(string id) {
			var user = _adminUserService.getUpdateUser(id);
			return View(user);
        }

        [HttpPost]
        public ActionResult editUser(UserDetailedListViewModel model) {
           	if (ModelState.IsValid) {
				_adminUserService.updateUser(model);
				return RedirectToAction("index");
			}
			return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addUser(RegisterViewModel model)
        {
            // Error handling
            if(!ModelState.IsValid){
                return View();
            }
            // nyr user . Username og email verd tad sama
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            //  Task til ad nota asynic
            // _userMangar byr til user i startup
            var result = await _userManger.CreateAsync(user, model.Password);

            if(result.Succeeded){
                // user is succesfully registered
                // concatenated first and last name as fullname in claims
                await _userManger.AddClaimAsync(user, new Claim("Name", $"{model.FirstName} {model.LastName}"));

              //   await _signInMager.SignInAsync(user,false);

                return RedirectToAction("index", "AdminUser");
            }

            return View();
        }

        public IActionResult removeUser(string id)
        {
            var user = _UserService.getUser(id);
            if(!user.Any()) {
                return RedirectToAction("SubscriptionNotFound");
            }
			return View(user.First());

        }

        [HttpPost]
        public ActionResult removeUser(UserListViewModel user){
           	if (ModelState.IsValid) {
				_adminUserService.removeUser(user);
				return RedirectToAction("index");
			}
			return View(user);
        }
    }
}
