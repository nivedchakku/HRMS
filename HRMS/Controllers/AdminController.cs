using HRMS.Entity.Models;
using HRMS.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using NuGet.Protocol.Core.Types;

namespace HRMS.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private IAdminRepository repository;
        private readonly IToastNotification _toastService;

        public AdminController(IAdminRepository repository, IToastNotification toast)
        {
            this.repository = repository;
            _toastService = toast;
        }

        public IActionResult ViewAllDepartment()
        {
            return View(repository.GetAllDept());
        }
        public JsonResult ViewAllDepartmentJson()
        {
            return Json(new { data = repository.GetAllDept() });
        }
        [HttpGet]
        public IActionResult EditDepartment(int id)
        {
            return View(repository.GetDept(id));
        }
        [HttpPost]
        public IActionResult EditDepartment(Department dept)
        {
            if (ModelState.IsValid)
            {
                repository.EditDept(dept);
                _toastService.AddSuccessToastMessage("Successfully Updated");
                return RedirectToAction("ViewAllDepartment");
            }
            _toastService.AddSuccessToastMessage("Error In Updated");
            return RedirectToAction("ViewAllDepartment");
        }
        public IActionResult CreateDepartment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult createDepartment(Department dept)
        {
            if (ModelState.IsValid)
            {
                var temp = repository.GetAllDept();
                if(temp.Where(x => x.deptname == dept.deptname).ToList().Count()!=0)
                {
                    _toastService.AddWarningToastMessage("Department Already Exists!");
                    return RedirectToAction("ViewAllDepartment");
                }
                repository.CreateDept(dept);
                _toastService.AddSuccessToastMessage("Depatment Added Successfully");
                return RedirectToAction("ViewAllDepartment");
            }
            return View(dept);
        }

        public IActionResult DeleteDepartment(int id)
        {
            return View(repository.GetDept(id));
        }
        [HttpPost]
        [ActionName("DeleteDepartment")]
        public IActionResult PostDeleteDepartment(int deptid)
        {
            repository.DeleteDept(deptid);
            return RedirectToAction("ViewAllDepartment");
        }

        //Position Crud
        public IActionResult ViewAllPosition()
        {
            return View(repository.GetAllPosition());
        }
        public JsonResult ViewAllPositionJson()
        {
            return Json(new { data = repository.GetAllPosition() });
        }
        [HttpGet]
        public IActionResult EditPosition(int id)
        {
            return View(repository.GetPosition(id));
        }
        [HttpPost]
        public IActionResult EditPosition(Position pos)
        {
            if (ModelState.IsValid)
            {
                repository.EditPosition(pos);
                _toastService.AddSuccessToastMessage("Successfully Updated");
                return RedirectToAction("ViewAllPosition");
            }
            _toastService.AddSuccessToastMessage("Error In Updated");
            return RedirectToAction("ViewAllPosition");

        }
        public IActionResult CreatePosition()
        {
            return View();
        }
        [HttpPost]
        public IActionResult createPosition(Position pos)
        {
            if (ModelState.IsValid)
            {
                var temp = repository.GetAllPosition();
                if (temp.Where(x => x.positionname == pos.positionname).ToList().Count() != 0)
                {
                    _toastService.AddWarningToastMessage("Position Already Exists!");
                    return RedirectToAction("ViewAllPosition");
                }

                repository.CreatePosition(pos);
                _toastService.AddSuccessToastMessage("Position Added Successfully");
                return RedirectToAction("ViewAllPosition");
            }
            return View(pos);
        }

        public IActionResult DeletePosition(int id)
        {
            return View(repository.GetPosition(id));
        }
        [HttpPost]
        [ActionName("DeletePosition")]
        public IActionResult PostDeletePosition(int positionid)
        {
            repository.DeletePosition(positionid);
            return RedirectToAction("ViewAllPosition");
        }

        //Salary Crud
        public IActionResult ViewAllSalary()
        {
            return View(repository.GetAllSalary());
        }
        public JsonResult ViewAllSalaryJson()
        {
            return Json(new { data = repository.GetAllSalary() });
        }
        [HttpGet]
        public IActionResult EditSalary(int id)
        {
            return View(repository.GetSalary(id));
        }
        [HttpPost]
        public IActionResult EditSalary(Salary sal)
        {
            if (ModelState.IsValid)
            {
                repository.EditSalary(sal);
                _toastService.AddSuccessToastMessage("Successfully Updated");
                return RedirectToAction("ViewAllSalary");
            }
            _toastService.AddSuccessToastMessage("Error In Updated");
            return RedirectToAction("ViewAllSalary");
        }
        public IActionResult CreateSalary()
        {
            return View();
        }
        [HttpPost]
        public IActionResult createSalary(Salary sal)
        {
            if (ModelState.IsValid)
            {
                repository.CreateSalary(sal);
                _toastService.AddSuccessToastMessage("Salary Added Successfully");
                return RedirectToAction("ViewAllSalary");
            }
            return View(sal);
        }

        //Project Curd
        public IActionResult ViewAllProject()
        {
            return View(repository.GetAllProject());
        }
        public JsonResult ViewAllProjectJson()
        {
            return Json(new { data = repository.GetAllProject() });
        }
        [HttpGet]
        public IActionResult EditProject(int id)
        {
            return View(repository.GetProject(id));
        }
        [HttpPost]
        public IActionResult EditProject(Project proj)
        {
            if (ModelState.IsValid)
            {
                repository.EditProject(proj);
                _toastService.AddSuccessToastMessage("Successfully Updated");
                return RedirectToAction("ViewAllProject");
            }
            _toastService.AddSuccessToastMessage("Error In Updated");
            return RedirectToAction("ViewAllProject");
        }
        public IActionResult CreateProject()
        {
            return View();
        }
        [HttpPost]
        public IActionResult createProject(Project proj)
        {
            if (ModelState.IsValid)
            {
                var temp = repository.GetAllProject();
                if (temp.Where(x => x.projectname == proj.projectname).ToList().Count() != 0)
                {
                    _toastService.AddWarningToastMessage("Project Already Exists!");
                    return RedirectToAction("ViewAllProject");
                }
                repository.CreateProject(proj);
                _toastService.AddSuccessToastMessage("Project Added Successfully");
                return RedirectToAction("ViewAllProject");
            }
            _toastService.AddSuccessToastMessage("Error Creation");
            return RedirectToAction("ViewAllProject");
        }

        //Leave Crud

        public IActionResult ViewAllLeave()
        {
            return View(repository.GetAllLeave());
        }
        public JsonResult ViewAllLeaveJson()
        {
            return Json(new { data = repository.GetAllLeave() });
        }
        [HttpGet]
        public IActionResult EditLeave(int id)
        {
            return View(repository.GetLeave(id));
        }
        [HttpPost]
        public IActionResult EditLeave(Leave leave)
        {
            if (ModelState.IsValid)
            {
                repository.EditLeave(leave);
                _toastService.AddSuccessToastMessage("Successfully Updated");
                return RedirectToAction("ViewAllLeave");
            }
            _toastService.AddErrorToastMessage("Error In Updated");
            return RedirectToAction("ViewAllLeave");
        }
        public IActionResult CreateLeave()
        {
            return View();
        }
        [HttpPost]
        public IActionResult createLeave(Leave leave)
        {
            if (ModelState.IsValid)
            {
                repository.CreateLeave(leave);
                _toastService.AddSuccessToastMessage("Leave Added Successfully");
                return RedirectToAction("ViewAllLeave");
            }
            _toastService.AddErrorToastMessage("Error In Creation");
            return RedirectToAction("ViewAllLeave");
        }


        //Training curd

        public IActionResult ViewAllTraining()
        {
            return View(repository.GetAllTraining());
        }
        public JsonResult ViewAllTrainingJson()
        {
            return Json(new { data = repository.GetAllTraining() });
        }
        [HttpGet]
        public IActionResult EditTraining(int id)
        {
            return View(repository.GetTraining(id));
        }
        [HttpPost]
        public IActionResult EditTraining(Training training)
        {
            if (ModelState.IsValid)
            {
                repository.EditTraining(training);
                _toastService.AddSuccessToastMessage("Successfully Updated");
                return RedirectToAction("ViewAllTraining");
            }
            _toastService.AddErrorToastMessage("Error In Updated");
            return RedirectToAction("ViewAllTraining");
        }
        public IActionResult CreateTraining()
        {
            return View();
        }
        [HttpPost]
        public IActionResult createTraining(Training training)
        {
            if (ModelState.IsValid)
            {
                var temp = repository.GetAllTraining();
                if (temp.Where(x => x.trainingname == training.trainingname).ToList().Count() != 0)
                {
                    _toastService.AddWarningToastMessage("Training Already Exists!");
                    return RedirectToAction("ViewAllTraining");
                }
                repository.CreateTraining(training);
                _toastService.AddSuccessToastMessage("Training Added Successfully");
                return RedirectToAction("ViewAllTraining");
            }
            _toastService.AddErrorToastMessage("Error In Creation");
            return RedirectToAction("ViewAllTraining");
        }


    }
}
