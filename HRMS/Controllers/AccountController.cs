using HRMS.Common.ErrorClass;
using HRMS.Entity.Models;
using HRMS.Entity.ViewModel;
using HRMS.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Data;
using System.Security.Claims;

namespace HRMS.Controllers
{
    [Authorize(Roles = ("HR,Admin"))]
    public class AccountController : Controller
    {
        private  IWebHostEnvironment _env;
        private readonly IAdminRepository repository;

        public UserManager<IdentityUser> _userManager { get; }
        public SignInManager<IdentityUser> SignInManager { get; }
        public RoleManager<IdentityRole> _roleManager { get; }

        private readonly IToastNotification _toastService;


        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IWebHostEnvironment env, 
            IAdminRepository repository,
            IToastNotification toast)
        {
            _userManager = userManager;
            SignInManager = signInManager;
            _roleManager = roleManager;
            _env = env;
            this.repository = repository;
            _toastService = toast;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                    if (result.Succeeded)
                    {

                        return RedirectToAction("Index", "User");
                    }

                }
                _toastService.AddWarningToastMessage("Invalid Login Credintials");
                return View(model);
            }
            catch (Exception ex)
            {
                _toastService.AddWarningToastMessage(ex.Message);
                return View(model);
            }
        }

        public async Task<IActionResult> Register()
        {
            ViewBag.Salary = repository.GetAllSalary();
            ViewBag.Department = repository.GetAllDept();
            ViewBag.Position = repository.GetAllPosition();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Employee model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = model.email,
                    Email = model.email
                };
                var temp = repository.ViewAllEmpolyee();
                var temp1 = temp.Where(x => x.email == model.email).Count();
                if (temp1>0)
                {
                    _toastService.AddWarningToastMessage("Email Already Exists!");
                    return RedirectToAction("Register");
                }

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    model.employeeid = user.Id;
                    model.date = DateTime.Now;
                    model.isdeleted = false;
                    if (model.imagepath != null)
                    {
                        string folderPath = Path.Combine(_env.WebRootPath, "UserImage");
                        string filePath = Path.Combine(folderPath, model.imagepath.FileName);
                        model.imagepath.CopyTo(new FileStream(filePath, FileMode.Create));
                        model.image = model.imagepath.FileName;
                    }
                    repository.CreateEmployee(model);
                    _toastService.AddSuccessToastMessage("Employee Added Successfully!");
                    return RedirectToAction("Login");
                }
            }

                _toastService.AddWarningToastMessage("Could not Register. Some error occured!");
                return RedirectToAction("ViewAllEmployee", "ManageEmployee");
            
        }
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            SignInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ErrorResult<ChangePasswordViewModel> model) // To handle error usinng nested class
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    model.ErrorMessage = "User DesNot Exists";
                    return View(model);
                }

                var result = await _userManager.ChangePasswordAsync(user, model.Item.OldPassword, model.Item.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ViewUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> AddRemoveRoles(string id)
        {
            var users = await _userManager.FindByIdAsync(id);
            var roles = await _roleManager.Roles.ToListAsync();

            UserRollViewModel userRoll = new UserRollViewModel()
            {
                Id = users.Id,
                UserName = users.UserName
            };

            foreach (var role in roles)
            {
                var temp = await _userManager.IsInRoleAsync(users, role.Name);
                userRoll.addRemoveRolesViewModel.Add(new AddRemoveRolesViewModel
                {
                    RollId = role.Id,
                    RollName = role.Name,
                    IsSelected = temp
                });
            }

            return View(userRoll);
        }
        [HttpPost]
        public async Task<IActionResult> AddRemoveRoles(UserRollViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            IdentityResult result = new IdentityResult();
            bool bFlag = false;
            if (ModelState.IsValid)
            {
                for (int i = 0; i < model.addRemoveRolesViewModel.Count; i++)
                {
                    if (model.addRemoveRolesViewModel[i].IsSelected && !await _userManager.IsInRoleAsync(user, model.addRemoveRolesViewModel[i].RollName))
                    {
                        result = await _userManager.AddToRoleAsync(user, model.addRemoveRolesViewModel[i].RollName);
                        bFlag = true;
                    }
                    else if (!model.addRemoveRolesViewModel[i].IsSelected && await _userManager.IsInRoleAsync(user, model.addRemoveRolesViewModel[i].RollName))
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, model.addRemoveRolesViewModel[i].RollName);
                        bFlag = true;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (bFlag)
                {
                    return RedirectToAction(nameof(ViewUsers));
                }
            }
            return View(result);
        }
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
        //public IActionResult ViewAllEmpolyee()
        //{
        //    return View();
        //}
    }
}
