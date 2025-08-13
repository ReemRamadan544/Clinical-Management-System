using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using universty_dental_clinical.DTO.Doctor;
using universty_dental_clinical.Models;
using universty_dental_clinical.Models.UniversityDentalClinic.Models;

namespace universty_dental_clinical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDBContext _context;

        public DoctorController(AppDBContext db, IMapper mapper)
        {
            _context = db;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var alldoctors = _context.Doctors.ToList();

            var doctorDtos = _mapper.Map<List<GetDoctor>>(alldoctors);

            return Ok(doctorDtos);
        }

        [HttpGet("GetDoctor/{id}")]
        public IActionResult Get(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(D => D.Id == id);
            if (doctor != null)
            {
                var getDoctor = new GetDoctor
                {
                    Id = doctor.Id,
                    Name = doctor.Name,
                    UniversityID = doctor.UniversityID,
                    UniversityEmail = doctor.UniversityEmail,
                    PhoneNumber = doctor.PhoneNumber,
                    password = doctor.Password,
                    CreationDate = doctor.CreationDate,
                };

                return Ok(getDoctor);
            }
            else
            {
                return NotFound($"doctor with ID {id} not found.");
            }
        }
        [HttpPost]
        public IActionResult Post([FromForm] CreatDoctor doctor)
        {
            var newAD = _mapper.Map<Doctor>(doctor);
            newAD.Role = "Doctor";
            _context.Doctors.Add(newAD);
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedAD = _context.Doctors.FirstOrDefault(c => c.Id == id);
            if (deletedAD != null)
            {
                _context.Doctors.Remove(deletedAD);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound($"{id} Not Found in Doctors ");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] UpdatedDoctor admin)
        {
            var EditedDoctor = _context.Doctors.FirstOrDefault(p => p.Id == id);

            if (EditedDoctor == null)
            {
                return NotFound("Doctor not found ");
            }

            EditedDoctor.UniversityEmail = admin.UniversityEmail;
            EditedDoctor.PhoneNumber = admin.PhoneNumber;
            EditedDoctor.Password = admin.password;
            _context.SaveChanges();
            return Ok();

        }
    }
}

