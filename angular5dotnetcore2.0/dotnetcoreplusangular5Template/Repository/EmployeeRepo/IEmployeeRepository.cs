
using dotnetcoreplusangular5Template.Models.Application_Class;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace dotnetcoreplusangular5Template.Repository.EmployeeRepo
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Method to add Employee
        /// </summary>
        /// <param name="employee">Employee object</param>
        /// <returns></returns>
        Task AddEmployeeAsync(Models.Employee employee);

        /// <summary>
        /// Method to update Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task UpdateEmployeeAsync(Models.Employee employee);

        /// <summary>
        /// Method to Delete Employee
        /// </summary>
        /// <param name="employee">Employee object</param>
        /// <returns></returns>
        Task DeleteEmployeeAsync(Models.Employee employee);

        /// <summary>
        /// Method to get Employee by id
        /// </summary>
        /// <param name="id">Id to Get Employee</param>
        /// <returns>Employee object</returns>
        Task<Models.Employee> GetEmployeeAsync(int id);

        /// <summary>
        /// Method ro Get all Employee 
        /// </summary>
        /// <returns>List of Employee</returns>
        Task<List<EmployeeAC>> GetAllAsync();
    }
}
