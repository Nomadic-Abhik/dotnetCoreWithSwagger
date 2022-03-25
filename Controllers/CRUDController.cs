using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProject1._0.Model;
using CoreProject1._0.IRepository;

namespace CoreProject1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
      
        private readonly IEmployee _employee;
        public CRUDController(IEmployee context)
        {
            // this._context = context;
            this._employee = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeData()
        {
            return Ok(await _employee.GetEmployee());
        }
        [HttpGet]
        [Route("/api/getEmployeebyInput")]
        public async Task<IActionResult> GetEmployeebyInput(string searchData)
        {
            return Ok(await _employee.GetEmployeebyInput(searchData));
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee model)
        {
            return Ok(await _employee.AddEmployee(model));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee model)
        {
            return Ok(await _employee.UpdateEmployee(model));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            return Ok(await _employee.DeleteEmployee(id));
        }
    }
}
