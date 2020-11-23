using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SpotifyAppApi.Data;
using SpotifyAppApi.Dtos;
using SpotifyAppApi.Models;

namespace SpotifyAppApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISpotifyAppApiRepository _repository;
        private readonly IMapper _mapper;

        public AuthController(ISpotifyAppApiRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            User user = _repository.Authorize(username, password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, null);

                return claimsIdentity;
            }

            //if there's no such user
            return null;

        }

        [HttpPost("get-token")]
        public ActionResult GetToken([FromBody] UserReadDto credentials)
        {
            var identity = GetIdentity(credentials.Username, credentials.Password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password" });
            }

            var now = DateTime.UtcNow;
            // create a jwt-token
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Ok(response);
        }
    }
}
