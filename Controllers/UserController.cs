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
        private readonly IProfileRepository _profileRepository;
        private readonly IStaffDocsRepository _staffRepository;


        public UserController(UserManager<UserModel> userManager, IMapper mapper, 
            ApplicationDBContext applicationDbContext, IProfileRepository profileRepository, IStaffDocsRepository staffRepository)
        {
            _userManager = userManager;            
            _mapper = mapper;
            _ApplicationDBContext = applicationDbContext;
            _profileRepository = profileRepository;
            _staffRepository = staffRepository;

        }

        //========= Users ==============        
        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin, Onboarding, Staff")]
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
        [Authorize(Roles = "Admin, Onboarding, Staff")]
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
        [Authorize(Roles = "Admin, Onboarding, Staff")]
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
        [Authorize(Roles = "Admin, Onboarding, Staff")]
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
                         .Where(b => b.Id == id).ToList();

            if (result == null)
            {
                return NotFound();
            }


            return Ok(_mapper.Map<List<UserModel>, List<UserDocsDto>>(result));
        }

        //========= Users Profiles ==============  

        // POST: api/user/Profile
        [HttpPost("profile")]
        [Authorize(Roles = "Admin, Onboarding, Staff")]
        [ProducesResponseType(201, Type = typeof(ProfilesModel))]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public IActionResult PostProfile([FromBody] ProfilesModel Model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_profileRepository.CreateProfile(Model))
            {
                ModelState.AddModelError("", $"Something went wrong saving the job " +
                                            $"{Model.Id}");
                return StatusCode(500, ModelState);
            }

            return Ok(new { userProfileAdded = true });
        }
        //========= Users Documents ==============  

        // POST: api/user/Documents
        [HttpPost("document")]
        [Authorize(Roles = "Admin, Onboarding, Staff")]
        [ProducesResponseType(201, Type = typeof(StaffDocsModel))]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public IActionResult PostDocument([FromBody] StaffDocsModel Model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_staffRepository.CreateStaffDocs(Model))
            {
                ModelState.AddModelError("", $"Something went wrong saving the job " +
                                            $"{Model.Id}");
                return StatusCode(500, ModelState);
            }

            return Ok(new { userDocumentAdded = true });
        }


    }
}
