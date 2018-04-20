using dotnetcoreplusangular5Template.Models;
using dotnetcoreplusangular5Template.Repository.EmployeeRepo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace dotnetcoreplusangular5Template.Controllers
{
    [Route(baseUrl)]
    public class EmployeeController : Controller
    {
        #region Private Member(s)

        private readonly IEmployeeRepository _employeeRepository;
        public const string baseUrl = "api/employee";

        #endregion

        #region Constructor(s)

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        #endregion

        #region Public API(s)

        #region Get Employee By Id

        /// <summary>
        /// Method to get Employee by Id
        /// </summary>
        /// <param name="id">Id to fetch Employee details</param>
        /// <returns>Employee object</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            return Ok(await _employeeRepository.GetEmployeeAsync(id));
        }

        #endregion

        #region Get All Employee

        /// <summary>
        /// Method to get all Employee
        /// </summary>
        /// <returns>Employee Object</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            return Ok(await _employeeRepository.GetAllAsync());
        }

        #endregion

        #region Add Employee

        /// <summary>
        /// Method to add Employee
        /// </summary>
        /// <param name="employee">Employee object</param>
        /// <returns>200 if successs</returns>
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _employeeRepository.AddEmployeeAsync(employee);
            return Ok();
        }

        #endregion

        #region Update Employee

        /// <summary>
        /// Method to update Employee
        /// </summary>
        /// <param name="id">Id to fetch Employee details</param>
        /// <param name="employee">Employee object</param>
        /// <returns>Employee object</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var employeeToUpdate = await _employeeRepository.GetEmployeeAsync(id);
                if (employeeToUpdate == null)
                {
                    return NotFound();
                }
                employeeToUpdate.EmployeeName = employee.EmployeeName;
                employee.DepartmentId = employee.DepartmentId;
                await _employeeRepository.UpdateEmployeeAsync(employeeToUpdate);
                return Ok(employeeToUpdate);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        #endregion

        #region Delete Employee

        /// <summary>
        /// Method to Delete Employee
        /// </summary>
        /// <param name="id">Id to delete Employee</param>
        /// <returns>204 if Success</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var employeeToDelete = await _employeeRepository.GetEmployeeAsync(id);
            if (employeeToDelete == null)
            {
                return NotFound();
            }
            await _employeeRepository.DeleteEmployeeAsync(employeeToDelete);
            return NoContent();
        }

        #endregion

        #endregion
    }
}
