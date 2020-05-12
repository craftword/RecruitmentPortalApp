using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecruitmentPortalApp.Dtos;
using RecruitmentPortalApp.Models;
using RecruitmentPortalApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentPortalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationDocsController : ControllerBase
    {
        private readonly IOrganizationDocsRepository _orgDocsRepository;
        private readonly IMapper _mapper;
        public OrganizationDocsController(IOrganizationDocsRepository orgDocsRepository, IMapper mapper)
        {
            _orgDocsRepository = orgDocsRepository;
            _mapper = mapper;
        }

        // GET: api/OrganizationDocs
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrganizationDocsModel>))]

        public IActionResult GetQuestions()
        {
            var questions = _orgDocsRepository.GetOrganizationDocs();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(questions);

        }

        // GET: api/OrganizationDocs/5
        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(OrganizationDocsModel))]
        public IActionResult GetJob([FromRoute] int id)
        {
            if (!_orgDocsRepository.OrganizationDocExists(id))
                return NotFound();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _orgDocsRepository.GetOrganizationDoc(id);

            if (result == null)
            {
                return NotFound();
            }


            return Ok(result);
        }


        // POST: api/OrganizationDocs/
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(201, Type = typeof(OrganizationDocsModel))]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public IActionResult PostJob([FromBody] OrganizationDocsModel Model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_orgDocsRepository.CreateOrganizationDocs(Model))
            {
                ModelState.AddModelError("", $"Something went wrong saving the job " +
                                            $"{Model.Id}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("GetJob", new { id = Model.Id }, Model);
        }


        // PUT: api/OrganizationDocs//5
        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public IActionResult PutQuestion([FromRoute] int id, [FromBody] OrganizationDocsModel Model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Model.Id)
            {
                return BadRequest();
            }

            if (!_orgDocsRepository.UpdateOrganizationDocs(Model))
            {
                ModelState.AddModelError("", $"Something went wrong updating the Product " +
                                            $"{Model.Id}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        // DELETE: api/OrganizationDocs/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteJob([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var result = _orgDocsRepository.GetOrganizationDoc(id);
            if (result == null)
            {
                return NotFound();
            }

            _orgDocsRepository.DeleteOrganizationDocs(result);


            return Ok(result);
        }

    }
}
