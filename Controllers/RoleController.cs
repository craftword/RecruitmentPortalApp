using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecruitmentPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RecruitmentPortalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class RoleController : ControllerBase
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;


        public RoleController(UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        //========= Roles ==============        
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult ListAllRoles()
        {
            var Roles = _roleManager.Roles;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(Roles);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetRole(string id)
        {
            if (await _roleManager.FindByIdAsync(id) == null)
                return NotFound();

            var role = await _roleManager.FindByIdAsync(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            return Ok(role);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> EditRole(IdentityRole model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            role.Name = model.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)
            {
                return NotFound(result.Errors);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteRole(IdentityRole model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
                return NotFound();
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                return NotFound(result.Errors);
            }

            return Ok(result);
        }

               


        //========= AddUserToRoles ==============

        [Route("AddUserToRole")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AddUsersToRoles(string id, string rolename)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var idResult = await _userManager.AddToRoleAsync(user, rolename);

            if (!idResult.Succeeded)
            {

                return NotFound(idResult.Errors);
            }

            return Ok(idResult);
        }

        //========= AddUserToRoles ==============

        [Route("DeleteUserInRole")]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteUserInRole(string id, string rolename)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var idResult = await _userManager.RemoveFromRoleAsync(user, rolename);

            if (!idResult.Succeeded)
            {

                return NotFound(idResult.Errors);
            }

            return Ok(idResult);
        }
    }
}
