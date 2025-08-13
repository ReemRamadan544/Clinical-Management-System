using AuthenticationPlugin;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using universty_dental_clinical.DTO.Doctor;
using universty_dental_clinical.Models;
using universty_dental_clinical.Models.UniversityDentalClinic.Models;

namespace universty_dental_clinical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAuthController : ControllerBase
    {
        private AppDBContext _context;
        private AuthService _authService;
        IConfiguration _configuration;
        IMapper _mapper;
        public DoctorAuthController(AppDBContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _authService = new AuthService(configuration);
        }
        #region doctor register 
        [HttpPost("doctorRegister")]
        public IActionResult Register([FromForm] CreatDoctor doctor)
        {
            var doctorExist = _context.Doctors.SingleOrDefault(d => d.UniversityEmail == doctor.UniversityEmail);
            if (doctorExist != null)
            {
                return BadRequest("User already exists");
            }

            var newdoc = _mapper.Map<Doctor>(doctor);
            newdoc.Password = SecurePasswordHasherHelper.Hash(newdoc.Password);
            _context.Doctors.Add(newdoc);
            _context.SaveChanges();
            return Ok($"Added successfully: {newdoc.Name}");
        }

        [HttpPost("login")]
        public IActionResult Logindoc([FromForm] Logindoc doctor)
        {
            var Accountdoc = _context.Doctors.FirstOrDefault(u => u.UniversityEmail == doctor.UniversityEmail);
            if (Accountdoc == null) return StatusCode(StatusCodes.Status404NotFound);
            var hashedPassword = Accountdoc.Password;
            //if (!SecurePasswordHasherHelper.Verify(doctor.Password, hashedPassword)) return Unauthorized();
            if(hashedPassword != doctor.Password) return Unauthorized();
            var claims = new[]
            {
              new Claim(JwtRegisteredClaimNames.Sub, Accountdoc.Name),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
              new Claim(JwtRegisteredClaimNames.Email, Accountdoc.UniversityEmail ),
              new Claim(ClaimTypes.Name, Accountdoc.Name),
            };

            var token = _authService.GenerateAccessToken(claims);
            return new ObjectResult(new
            {
                access_token = token.AccessToken,
                token_type = token.TokenType,
                user_Id = Accountdoc.Id,
                role = Accountdoc.Role,

            });
        }
        #endregion
    }
}
