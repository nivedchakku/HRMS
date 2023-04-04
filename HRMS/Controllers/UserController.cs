using HRMS.Entity.Models;
using HRMS.Entity.ViewModel;
using HRMS.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;

namespace HRMS.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IAdminRepository repository;
        private readonly IToastNotification _toastService;


        public UserController(IAdminRepository repository, IToastNotification toast)
        {
            this.repository = repository;
            _toastService = toast;

        }
        public IActionResult Index()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var temp = repository.GetEmpolyee(id);
            HttpContext.Session.SetString("fullName", temp.firstname);
            HttpContext.Session.SetString("position", temp.positionname);
            HttpContext.Session.SetString("image", temp.image);

            // Leave status
            var leavelist = repository.GetAllLeave();
            var history = repository.EmpLeaveHistory(id);
            if (history.Count() == 0)
            {
                ViewBag.data = (from l in leavelist
                                select (new LeaveData { name = l.leavename, days = l.days })).ToList();
            }
            else
            {
                var leavedays = (from h in history
                                 where h.status == "Pending" || h.status == "Approved"
                                 group h by h.leaveid into grp
                                 select new { leaveid = grp.Key, days = grp.Sum(x => x.leavedays) }).ToList();
                //ViewBag.data = (from l in leavelist
                //                from ld in leavedays
                //                select (new LeaveData { name = l.leavename, days = (ld.leaveid == l.leaveid) ? l.days - ld.days : l.days })).ToList();

                ViewBag.data = (from l in leavelist
                                join ld in leavedays on l.leaveid equals ld.leaveid
                                into grp
                                from g in grp.DefaultIfEmpty()
                                select (new LeaveData { name = l.leavename, days = g != null ? l.days - g.days : l.days })).ToList();
            }


            return View();
        }
        public IActionResult ViewLeave(string? id)
        {
            if(id == null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            var leavelist = repository.GetAllLeave();
            var history = repository.EmpLeaveHistory(id);
            if (history.Count() == 0)
            {
                ViewBag.data = (from l in leavelist
                                select (new LeaveData { name = l.leavename, days = l.days })).ToList();
            }
            else
            {
                var leavedays = (from h in history
                                 where h.status == "Pending" || h.status == "Approved"
                                 group h by h.leaveid into grp
                                 select new { leaveid = grp.Key, days = grp.Sum(x => x.leavedays) }).ToList();
                //ViewBag.data = (from l in leavelist
                //                from ld in leavedays
                //                select (new LeaveData { name = l.leavename, days = (ld.leaveid == l.leaveid) ? l.days - ld.days : l.days })).ToList();

                ViewBag.data = (from l in leavelist
                                join ld in leavedays on l.leaveid equals ld.leaveid
                                into grp
                                from g in grp.DefaultIfEmpty()
                                select (new LeaveData { name = l.leavename, days = g != null ? l.days - g.days : l.days })).ToList();
            }

            return View(repository.EmpLeaveHistory(id).OrderBy(x =>x.dateapplied));
        }
        [HttpGet]
        public IActionResult LeaveApply()
        {
            ViewBag.Leave = repository.GetAllLeave();
            return View();
        }
        [HttpPost]
        public IActionResult LeaveApply(LeaveApp leaveapplication)
        {
            leaveapplication.dateapplied = DateTime.Now;
            if(ModelState.IsValid)
            {
                var leavelist = repository.GetAllLeave();
                var days = leavelist.Where(x => x.leaveid == leaveapplication.leaveid).Select(y => y.days).FirstOrDefault();
                var history = repository.EmpLeaveDays(leaveapplication.employeeid, leaveapplication.leaveid);
                if ((days - history - leaveapplication.leavedays) < 0)
                {
                    _toastService.AddWarningToastMessage("You Exceeded the maximum leave days!");
                    return RedirectToAction("ViewLeave");
                }
                else
                {
                    repository.ApplyLeave(leaveapplication);
                    _toastService.AddSuccessToastMessage("Leave Application Submitted Succesfully!");
                    return  RedirectToAction("ViewLeave");
                }
            }
            _toastService.AddWarningToastMessage("Could not Apply. Some error occured!");
            return RedirectToAction("ViewLeave");
        }
        public IActionResult UpdateLeaveCancel(int leaveapplyid)
        {
            repository.LeaveStatusUpdate(leaveapplyid, "Cancelled");
            return RedirectToAction("ViewLeave");
        }
        public IActionResult ViewProjects(string? id)
        {
            if (id == null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return View(repository.GetProjectOfEmp(id));
        }
        public IActionResult ViewTrainings(string? id)
        {
            if (id == null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return View(repository.GetTrainingOfEmp(id));
        }
        public IActionResult Attandance(string employeeid)
        {
            if(employeeid == null)
            {
                employeeid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            ViewBag.temp = repository.GetAttandance(employeeid, DateTime.Now);
            var temp = repository.GetAllAttandance(employeeid);
            return View(temp);
        }
        public IActionResult CheckIn()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            repository.CheckIn(id);
            return RedirectToAction("Attandance");
        }
        public IActionResult CheckOut()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            repository.CheckOut(id);
            return RedirectToAction("Attandance");
        }
    }
}
