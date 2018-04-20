using dotnetcoreplusangular5Template.Data;
using dotnetcoreplusangular5Template.Models;
using dotnetcoreplusangular5Template.Models.Application_Class;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoreplusangular5Template.Repository.EmployeeRepo
{
    public class EmployeeRepository : IEmployeeRepository
    {
   
            #region Private Member(s)

            private readonly ApplicationDbContext _dbContext;

        #endregion

            #region Constructor(s)

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

            #endregion

            #region Public Method(s)

            public async Task AddEmployeeAsync(Employee employee)
            {
                _dbContext.Employee.Add(employee);
                await _dbContext.SaveChangesAsync();
            }

            public async Task UpdateEmployeeAsync(Employee employee)
            {
                _dbContext.Employee.Update(employee);
                await _dbContext.SaveChangesAsync();
            }

            public async Task DeleteEmployeeAsync(Employee employee)
            {
                _dbContext.Employee.Remove(employee);
                await _dbContext.SaveChangesAsync();
            }

            public async Task<Employee> GetEmployeeAsync(int id)
            {
                return await _dbContext.Employee.FindAsync(id);
            }

            public async Task<List<EmployeeAC>> GetAllAsync()
            {
                var EmployeeList = await (_dbContext.Employee.AsQueryable()).ToListAsync();
                List<EmployeeAC> employees = new List<EmployeeAC>();
                foreach (var employee in EmployeeList)
                {
                    EmployeeAC employeeDetail = new EmployeeAC()
                    {
                        EmployeeId = employee.Id,
                        EmployeeName = employee.EmployeeName,
                        DepartmentName = (await _dbContext.Department.FindAsync(employee.DepartmentId)).DepatmentName
                    };
                    employees.Add(employeeDetail);
                }
                return employees;
            }

            #endregion

        }
    }
