using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using universty_dental_clinical.DTO.Admin;
using universty_dental_clinical.Models;

namespace universty_dental_clinical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
     public class AdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDBContext _context;

        public AdminController(AppDBContext db, IMapper mapper)
        {
            _context = db;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get ()
        {
           var alladmins = _context.Admins.ToList();

            var adminDtos = _mapper.Map<List<GetAdmin>>(alladmins);

            return Ok(adminDtos);
        }

        [HttpGet("GetAdmin/{id}")]

        public IActionResult Get(int id)
        {
            var admin = _context.Admins.FirstOrDefault(D => D.Id == id);
            if (admin != null)
            {
                var getAdmin = new GetAdmin
                {
                    Id = admin.Id,
                    Name = admin.Name,
                    UniversityID = admin.UniversityID,
                    UniversityEmail = admin.UniversityEmail,
                    PhoneNumber = admin.PhoneNumber,
                    Password=admin.Password,
                };

                return Ok(getAdmin);
            }
            else
            {
                return NotFound($"Admin with ID {id} not found.");
            }
        }
        [HttpPost]
        public IActionResult Post([FromForm] CreateAdmin admin)
        {
            var newAD = _mapper.Map<Admin>(admin);
            newAD.Role = "Admin";
            _context.Admins.Add(newAD);
            _context.SaveChanges();
            return Ok($"Added Successfully {newAD.Name}");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedAD = _context.Admins.FirstOrDefault(c => c.Id == id);
            if (deletedAD != null)
            {
                _context.Admins.Remove(deletedAD);
                _context.SaveChanges();
                return Ok("Deleted Successfully");
            }
            else
            {
                return NotFound($"{id} Not Found in Admins ");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] UpdatedAdmin admin)
        {
           var EditedAdmin=_context.Admins.FirstOrDefault(p=> p.Id == id); 
            
            if(EditedAdmin == null)
            {
                return NotFound("Admin not found ");
            }

            EditedAdmin.UniversityEmail = admin.UniversityEmail;
            EditedAdmin.PhoneNumber = admin.PhoneNumber;
            EditedAdmin.Password = admin.Password;
            _context.SaveChanges(); 
            return Ok();

        }
    }
}
