using dotnetcoreplusangular5Template.Data;
using dotnetcoreplusangular5Template.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoreplusangular5Template.Repository.DepartmentRepo
{
    public class DepartmentRepository : IDepartmentRepository
    {
        #region Private Member(s)

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Constructor

        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       
        #endregion

        #region Public method(s)

        public async Task AddDepartmentAsync(Department department)
        {
            _dbContext.Department.Add(department);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            _dbContext.Department.Update(department);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(Department department)
        {
            _dbContext.Department.Remove(department);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Department> GetDepartmentAsnync(int id)
        {
            return await _dbContext.Department.FindAsync(id);
        }

        public async Task<List<Department>> GetAllDepartmentAsync()
        {
            return await (_dbContext.Department.AsQueryable()).ToListAsync();
        }

        #endregion
    }
}
