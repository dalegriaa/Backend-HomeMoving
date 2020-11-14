using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiTechAndSolve.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IDataProcessApplication _dataProcessApplication;
        public HomeController(IDataProcessApplication dataProcessApplication)
        {
            _dataProcessApplication = dataProcessApplication;
        }
        [HttpPost("[action]/{id}/{nameFile}")]
        public IActionResult InsertDataUser([FromRoute] int id,string nameFile)
        {

            IFormFile file = Request.Form.Files[nameFile];
            if (file == null) return BadRequest();
            var response = _dataProcessApplication.
                                InsertDataProcessFile(file,id);

            if (response.IsSuccess) return Ok(response);
            return BadRequest(response.Message);
           

        }

    }
}
