using HRMS.Entity.Data;
using HRMS.Entity.Models;
using HRMS.Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Services.Repository
{
    
    public class AdminRepository : IAdminRepository
    {
        private ApplicationDbContext context;

        public AdminRepository(ApplicationDbContext context)
        {
            this.context = context;

        }

        public void CreateDept(Department dept)
        {
            context.Department.Add(dept);
            context.SaveChanges();
        }

        public void CreatePosition(Position pos)
        {
            context.Position.Add(pos);
            context.SaveChanges();
        }

        public void CreateSalary(Salary salary)
        {
            context.Salary.Add(salary);
            context.SaveChanges();
        }

        public void DeleteDept(int id)
        {
            var dept = context.Department.Find(id);
            dept.isdeleted=true;
            context.Department.Update(dept);
            context.SaveChanges();
        }

        public void DeletePosition(int id)
        {
            var pos = context.Position.Find(id);
            pos.isdeleted = true;
            context.Position.Update(pos);
            context.SaveChanges();
        }

        public void DeleteSalary(int id)
        {
            var sal = context.Salary.Find(id);
            context.Salary.Remove(sal);
            context.SaveChanges();
        }

        public void EditDept(Department dept)
        {
            context.Department.Update(dept);
            context.SaveChanges();
        }

        public void EditPosition(Position pos)
        {
            context.Position.Update(pos);
            context.SaveChanges();
        }

        public void EditSalary(Salary sal)
        {
            context.Salary.Update(sal);
            context.SaveChanges();
        }

        public List<Department> GetAllDept()
        {
            return context.Department.Where(x => x.isdeleted==false).ToList();
        }

        public List<Position> GetAllPosition()
        {
            return context.Position.Where(x => x.isdeleted == false).ToList();
            
        }

        public List<Salary> GetAllSalary()
        {
            return context.Salary.ToList();

        }

        public Department GetDept(int id)
        {
            return context.Department.Find(id);
        }

        public Position GetPosition(int id)
        {
            return context.Position.Find(id);

        }

        public Salary GetSalary(int id)
        {
            return context.Salary.Find(id);

        }

        //Project
        public void CreateProject(Project proj)
        {
            context.Project.Add(proj);
            context.SaveChanges();
        }

        public void DeleteProject(int id)
        {
            var proj = context.Project.Find(id);
            context.Project.Remove(proj);
            context.SaveChanges();
        }

        public void EditProject(Project proj)
        {
            context.Project.Update(proj);
            context.SaveChanges();
        }

        public List<Project> GetAllProject()
        {
            return context.Project.ToList();
        }

        public Project GetProject(int id)
        {
            return context.Project.Find(id);
        }

        //Leave

        public void CreateLeave(Leave leave)
        {
            context.Leave.Add(leave);
            context.SaveChanges();
        }

        public void DeleteLeave(int id)
        {
            var leave = context.Leave.Find(id);
            context.Leave.Remove(leave);
            context.SaveChanges();
        }

        public void EditLeave(Leave leave)
        {
            context.Leave.Update(leave);
            context.SaveChanges();
        }

        public List<Leave> GetAllLeave()
        {
            return context.Leave.ToList();

        }
        public Leave GetLeave(int id)
        {
            return context.Leave.Find(id);

        }

        //Training
        public List<Training> GetAllTraining()
        {
            return context.Training.ToList();

        }

        public Training GetTraining(int id)
        {
            return context.Training.Find(id);
        }

        public void CreateTraining(Training training)
        {
            context.Training.Add(training);
            context.SaveChanges();

        }

        public void EditTraining(Training training)
        {
            context.Training.Update(training);
            context.SaveChanges();
        }

        public void DeleteTraining(int id)
        {
            var training = context.Training.Find(id);
            context.Training.Remove(training);
            context.SaveChanges();
        }

        public void CreateEmployee(Employee employee)
        {
            context.Employee.Add(employee);
            context.SaveChanges();

        }

        public List<EmployeeViewModel> ViewAllEmpolyee()
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
            try
            {
                employees = (from emp in context.Employee
                                 join dept in context.Department on emp.departmentid equals dept.deptid
                                 join pos in context.Position on emp.positionid equals pos.positionid
                                 join sal in context.Salary on emp.salaryid equals sal.salaryid
                                 select (new EmployeeViewModel
                                 {
                                     employeeid = emp.employeeid,
                                     firstname = emp.firstname,
                                     lastname = emp.lastname,
                                     mobile = emp.mobile,
                                     gender = emp.gender,
                                     email = emp.email,
                                     dob = emp.dob,
                                     address = emp.address,
                                     departmentid = emp.departmentid,
                                     positionid = emp.positionid,
                                     salaryid = emp.salaryid,
                                     isdeleted = emp.isdeleted,
                                     image = emp.image,
                                     date = emp.date,
                                     departmentname = dept.deptname,
                                     positionname = pos.positionname,
                                     salary = new Salary()
                                     {
                                         salaryid = sal.salaryid,
                                         salary = sal.salary,
                                         pf = sal.pf,
                                         specialallowance = sal.specialallowance
                                     }
                                 })).ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return employees;
        }

        public EmployeeViewModel GetEmpolyee(string id)
        {
            EmployeeViewModel employee = new EmployeeViewModel();
            try
            {
                employee = (from emp in context.Employee
                             join dept in context.Department on emp.departmentid equals dept.deptid
                             join pos in context.Position on emp.positionid equals pos.positionid
                             join sal in context.Salary on emp.salaryid equals sal.salaryid
                             where emp.employeeid == id
                             select (new EmployeeViewModel
                             {
                                 employeeid = emp.employeeid,
                                 firstname = emp.firstname,
                                 lastname = emp.lastname,
                                 mobile = emp.mobile,
                                 email = emp.email,
                                 gender = emp.gender,
                                 dob = emp.dob,
                                 address = emp.address,
                                 departmentid = emp.departmentid,
                                 positionid = emp.positionid,
                                 salaryid = emp.salaryid,
                                 isdeleted = emp.isdeleted,
                                 image = emp.image,
                                 date = emp.date,
                                 departmentname = dept.deptname,
                                 positionname = pos.positionname,
                                 salary = new Salary()
                                 {
                                     salaryid = sal.salaryid,
                                     salary = sal.salary,
                                     pf = sal.pf,
                                     specialallowance = sal.specialallowance
                                 }
                             })).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return employee;
        }

        public void UpdateEmpolyee(Employee emp)
        {
            context.Employee.Update(emp);
            context.SaveChanges();
        }

        public void ApplyLeave(LeaveApp leaveapply)
        {
            context.LeaveApp.Add(leaveapply);
            context.SaveChanges();
        }

        public List<LeaveApp> EmpLeaveHistory(string employeeid)
        {     
            var leave = (from la in context.LeaveApp
                       join l in context.Leave on la.leaveid equals l.leaveid 
                       where la.employeeid == employeeid
                       select(new LeaveApp
                       {
                           leaveapplyid = la.leaveapplyid,
                           leaveid = la.leaveid,
                           employeeid = la.employeeid,
                           startdate = la.startdate,
                           enddate = la.enddate,
                           leavedays = la.leavedays,
                           description = la.description,
                           status = la.status,
                           dateapplied = la.dateapplied,
                           leavename= l.leavename,

                       })).ToList();
            return (leave);
        }

        public int EmpLeaveDays(string employeeid, int leaveid)
        {
            var a = (from l in context.LeaveApp 
                     where l.employeeid == employeeid & l.leaveid == leaveid & (l.status == "Pending" || l.status == "Approved")
                     group l by l.employeeid into grp 
                     select new { day = grp.Sum(x => x.leavedays) }).FirstOrDefault();
            if(a == null)
            {
                return 0;
            }
            
                return a.day;
        }

        public void LeaveStatusUpdate(int leaveapplyid, string status)
        {
            var temp = context.LeaveApp.Find(leaveapplyid);
            temp.status = status;
            context.LeaveApp.Update(temp);
            context.SaveChanges();
        }

        public List<LeaveApp> LeaveHistory()
        {
            var leave = (from la in context.LeaveApp
                         join l in context.Leave on la.leaveid equals l.leaveid
                         join e in context.Employee on la.employeeid equals e.employeeid 
                         select (new LeaveApp
                         {
                             leaveapplyid = la.leaveapplyid,
                             leaveid = la.leaveid,
                             employeeid = la.employeeid,
                             startdate = la.startdate,
                             enddate = la.enddate,
                             leavedays = la.leavedays,
                             description = la.description,
                             status = la.status,
                             dateapplied = la.dateapplied,
                             leavename = l.leavename,
                             employeename = e.firstname+' '+e.lastname

                         })).ToList();
            return (leave);
        }

        public List<LeaveApp> PendingLeaveHistory()
        {
            var leave = (from la in context.LeaveApp
                         join l in context.Leave on la.leaveid equals l.leaveid
                         join e in context.Employee on la.employeeid equals e.employeeid
                         where la.status == "Pending"
                         select (new LeaveApp
                         {
                             leaveapplyid = la.leaveapplyid,
                             leaveid = la.leaveid,
                             employeeid = la.employeeid,
                             startdate = la.startdate,
                             enddate = la.enddate,
                             leavedays = la.leavedays,
                             description = la.description,
                             status = la.status,
                             dateapplied = la.dateapplied,
                             leavename = l.leavename,
                             employeename = e.firstname + ' ' + e.lastname

                         })).ToList();
            return (leave);
        }

        public void CreateTrainingAllocation(TrainingAllocation allocation)
        {
            context.TrainingAllocation.Add(allocation);
            context.SaveChanges();
        }


        public List<TrainingAllocation> GetEmpInTraining(int trainingid)
        {
            var training = (from TA in context.TrainingAllocation
                            join T in context.Training on TA.trainingid equals T.trainingid
                            join E in context.Employee on TA.employeeid equals E.employeeid
                            where TA.trainingid == trainingid
                            select (new TrainingAllocation
                            {
                                trainingallocationid = TA.trainingallocationid,
                                trainingid = TA.trainingid,
                                employeeid = TA.employeeid,
                                status = TA.status,
                                date = TA.date,
                                firstname = E.firstname,
                                lastname = E.lastname,
                                training = new Training()
                                {
                                    trainingname = T.trainingname,
                                    description = T.description,
                                    status = T.status
                                }
                            })).ToList();
            return training;
        }

        public void UpdateTrainingAllocationStatus(int trainingallocationid)
        {
            var temp = context.TrainingAllocation.Find(trainingallocationid);
            temp.status = "Completed";
            context.TrainingAllocation.Update(temp);
            context.SaveChanges();
        }

        public void RemoveTrainingAllocation(int trainingallocationid)
        {
            var temp = context.TrainingAllocation.Find(trainingallocationid);
            context.TrainingAllocation.Remove(temp);
            context.SaveChanges();
        }

        public void CreateProjectAllocation(ProjectAllocation allocation)
        {
            context.ProjectAllocation.Add(allocation);
            context.SaveChanges();
        }


        public List<ProjectAllocation> GetEmpInProject(int projectid)
        {
            var temp = (from PA in context.ProjectAllocation
                        join P in context.Project on PA.projectid equals P.projectid
                        join E in context.Employee on PA.employeeid equals E.employeeid
                        where PA.projectid == projectid
                        select (new ProjectAllocation
                        {
                            allocationid = PA.allocationid,
                            projectid = PA.projectid,
                            employeeid = PA.employeeid,
                            status = PA.status,
                            allocationdate = PA.allocationdate,
                            projectname = P.projectname,
                            firstname = E.firstname,
                            lastname = E.lastname
                        })).ToList();
            return temp;
        }

        public void UpdateProjectAllocationStatus(int projectallocationid)
        {
            var temp = context.ProjectAllocation.Find(projectallocationid);
            temp.status = "Completed";
            context.ProjectAllocation.Update(temp);
            context.SaveChanges();
        }

        public List<ProjectAllocation> GetProjectOfEmp(string employeeid)
        {
            var project = (from PA in context.ProjectAllocation
                           join P in context.Project on PA.projectid equals P.projectid
                           join E in context.Employee on PA.employeeid equals E.employeeid
                           where E.employeeid == employeeid
                           select (new ProjectAllocation
                           {
                               allocationid = PA.allocationid,
                               projectid = PA.projectid,
                               employeeid = PA.employeeid,
                               status = PA.status,
                               allocationdate = PA.allocationdate,
                               projectname = P.projectname,
                               firstname = E.firstname,
                               lastname = E.lastname
                           })).ToList(); ;
            return project;
        }

        public List<TrainingAllocation> GetTrainingOfEmp(string employeeid)
        {
            var training = (from TA in context.TrainingAllocation
                            join T in context.Training on TA.trainingid equals T.trainingid
                            join E in context.Employee on TA.employeeid equals E.employeeid
                            where E.employeeid == employeeid
                            select (new TrainingAllocation
                            {
                                trainingallocationid = TA.trainingallocationid,
                                trainingid = TA.trainingid,
                                employeeid = TA.employeeid,
                                status = TA.status,
                                date = TA.date,
                                firstname = E.firstname,
                                lastname = E.lastname,
                                training = new Training()
                                {
                                    trainingname = T.trainingname,
                                    description = T.description,
                                    status = T.status
                                }
                            })).ToList();
            return training;
        }

        public Attandance GetAttandance(string employeeid, DateTime date)
        {
            var date1 = Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}", date));
            return (context.Attandance.Where(x => x.employeeid == employeeid && x.date == date1).FirstOrDefault());
        }

        public void CheckIn(string employeeid)
        {
            var time = TimeOnly.FromDateTime(DateTime.Now);
            Attandance temp = new Attandance()
            {
                employeeid = employeeid,
                date = DateTime.Now,
                timein = Convert.ToString(time)
            };
            context.Attandance.Add(temp);
            context.SaveChanges();
        }

        public void CheckOut(string employeeid)
        {
            var date = Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}", DateTime.Now));
            var temp = context.Attandance.Where(x => x.employeeid == employeeid && x.date == date).FirstOrDefault();
            temp.timeout = Convert.ToString(TimeOnly.FromDateTime(DateTime.Now));
            context.Attandance.Update(temp);
            context.SaveChanges();
        }

        public List<Attandance> GetAllAttandance(string employeeid)
        {
            return (context.Attandance.Where(x => x.employeeid == employeeid).ToList());

        }
    }
}
