
using dotnetcoreplusangular5Template.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetcoreplusangular5Template.Repository.DepartmentRepo
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Method to add Department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        Task AddDepartmentAsync(Department department);

        /// <summary>
        /// Method to update Department
        /// </summary>
        /// <param name="department">Department object</param>
        /// <returns></returns>
        Task UpdateDepartmentAsync(Department department);

        /// <summary>
        /// Method to delete Department
        /// </summary>
        /// <param name="department">Department object</param>
        /// <returns></returns>
        Task DeleteDepartmentAsync(Department department);

        /// <summary>
        /// Method to get Department by id
        /// </summary>
        /// <param name="id">id to fetch Department</param>
        /// <returns>Department object</returns>
        Task<Department> GetDepartmentAsnync(int id);

        /// <summary>
        /// Method to Get all Department
        /// </summary>
        /// <returns>List of Deparments</returns>
        Task<List<Department>> GetAllDepartmentAsync();
    }
}
