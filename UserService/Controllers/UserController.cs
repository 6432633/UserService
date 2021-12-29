using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MiNET.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UserService.Data;
using UserService.DTO;
using UserService.Models;

namespace UserService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        [HttpGet("all")]
        public ActionResult <IEnumerable<UserReadDTO>> GetAllUsers()
        {
                return Ok(_mapper.Map<IEnumerable<UserReadDTO>>(_userRepository.GetUsers()) == null 
                       ? NotFound("No users exist in db") 
                       : Ok(_mapper.Map <IEnumerable < UserReadDTO >> (_userRepository.GetUsers())));
        }
        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> GetUser(string id)
        {
            if (_userRepository.GetUserById(id) != null)
            {
                return Ok(_mapper.Map<UserReadDTO>(_userRepository.GetUserById(id)));
            }
            else return NotFound();
        }
        [HttpPost("create")]
        public ActionResult<UserReadDTO> CreateUser(UserCreateDTO user)
        {    
            var userModel = _mapper.Map<User>(user);
            userModel.CreatedAt = DateTime.UtcNow;
            _userRepository.CreateUser(userModel);
            _userRepository.SaveChanges();
            var userReadDto = _mapper.Map<UserReadDTO>(userModel);

            return CreatedAtRoute(nameof(GetUser),new { Id = userReadDto.Id }, userReadDto);
        }
        [HttpPut("{id}/update")]
        public ActionResult UpdateUser(string id, UserUpdateDTo userUpdateDTo)
        {
            var userFromRepo = _userRepository.GetUserById(id);
            if(userFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(userUpdateDTo, userFromRepo);
            _userRepository.UpdateUser(userFromRepo);
            _userRepository.SaveChanges();
            return NoContent();
        }
        [HttpPatch("{id}/partialUpdate")]
        public ActionResult PatchUser(string id,JsonPatchDocument<UserUpdateDTo> patchUser)
        {
            var userFromRepo = _userRepository.GetUserById(id);
            if(userFromRepo == null)
            {
                return NotFound();
            }
            var userPatch =_mapper.Map<UserUpdateDTo>(userFromRepo);
            patchUser.ApplyTo(userPatch, ModelState);
            if (!TryValidateModel(userPatch))
            {
                return ValidationProblem(ModelState);
                               
            }
            _mapper.Map(userPatch, userFromRepo);
            _userRepository.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}/delete")]
        public ActionResult DeleteUser(string id)
        {
            var userFromRepo = _userRepository.GetUserById(id);
            if (userFromRepo == null)
            {
                return NotFound();
            }
            _userRepository.DeleteUser(userFromRepo);
            _userRepository.SaveChanges();
            return NoContent();
        }
    }
}
