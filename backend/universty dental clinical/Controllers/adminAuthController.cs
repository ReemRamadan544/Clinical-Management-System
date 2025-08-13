using AuthenticationPlugin;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using universty_dental_clinical.DTO.Admin;
using universty_dental_clinical.Models;
using universty_dental_clinical.Models.UniversityDentalClinic.Models;

namespace universty_dental_clinical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class adminAuthController : ControllerBase
    {
        private AppDBContext _context;
        private AuthService _authService;
        IConfiguration _configuration;
        IMapper _mapper;

        public adminAuthController(AppDBContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _authService = new AuthService(configuration);
        }
        #region Admin register 
        [HttpPost("AdminRegister")]
        public IActionResult Register([FromForm] CreateAdmin admin)
        {
            var adminExist = _context.Admins.SingleOrDefault(u => u.UniversityEmail == admin.UniversityEmail);
            if (adminExist != null)
            {
                return BadRequest("User already exists");
            }

            var newAdmin = _mapper.Map<Admin>(admin);
            newAdmin.Password = SecurePasswordHasherHelper.Hash(newAdmin.Password);
            _context.Admins.Add(newAdmin);
            _context.SaveChanges();
            return Ok($"Added successfully: {newAdmin.Name}");
        }

        [HttpPost("login")]
        public IActionResult Login([FromForm] Login admin)
        {
            var AccountUser = _context.Admins.FirstOrDefault(u => u.UniversityEmail == admin.UniversityEmail);
            if (AccountUser == null) return StatusCode(StatusCodes.Status404NotFound);
            var hashedPassword = AccountUser.Password;
            if (admin.Password != hashedPassword) return Unauthorized();
            var claims = new[]
            {
              new Claim(JwtRegisteredClaimNames.Sub, AccountUser.Name),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
              new Claim(JwtRegisteredClaimNames.Email, AccountUser.UniversityEmail ),
              new Claim(ClaimTypes.Name, AccountUser.Name),
            };

            var token = _authService.GenerateAccessToken(claims);
            return new ObjectResult(new
            {
                access_token = token.AccessToken,
                role = AccountUser.Role,
                token_type = token.TokenType,
                user_Id = AccountUser.Id,
               

            });
        }
        #endregion
    }
}
