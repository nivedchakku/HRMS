using HRMS.Entity.Models;
using HRMS.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using NToastNotify;
using NuGet.Protocol.Core.Types;

namespace HRMS.Controllers
{
    [Authorize(Roles = ("HR,Admin"))]
    public class HRController : Controller
    {
        private readonly IToastNotification _toastService;
        private readonly IAdminRepository repository;
        public HRController(IToastNotification toastService, IAdminRepository repository)
        {
            this.repository = repository;
            _toastService = toastService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LeaveRequests()
        {
            return View(repository.PendingLeaveHistory());
        }
        public IActionResult AllLeave()
        {
            return View(repository.LeaveHistory());
        }
        public IActionResult UpdateLeaveCancel(int leaveapplyid)
        {
            repository.LeaveStatusUpdate(leaveapplyid, "Cancelled");
            return RedirectToAction("LeaveRequests");
        }
        public IActionResult UpdateLeaveApprove(int leaveapplyid)
        {
            repository.LeaveStatusUpdate(leaveapplyid, "Approved");
            return RedirectToAction("LeaveRequests");
        }
        //Asign and manage trainings
        public IActionResult TrainingDetails()
        {
            var data = repository.GetAllTraining();
            return View(data.Where(x => x.status == "Active").ToList());
        }
        public IActionResult TrainingEmployees(int trainingid)
        {
            return View(repository.GetEmpInTraining(trainingid));
        }
        [HttpGet]
        public IActionResult AddEmpTraining(int trainingid)
        {
            TrainingAllocation trainingAllocation = new TrainingAllocation();
            trainingAllocation.trainingid = trainingid;
            ViewBag.emp = repository.ViewAllEmpolyee();
            return View(trainingAllocation);
        }
        [HttpPost]
        public IActionResult AddEmpTraining(TrainingAllocation trainingAllocation)
        {
            trainingAllocation.date = DateTime.Now;
            if (ModelState.IsValid)
            {
                repository.CreateTrainingAllocation(trainingAllocation);
                _toastService.AddSuccessToastMessage("Employee Added to training!");
                return RedirectToAction("TrainingDetails");
            }
            _toastService.AddErrorToastMessage("Error Occurred. Cound Not Add!");
            return RedirectToAction("TrainingDetails");
        }
        public IActionResult UpdateTrainingAllocation(int trainingallocationid)
        {
            repository.UpdateTrainingAllocationStatus(trainingallocationid);
            _toastService.AddSuccessToastMessage("Status Updated!");
            return RedirectToAction("TrainingDetails");
        }
        public IActionResult RemoveTrainingAllocation(int trainingallocationid)
        {
            repository.RemoveTrainingAllocation(trainingallocationid);
            _toastService.AddSuccessToastMessage("User Removed!");
            return RedirectToAction("TrainingDetails");
        }

        //Asign and manage Projects
        public IActionResult ProjectDetails()
        {
            var data = repository.GetAllProject();
            return View(data.Where(x => x.status == "ongoing").ToList());
        }
        public IActionResult ProjectEmployees(int projectid)
        {
            return View(repository.GetEmpInProject(projectid));
        }
        public IActionResult AddEmpProject(int projectid)
        {
            ProjectAllocation projectAllocation = new ProjectAllocation();
            projectAllocation.projectid = projectid;
            ViewBag.emp = repository.ViewAllEmpolyee();
            return View(projectAllocation);
        }
        [HttpPost]
        public IActionResult AddEmpProject(ProjectAllocation projectAllocation)
        {
            projectAllocation.allocationdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var temp = repository.GetEmpInProject(projectAllocation.projectid);
                if(temp.Where(x => x.employeeid == projectAllocation.employeeid).Count()> 0)
                {
                    _toastService.AddErrorToastMessage("Employee is already added to Project!");
                    return RedirectToAction("ProjectDetails");
                }
                repository.CreateProjectAllocation(projectAllocation);
                _toastService.AddSuccessToastMessage("Employee Added to Project!");
                return RedirectToAction("ProjectDetails");
            }
            _toastService.AddErrorToastMessage("Error Occurred. Cound Not Add!");
            return RedirectToAction("ProjectDetails");
        }
        public IActionResult UpdateProjectAllocation(int allocationid)
        {
            repository.UpdateProjectAllocationStatus(allocationid);
            _toastService.AddSuccessToastMessage("Status Updated!");
            return RedirectToAction("ProjectDetails");
        }


    }
}
