using dotnetcoreplusangular5Template.Models;
using dotnetcoreplusangular5Template.Repository.DepartmentRepo;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace dotnetcoreplusangular5Template.Controllers
{
    [Route(baseUrl)]
    public class DepartmentController : Controller
    {
        #region Private Members

        private readonly IDepartmentRepository _departmentRepository;
        public const string baseUrl = "api/department";

        #endregion

        #region Constructor

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        #endregion

        #region public API(s)

        #region getDepartmentById

        /**
       * @api {get} api/department/:id
       * @apiVersion 1.0.0
       * @apiName GetDepartmentById
       * @apiGroup Department
       * @apiParam {int} id:UniquekeyofDepartment 
       * HTTP/1.1 200 OK 
       * {
       *  "id": 1,
       *  "depatmentName": "depatment_name",
       *  "employee": null
       * }
       * @apiError UserNotFound department id not found.
       * @apiErrorExample {json} Error-Response:
       * HTTP/1.1 404 Not Found
       * {
       *   "error": "Department Not Found"
       * }
       */

        /// <summary>
        /// Method to get Department by id
        /// </summary>
        /// <param name="id">Id to get Department</param>
        /// <returns>Department object</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var Department = await _departmentRepository.GetDepartmentAsnync(id);
            if (Department == null)
            {
                return NotFound();
            }
            return Ok();
        }

        #endregion

        #region Get All Department


        /// <summary>
        /// Method to Get all Department
        /// </summary>
        /// <returns>Department object</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllDepartment()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var department = await _departmentRepository.GetAllDepartmentAsync();
            return Ok(department);
        }

        #endregion


        /// <summary>
        /// Method to add Department
        /// </summary>
        /// <param name="department">Department object</param>
        /// <returns>Department object</returns>
        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _departmentRepository.AddDepartmentAsync(department);
            return Ok(department);
        }

        /// <summary>
        /// Method to update Department
        /// </summary>
        /// <param name="id">Id to update Department</param>
        /// <param name="department">Department object</param>
        /// <returns>department object</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var departmentToUpdate = await _departmentRepository.GetDepartmentAsnync(id);
            if (departmentToUpdate == null)
            {
                return NotFound();
            }
            departmentToUpdate.DepatmentName = department.DepatmentName;
            await _departmentRepository.UpdateDepartmentAsync(departmentToUpdate);
            return Ok();
        }

        /// <summary>
        /// Method to delete Delete Department
        /// </summary>
        /// <param name="id"></param>
        /// <returns>204 if success</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var departmentToDelete = await _departmentRepository.GetDepartmentAsnync(id);
            if (departmentToDelete == null)
            {
                return NotFound();
            }
            await _departmentRepository.DeleteDepartmentAsync(departmentToDelete);
            return NoContent();
        }

        #endregion
    }
}
