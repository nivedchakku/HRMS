using HRMS.Entity.Models;
using HRMS.Entity.ViewModel;
using HRMS.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;

namespace HRMS.Controllers
{
    [Authorize]
    public class ManageEmployeeController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IAdminRepository repository;
        private readonly IToastNotification _toastService;


        public ManageEmployeeController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IAdminRepository repository,
            IToastNotification toast)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.repository = repository;
            _toastService = toast;

        }


        [Authorize(Roles = ("HR,Admin"))]
        public IActionResult ViewAllEmployee(string ? empid, int ? deptid, int ? posid)
        {
            ViewBag.emp = repository.ViewAllEmpolyee();
            ViewBag.dept = repository.GetAllDept();
            ViewBag.pos = repository.GetAllPosition();
            var query = repository.ViewAllEmpolyee().AsQueryable();
            if(empid != null)
            {
                query =query.Where(x => x.employeeid == empid);
            }
            if(deptid != null)
            {
                query = query.Where(x => x.departmentid == deptid);
            }
            if(posid != null)
            {
                query = query.Where(x => x.positionid == posid);
            }
            return View(query.ToList());
        }


        public IActionResult ViewEmployeeDetails(string id)
        {
            if (id == null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return View(repository.GetEmpolyee(id));
        }
        public IActionResult EditEmployeeDetails(string? id)
        {
            if(id == null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            ViewBag.Salary = repository.GetAllSalary();
            ViewBag.Department = repository.GetAllDept();
            ViewBag.Position = repository.GetAllPosition();
            return View(repository.GetEmpolyee(id));
        }
        [HttpPost]
        public IActionResult EditEmployeeDetails(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee()
                {
                    employeeid = model.employeeid,
                    firstname = model.firstname,
                    lastname = model.lastname,
                    mobile = model.mobile,
                    email = model.email,
                    gender = model.gender,
                    dob = model.dob,
                    address = model.address,
                    departmentid = model.departmentid,
                    positionid = model.positionid,
                    salaryid = model.salaryid,
                    isdeleted = model.isdeleted,
                    date = model.date,
                    image = model.image,
                };
                repository.UpdateEmpolyee(emp);
                _toastService.AddSuccessToastMessage("Profile Updated!");
                if (User.IsInRole("Admin") || User.IsInRole("HR"))
                {
                    return RedirectToAction("ViewAllEmployee");
                }
                return RedirectToAction("ViewEmployeeDetails");
            }
            _toastService.AddWarningToastMessage("Error in Update. Something Went Wrong!");
            if (User.IsInRole("Admin") || User.IsInRole("HR"))
            {
                return RedirectToAction("ViewAllEmployee");
            }
            return RedirectToAction("ViewEmployeeDetails");
        }

    }
}
