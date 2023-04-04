using HRMS.Entity.Models;
using HRMS.Entity.ViewModel;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Services.Repository
{
    public interface IAdminRepository
    {

        public List<Department> GetAllDept();
        public Department GetDept(int id);
        public void CreateDept(Department dept);
        public void EditDept(Department dept);
        public void DeleteDept(int id);

        public List<Position> GetAllPosition();
        public Position GetPosition(int id);
        public void CreatePosition(Position pos);
        public void EditPosition(Position pos);
        public void DeletePosition(int id);

        public List<Salary> GetAllSalary();
        public Salary GetSalary(int id);
        public void CreateSalary(Salary sal);
        public void EditSalary(Salary sal);
        public void DeleteSalary(int id);

        public List<Project> GetAllProject();
        public Project GetProject(int id);
        public void CreateProject(Project proj);
        public void EditProject(Project proj);
        public void DeleteProject(int id);

        public List<Leave> GetAllLeave();
        public Leave GetLeave(int id);
        public void CreateLeave(Leave leave);
        public void EditLeave(Leave leave);
        public void DeleteLeave(int id);


        public List<Training> GetAllTraining();
        public Training GetTraining(int id);
        public void CreateTraining(Training training);
        public void EditTraining(Training training);
        public void DeleteTraining(int id);

        public void CreateEmployee(Employee employee);
        public List<EmployeeViewModel> ViewAllEmpolyee();
        public EmployeeViewModel GetEmpolyee(string id);
        public void UpdateEmpolyee(Employee emp);


        //To Apply Leave
        public void ApplyLeave(LeaveApp leaveapply);

        // To get Leave Histery of a perticular employee
        public List<LeaveApp> EmpLeaveHistory(string employeeid);

        // To get Leave Histery of a All employee
        public List<LeaveApp> LeaveHistory();

        // To get Leave Histery of a All employee
        public List<LeaveApp> PendingLeaveHistory();

        //To get count of taken leave of an employee for particular leave category
        public int EmpLeaveDays(string employeeid, int leaveid);
        public void LeaveStatusUpdate(int leaveapplyid, string status);


        //Training Allocation

        public void CreateTrainingAllocation(TrainingAllocation allocation);
        public List<TrainingAllocation> GetEmpInTraining(int trainingid);

        public void UpdateTrainingAllocationStatus(int trainingallocationid);
        public void RemoveTrainingAllocation(int trainingallocationid);


        //Leave Allocation
        public void CreateProjectAllocation(ProjectAllocation allocation);
        public List<ProjectAllocation> GetEmpInProject(int projectid);

        public void UpdateProjectAllocationStatus(int projectallocationid);


        public List<ProjectAllocation> GetProjectOfEmp(string employeeid);

        public List<TrainingAllocation> GetTrainingOfEmp(string employeeid);



        //Attandance

        public Attandance GetAttandance(string employeeid, DateTime date);
        public List<Attandance> GetAllAttandance(string employeeid);

        public void CheckIn(string employeeid);
        public void CheckOut(string employeeid);




    }
}
