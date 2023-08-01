﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TEST.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        public IConfiguration _configuration;

        public SecurityController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // GET: api/<SecurityController>
        [HttpPost]
        public string Get()
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", "sacha"),
                        new Claim("DisplayName", "sacha"),
                        new Claim("UserName", "sacha"),
                        new Claim("Email", "sacha")
                        
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: signIn);

            return "sacha";
        }

        // GET api/<SecurityController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            //return BCrypt.Net.BCrypt.HashPassword(id);
            if (BCrypt.Net.BCrypt.Verify("get", "$2a$11$/ejkmMezYN87vERZSTOePuS6Bry4BZbZTt6akewxLbAoTuteGdpy2"))
                return "verifié avec succes";
            else
                return "erreur de verification";


        }

        // POST api/<SecurityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SecurityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SecurityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
