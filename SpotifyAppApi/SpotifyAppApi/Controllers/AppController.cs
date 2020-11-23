using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SpotifyAppApi.Data;
using SpotifyAppApi.Dtos;
using SpotifyAppApi.Models;

namespace SpotifyAppApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly ISpotifyAppApiRepository _repository;
        private readonly IMapper _mapper;

        public AppController(ISpotifyAppApiRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Get a single user
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var user = _repository.GetUserById(id);

            if (user != null)
            {
                return Ok(_mapper.Map<UserReadDto>(user));
            }

            return NotFound();
        }

        // Register a user
        [HttpPost]
        public ActionResult<UserReadDto> Register([FromBody] UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);
            _repository.Register(userModel);
            _repository.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            return Ok(userReadDto);
        }

        // Update a user
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            var userModelFromRepo = _repository.GetUserById(id);

            if (userModelFromRepo is null)
            {
                return NotFound();
            }

            _mapper.Map(userUpdateDto, userModelFromRepo);
            _repository.UpdateUser(userModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
