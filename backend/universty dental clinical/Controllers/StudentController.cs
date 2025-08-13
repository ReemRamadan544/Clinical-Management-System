using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using universty_dental_clinical.DTO.Doctor;
using universty_dental_clinical.Models.UniversityDentalClinic.Models;
using universty_dental_clinical.Models;
using universty_dental_clinical.DTO.Student;
using OfficeOpenXml;
using universty_dental_clinical.Services;

namespace universty_dental_clinical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDBContext _context;
        private readonly ExcelService _excelService;

        public StudentController(AppDBContext db, IMapper mapper)
        {
            _context = db;
            _mapper = mapper;
            _excelService = new ExcelService();
        }
        [HttpGet]
        public IActionResult Get(string? searchString)
        {
            IEnumerable<Student> allstudents = new List<Student>();
            if(searchString == null)
            {
                allstudents = _context.Students.ToList();
            } else
            {
                allstudents = _context.Students.ToList().Where(s => s.Name.ToLower().Contains(searchString.ToLower()));
            }

            return Ok(allstudents);
        }

        [HttpGet("GetStudent/{id}")]
        public IActionResult Get(int id)
        {
            var student = _context.Students.FirstOrDefault(D => D.Id == id);
            if (student != null)
            {
                //var getDoctor = new GetDoctor
                //{
                //    Id = doctor.Id,
                //    Name = doctor.Name,
                //    UniversityID = doctor.UniversityID,
                //    UniversityEmail = doctor.UniversityEmail,
                //    PhoneNumber = doctor.PhoneNumber,
                //    password = doctor.Password,
                //    Specialty = doctor.Specialty,
                //    CreationDate = doctor.CreationDate,
                //};

                return Ok(student);
            }
            else
            {
                return NotFound($"student with ID {id} not found.");
            }
        }
        [HttpPost]
        public IActionResult Post([FromForm] CreateStudent student)
        {
            var newAD = _mapper.Map<Student>(student);
            newAD.Role = "Student";
            newAD.ContactInfo = "Not Set";
            newAD.Gender = "Not Set";
            newAD.UniversityEmail = "Not Set";
            _context.Students.Add(newAD);
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedAD = _context.Students.FirstOrDefault(c => c.Id == id);
            if (deletedAD != null)
            {
                _context.Students.Remove(deletedAD);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound($"{id} Not Found in students ");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] UpdateStudent student)
        {
            var EditedStudent = _context.Students.FirstOrDefault(p => p.Id == id);

            if (EditedStudent == null)
            {
                return NotFound("Student not found ");
            }

            EditedStudent.UniversityEmail = student.UniversityEmail;
            EditedStudent.ContactInfo = student.ContactInfo;
            EditedStudent.Password = student.Password;
            _context.SaveChanges();
            return Ok();

        }

        

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            List<Student> students;
            try
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    stream.Position = 0;
                    students = _excelService.ImportStudentsFromExcel(stream);
                }

                _context.Students.AddRange(students);
                _context.SaveChanges();
                var resultFile = _excelService.ExportStudentsToExcel(students);
                var fileName = "StudentsPasword.xlsx";
            var exportFile = File(resultFile, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

                return exportFile;
        }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
    }
}
    }
}
