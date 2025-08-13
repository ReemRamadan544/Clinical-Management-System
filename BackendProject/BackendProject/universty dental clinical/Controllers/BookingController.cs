using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using universty_dental_clinical.DTO.Booking;
using universty_dental_clinical.Models.UniversityDentalClinic.Models;
using universty_dental_clinical.Models;

namespace universty_dental_clinical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDBContext _context;

        public BookingController(AppDBContext db, IMapper mapper)
        {
            _context = db;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var allbookings = _context.Bookings.ToList();
            var bookingDtos = _mapper.Map<List<GetBooking>>(allbookings);

            return Ok(bookingDtos);
        }

        [HttpGet("GetBooking/{id}")]
        public IActionResult Get(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(D => D.Id == id);
            if (booking!= null)
            {
                var getBooking = new GetBooking
                {
                    Id = booking.Id,
                    Time = booking.Time,
                    Status = booking.Status,
                    PatientName = booking.PatientName,
                    StudentName = booking.StudentName,
                    Diagnose = booking.Diagnose,
                    Signature = booking.Signature,
                    StudentId = (int)booking.StudentId,
                };

                return Ok(getBooking);
            }
            else
            {
                return NotFound($"Booking with ID {id} not found.");
            }
        }
        [HttpPost]
        public IActionResult Post([FromForm] CreateBooking booking)
        {
            var newAD = _mapper.Map<Booking>(booking);
            var student = _context.Students.FirstOrDefault(s => s.Id == newAD.StudentId);
            var patient = _context.users.FirstOrDefault(s => s.Id == newAD.UserId);
            if (student != null)
            {
                newAD.StudentName = student.Name;
            }
            newAD.CreationDate = DateTime.Now;
            newAD.Signature = false;
            newAD.Status = "In Progress";
            newAD.PatientName = patient.Name;
            _context.Bookings.Add(newAD);
            _context.SaveChanges();
            return Ok(newAD.Id);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedAD = _context.Bookings.FirstOrDefault(c => c.Id == id);
            if (deletedAD != null)
            {
                _context.Bookings.Remove(deletedAD);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound($"{id} Not Found in Booking ");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] UpdatedBooking booking)
        {
            var EditedBooking = _context.Bookings.FirstOrDefault(p => p.Id == id);

            if (EditedBooking== null)
            {
                return NotFound("booking not found ");
            }

            EditedBooking.Status = booking.Status;
            EditedBooking.Time = booking.Time;
            EditedBooking.PatientName = booking.PatientName;
            _context.SaveChanges();
            return Ok();

        }

        [HttpGet("GetBookingsByStudentId/{studentId}")]
        public IActionResult GetBookingsByStudentId(int studentId)
        {
            var booking = _context.Bookings.ToList().Where(D => D.StudentId == studentId);
            if (booking != null)
            {
                return Ok(booking);
            }
            else
            {
                return NotFound($"student with ID {studentId} not found.");
            }
        }

        [HttpPost("SetBookingStatus/{bookingId}")]
        public IActionResult SetBookingStatus(int bookingId, [FromQuery] bool signature)
        {
            var booking = _context.Bookings.FirstOrDefault(D => D.Id == bookingId);
            var patient = _context.users.FirstOrDefault(P => P.Id == booking.UserId);
            if (signature)
            {
                booking.Status = "Completed";
                patient.Status = "Completed";
                booking.Signature = true;
            } else
            {
                booking.Status = "In Progress";
                patient.Status = "In Progress";
                booking.Signature = false;
            }
            _context.SaveChanges();
            return Ok();
        }

    }
}
