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
        public async Task<IActionResult> GetData()
        {
            return Ok(await _employee.GetEmployee());
        }
    }
}
