using Application.Services.Auth.Commands;
using Application.Services.Auth.Dto;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Infrastructure.Services
{
    public class AuthService:IAuthService
    {
        private readonly UserManager<CustomUserIdentity> _userManager;
        private readonly SignInManager<CustomUserIdentity> _signInManager;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<CustomUserIdentity> userManager, SignInManager<CustomUserIdentity> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public async Task<UserDto> LoginAsync(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null) throw new UnAuthorizedException("Invalid Login");
            
            // Uncomment password validation
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: true);
            if (result.IsNotAllowed) throw new UnAuthorizedException("Account not confirmed yet");
            if (result.IsLockedOut) throw new UnAuthorizedException("Account is locked.");
            if (!result.Succeeded) throw new UnAuthorizedException("Invalid Login");
            
            var response = new UserDto()
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email!,
                Token = await GenerateTokenAsync(user),
            };
            return response;
        }

        public async Task<UserDto> RegisterAsync(RegisterDto model)
        {
            var user = new CustomUserIdentity()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user,model.Password);
            if(!result.Succeeded)throw new ValidationException() { Errors = result.Errors.Select(E=>E.Description) };
            var response = new UserDto()
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email!,
                Token = await GenerateTokenAsync(user),
            };
            return response;

        }

        private async Task<string> GenerateTokenAsync(CustomUserIdentity user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var rolesAsClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

            var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("TenantId", user.TenantId.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        }
            .Union(userClaims)
            .Union(rolesAsClaims);

            var secretKey = _configuration["JwtSettings:SecretKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: authClaims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}