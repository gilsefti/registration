using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registration.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        IRegistrationRepo RegistrationRepo;
        public RegistrationController(IRegistrationRepo registrationRepo) {
            this.RegistrationRepo = registrationRepo;
        
        }
        [HttpPost("CreateRegistration")]
        public IActionResult CreateRegistration([FromQuery]string studentId) {
            this.RegistrationRepo.CreateRegistration(studentId);
            return Ok();
        }

        [HttpPost("AddCourse")]
        public IActionResult AddCourse([FromQuery] string studentId, [FromQuery] string courseId)
        {
            this.RegistrationRepo.AddCourse(studentId, courseId);
            return Ok();
        }
        [HttpPost("ClearAllCourses")]
        public IActionResult ClearAllCourses([FromQuery] string studentId)
        {
            this.RegistrationRepo.ClearAllCourses(studentId);
            return Ok();
        }

        [HttpPost("Complete")]
        public IActionResult Complete([FromQuery] string studentId)
        {
            this.RegistrationRepo.Complete(studentId);
            return Ok();
        }

        [HttpPost("Pay")]
        public IActionResult Pay([FromQuery] string studentId)
        {
            this.RegistrationRepo.Pay(studentId);
            return Ok();
        }
        [HttpPost("Cancel")]
        public IActionResult Cancel([FromQuery] string studentId)
        {
            this.RegistrationRepo.Cancel(studentId);
            return Ok();
        }
    }
}
