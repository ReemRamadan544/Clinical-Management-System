using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using universty_dental_clinical.DTO.User;
using universty_dental_clinical.Models.UniversityDentalClinic.Models;
using universty_dental_clinical.Models;
using Microsoft.EntityFrameworkCore;

namespace universty_dental_clinical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDBContext _context;

        public UserController(AppDBContext db, IMapper mapper)
        {
            _context = db;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var allpatients = _context.users.ToList();

            var patientDtos = _mapper.Map<List<GetUser>>(allpatients);

            return Ok(patientDtos);
        }

        [HttpGet("GetPatient/{id}")]
        public IActionResult Get(int id)
        {
            var user = _context.users.FirstOrDefault(D => D.Id == id);
            if (user != null)
            {
                var getPatient = new GetUser
                {
                    Id = user.Id,
                    Name = user.Name,
                    UniversityID = user.UniversityID,
                    UniversityEmail = user.UniversityEmail,
                    ContactInfo = user.ContactInfo,
                    Gender = user.Gender,
                    password = user.Password,
                    Role = user.Role,
                    StudentId = (int)user.StudentId,
                    CreationDate = user.CreationDate,
                    MedicalHistory = user.MedicalHistory,
                    StudentName = user.StudentName,
                    Diagnose = user.Diagnose,
                    Status = user.Status,
                    DentalHistory = user.DentalHistory,
                    Complaint = user.Complaint,
                    Age = user.Age,
                    TreatmentPlan = user.TreatmentPlan,
                    Procedure = user.Procedure,
                };

                return Ok(getPatient);
            }
            else
            {
                return NotFound($"User with ID {id} not found.");
            }
        }
        [HttpPost]
        public IActionResult Post([FromForm] CreateUser user)
        {
            var newAD = _mapper.Map<User>(user);
            newAD.Role = "Patient";
            newAD.Password = "NOTSET";
            if (newAD.UniversityEmail == null) newAD.UniversityEmail = "";
            if (newAD.StudentId != null || newAD.StudentId != 0)
            {
                var student = _context.Students.FirstOrDefault(u => u.Id == newAD.StudentId);
                if(student != null)
                {
                    if (student.PatientCount == null) student.PatientCount = 0;
                    student.PatientCount += 1;
                    newAD.StudentName = student.Name;
                }
            }
            _context.users.Add(newAD);
            _context.SaveChanges();
            return Ok(newAD.Id);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedAD = _context.users.FirstOrDefault(c => c.Id == id);
            if (deletedAD != null)
            {
                _context.users.Remove(deletedAD);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound($"{id} Not Found in Doctors ");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] UpdateUser user)
        {
            var EditedPatient = _context.users.FirstOrDefault(p => p.Id == id);

            if (EditedPatient == null)
            {
                return NotFound("Patient not found ");
            }
            if (user.UniversityEmail == null)
            {
                EditedPatient.UniversityEmail = "";
            }
            else
            { EditedPatient.UniversityEmail = user.UniversityEmail;
            }
            EditedPatient.ContactInfo = user.ContactInfo;
            EditedPatient.Password = "NOTSET";
            EditedPatient.UpdationDate = DateTime.Now.ToString();
            EditedPatient.MedicalHistory=user.MedicalHistory;
            EditedPatient.DentalHistory = user.DentalHistory;
            EditedPatient.Diagnose = user.Diagnose;
            EditedPatient.Age = user.Age;
            EditedPatient.Complaint = user.Complaint;
            EditedPatient.TreatmentPlan = user.TreatmentPlan;
            EditedPatient.Procedure = user.Procedure;

            _context.SaveChanges();
            return Ok();

        }

        [HttpGet("GetPatientByStudentId/{studentId}")]
        public IActionResult GetPatientByStudentId(int studentId)
        {
            var patient = _context.users.ToList().Where(D => D.StudentId == studentId);
            if (patient != null)
            {
                return Ok(patient);
            }
            else
            {
                return NotFound($"student with ID {studentId} not found.");
            }
        }
    }
}
