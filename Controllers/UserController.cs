using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecruitmentPortalApp.Models;
//using RecruitmentPortalApp.Dtos;

namespace RecruitmentPortalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<UserModel> _userManager;        
        private readonly IMapper _mapper;


        public UserController(UserManager<UserModel> userManager, IMapper mapper)
        {
            _userManager = userManager;            
            _mapper = mapper;


        }

        //========= Users ==============        
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ICollection<UserDto>))]
        public IActionResult ListAllUser()
        {
            var Users = _userManager.Users;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userDto = _mapper.Map<ICollection<UserModel>, ICollection<UserDto>>(Users.ToList());
            return Ok(userDto);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        public async Task<IActionResult> GetUser([FromRoute] string id)
        {
            if (_userManager.FindByIdAsync(id) == null)
                return NotFound();

            var User = await _userManager.FindByIdAsync(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userDto = _mapper.Map<UserModel, UserDto>(User);
            return Ok(userDto);
        }

    }
}
