using AuthenticationPlugin;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using universty_dental_clinical.DTO.User;
using universty_dental_clinical.Models;

namespace universty_dental_clinical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAuthController : ControllerBase
    {
        private AppDBContext _context;
        private AuthService _authService;
        IConfiguration _configuration;
        IMapper _mapper;

        public StudentAuthController(AppDBContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _authService = new AuthService(configuration);
        }

        [HttpPost("login")]
        public IActionResult Loginuse([FromForm] LoginStudent user)
        {
            var AccountUser = _context.Students.FirstOrDefault(u => u.UniversityID == user.UniversityId);
            if (AccountUser == null) return StatusCode(StatusCodes.Status404NotFound);
            var hashedPassword = AccountUser.Password;
            if (user.Password != hashedPassword) return Unauthorized();
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
                token_type = token.TokenType,
                user_Id = AccountUser.Id,
                role = AccountUser.Role,
            });
        }
    }
}