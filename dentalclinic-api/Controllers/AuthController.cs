﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using dentalclinic.Common.Model.Domain;
using dentalclinic_api.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Cryptography;
using dentalclinic_api.Models.Common;
using dentalclinic.Common.Services;

namespace dentalclinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IDentalDBContext _dbContext;
        public AuthController(
           UserManager<ApplicationUser> userManager,
           RoleManager<IdentityRole> roleManager,
           IConfiguration configuration, IDentalDBContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _dbContext = dbContext;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login( LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password) && await _userManager.IsInRoleAsync(user, model.UserRole))
            {
                
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = CreateToken(authClaims);
                var refreshToken = GenerateRefreshToken();

                _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

                await _userManager.UpdateAsync(user);

                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = refreshToken,
                    Expiration = token.ValidTo,
                    UserName=user.UserName,
                    UserId=user.Id
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin()
        {
            try
            {

            string username = "Admin";
            string password = "Welcome@123";


            var userExists = await _userManager.FindByNameAsync(username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = username,
                Designation="Admin",
                FirstName="Admin",
                LastName="Admin",
                NationalityId=_dbContext.Nationalities.Where(x => x.NationalityCode == "IN").FirstOrDefault().NationalityId,
                UserTypeId= (int)USERTYPE.Admin
            };
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.Doctor))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Doctor));
            if (!await _roleManager.RoleExistsAsync(UserRoles.Reception))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Reception));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
           
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("getRoles")]
        public async Task<IEnumerable<SelectListModel>> GetRoles()
        {
            return _roleManager.Roles.Select(x=> new SelectListModel { Id=x.Id,Name=x.Name}).ToList();

        }


        [HttpPost]
        [Route("register-users")]
        public async Task<IActionResult> RegisterUsers(ApplicationUser user)
        {
            try
            {

               // string username = "Admin";
                string password = "Welcome@123";

                string username =await GenerateUName(user.FirstName, user.LastName);
                //ApplicationUser user = new()
                //{
                //    SecurityStamp = Guid.NewGuid().ToString(),
                //    UserName = username,
                //    Designation = "Admin",
                //    FirstName = "Admin",
                //    LastName = "Admin",
                //    NationalityId = userDetails.NationalityId,
                //    UserTypeId = (int)USERTYPE.Admin
                //};
                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

                if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await _roleManager.RoleExistsAsync(UserRoles.Doctor))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Doctor));
                if (!await _roleManager.RoleExistsAsync(UserRoles.Reception))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Reception));

                if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.Admin);
                }

                return Ok(new Response { Status = "Success", Message = "User created successfully!" });

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;

        }

        private async Task<string> GenerateUName(string firstname,string lastname)
        {
           
                const string chars = "0123456789";
                int length = 3;
                var random = new Random();
                string uname = firstname+"."+lastname;

                var userExists = await _userManager.FindByNameAsync(uname);
                if (userExists != null)
                {
                    bool exists = true;
                    int repeat = 0;

                    while (exists && repeat < 5)
                    {
                        uname = uname+ Convert.ToString(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
                        var user = await _userManager.FindByNameAsync(uname);
                        if (user != null) { exists = true; }
                        else exists = false;
                        repeat++;
                    }
                }
                
                return uname;
           
        }
    }
}
