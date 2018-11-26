using EF.Core.Interfaces;
using EF.Infrastructure.Connection;
using EF.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Infrastructure.Services
{
    public class EmployeeBusiness
    {
        InterviewEntities context;
        IEmployeeRepository iEmployeeRepository;

        public EmployeeBusiness()
        {
            context = new InterviewEntities();
            iEmployeeRepository = new EmployeeRepository(context);
        }

        /* begin code
         * 
        // Save Employee
        public EmployeeViewModel SaveEmployee(EmployeeViewModel data, string currentUser, string imageName)
        {
            try
            {
                Employee _se = new Employee();
                _se.ID = data.ID;
                _se.EmpNo = data.EmpNo;
                _se.NIC = data.NIC;
                _se.EmployeeImagePath = imageName;
                _se.LastName = data.LastName;
                _se.FirstName = data.FirstName;
                _se.MiddleName = data.MiddleName;
                _se.Mobile = data.Mobile;
                _se.Home = data.Home;
                _se.Email = data.Email;
                _se.PostBox = data.PostBox;
                _se.Street = data.Street;
                _se.City = data.City;
                _se.dob = data.dob;
                var res = iEmployeeRepository.Insert(_se);

                if (res != null)
                {
                    data.ID = res.ID;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }

        // Update Employee
        public EmployeeViewModel UpdateEmployee(EmployeeViewModel data, string currentUser, string imageName)
        {
            try
            {
                Employee _se = new Employee();
                _se.ID = data.ID;
                _se.NIC = data.NIC;
                _se.EmpNo = data.EmpNo;
                _se.EmployeeImagePath = imageName;
                _se.LastName = data.LastName;
                _se.FirstName = data.FirstName;
                _se.MiddleName = data.MiddleName;
                _se.Mobile = data.Mobile;
                _se.Home = data.Home;
                _se.Email = data.Email;
                var res = iEmployeeRepository.Update(_se);

                if (res != null)
                {
                    data.ID = res.ID;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return data;
        }

        // Delete an Employee
        public EmployeeViewModel DeleteEmployee(EmployeeViewModel data)
        {
            try
            {
                Employee _se = new Employee();
                _se.ID = data.ID;
                _se.IsActive = false;
                var res = iEmployeeRepository.UpdateProperty(x => x.ID == data.ID, new System.Collections.Generic.KeyValuePair<string, object>("IsActive", _se.IsActive));


                if (res != null)
                {
                    data.ID = _se.ID;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return data;

        }

        //Get Number of registered Employees
        public int GetNoOfAllRegisteredEmployees()
        {
            return iEmployeeRepository.GetAll().Count;
        }

        //Get an employee details
        public EmployeeViewModel GetAnEmployeeDetails(int empNo)
        {
            var employeeDetails = iEmployeeRepository.GetList(x => x.EmpNo == empNo)
                .Select(y => new EmployeeViewModel
                {
                    ID = y.ID,
                    EmpNo = y.EmpNo,
                    LastName = y.LastName,
                    FirstName = y.FirstName,
                    MiddleName = y.MiddleName,
                    FullName = y.FirstName + ' ' + y.MiddleName + ' ' + y.LastName,
                    EmployeeImagePath = y.EmployeeImagePath,
                    NIC = y.NIC,
                    dob = y.dob,
                    Gender = y.Gender
                }).FirstOrDefault();
            return employeeDetails;
        }

        //Get All employees details
        public IList GetAllEmployeesDetails()
        {
            var employeeDetails = iEmployeeRepository.GetList(x => x.IsActive == true)
                .Select(y => new EmployeeViewModel
                {
                    ID = y.ID,
                    EmpNo = y.EmpNo,
                    NIC = y.NIC,
                    LastName = y.LastName,
                    FirstName = y.FirstName
                }).ToList();
            return employeeDetails;
        }
        */

    }
}
