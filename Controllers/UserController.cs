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
using RecruitmentPortalApp.Dtos;
using RecruitmentPortalApp.Services;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentPortalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<UserModel> _userManager;        
        private readonly IMapper _mapper;
        private readonly ApplicationDBContext _ApplicationDBContext;


        public UserController(UserManager<UserModel> userManager, IMapper mapper, ApplicationDBContext applicationDbContext)
        {
            _userManager = userManager;            
            _mapper = mapper;
            _ApplicationDBContext = applicationDbContext;

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
        public async Task<IActionResult> GetUser( string id)
        {
            if (await _userManager.FindByIdAsync(id) == null)
                return NotFound();

            var User = await _userManager.FindByIdAsync(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userDto = _mapper.Map<UserModel, UserDto>(User);
            return Ok(userDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteUser(UserModel user)
        {
            if (await _userManager.FindByEmailAsync(user.Email) == null)
                return NotFound();

            var User = await _userManager.DeleteAsync(user);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            return Ok(User);
        }
        // ALL APPLICATIONS OF A GIVEN USER 
        [HttpGet("{id}/application")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(JobApplicantsDto))]
        public async Task<IActionResult> GetAllApplication([FromRoute] string id)
        {
            if (await _userManager.FindByIdAsync(id) == null)
                return NotFound();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _ApplicationDBContext.NewUsers
                         .Where(m => m.Id == id)
                         .SelectMany(m => m.Applications.Select(mc => mc.Job)).FirstOrDefault();

            if (result == null)
            {
                return NotFound();
            }


            return Ok(_mapper.Map<JobsModel, JobApplicantsDto>(result));
        }

        // ALL DOCUMENTS OF A GIVEN USER 
        [HttpGet("{id}/documents")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(JobApplicantsDto))]
        public async Task<IActionResult> GetAllDocuments([FromRoute] string id)
        {
            if (await _userManager.FindByIdAsync(id) == null)
                return NotFound();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _ApplicationDBContext.NewUsers
                         .Include(c => c.StaffDocuments)
                         .Where(b => b.Id == id).FirstOrDefault();

            if (result == null)
            {
                return NotFound();
            }


            return Ok(_mapper.Map<UserModel, UserDto>(result));
        }
    }
}
