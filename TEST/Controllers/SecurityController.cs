using BusinessLogic.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TEST.Static;

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
        [HttpGet("Authentification")]
        public string Authentification()
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTToken:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Roleid","XNDER-RETR"),
                new Claim("idCompagnie","2"),
                new Claim("iduser","USERID0000001"),
            };
            var token = new JwtSecurityToken(_configuration["JWTToken:Issuer"],
                _configuration["JWTToken:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return Crypto.EncodeText(new JwtSecurityTokenHandler().WriteToken(token));

        }
        
        //GET api/<SecurityController>/5
        [HttpGet("Get")]
        [PersonalAuth]
        public string Get()
        {
           return  HttpContext.Request.Headers.Authorization.ToString();
           // //return BCrypt.Net.BCrypt.HashPassword(id);
           // if (BCrypt.Net.BCrypt.Verify("get", "$2a$11$/ejkmMezYN87vERZSTOePuS6Bry4BZbZTt6akewxLbAoTuteGdpy2"))
           //     return "verifié avec succes";
           // else
           //     return "erreur de verification";
        }

        //POST api/<SecurityController>
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

        [HttpPost("Uploadphoto")]
        public async Task<IActionResult> UploadFileWithObject(IFormFile file, [FromBody] UtilisateurSaveDTO yourObject)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            if (yourObject == null)
            {
                return BadRequest("No object provided.");
            }

            // Process the uploaded file
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                byte[] fileBytes = memoryStream.ToArray();
                // Do something with the fileBytes, like saving to disk or processing

                // Now you can also use the 'yourObject' that was sent in the request
                // Perform actions with yourObject

                // Return a success response
                return Ok("File uploaded and object received successfully.");
            }
        }
    }
}
