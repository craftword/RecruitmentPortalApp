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
        
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;
        public ApplicationController(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        // POST: api/Application
        [HttpPost]
        [Authorize(Roles = "Applicant")]
        [ProducesResponseType(201, Type = typeof(ApplicationsModel))]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public IActionResult PostApplication([FromBody] ApplicationsModel application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_applicationRepository.CreateApplication(application))
            {
                ModelState.AddModelError("", $"Something went wrong saving the job " +
                                            $"{application.Job}");
                return StatusCode(500, ModelState);
            }

            return Ok(new { applicationCreated = true });
        }

        // GET: api/Applications
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ApplicationsDto>))]

        public IActionResult GetAllApplications()
        {
            var apps = _applicationRepository.GetApplication();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_mapper.Map<ICollection<ApplicationsModel>, ICollection<ApplicationsDto>>(apps));

        }

        // GET: api/application/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Applicant")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ApplicationsDto))]
        public IActionResult GetJob([FromRoute] int id)
        {
            if (!_applicationRepository.ApplicationExists(id))
                return NotFound();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _applicationRepository.GetApplication(id);

            if (result == null)
            {
                return NotFound();
            }


            return Ok(_mapper.Map<ApplicationsModel, ApplicationsDto>(result));
        }

        // ALL SCORES OF A GIVEN USER AT A PARTICULAR APPLICATION
        [HttpGet("{id}/scores")]
        [Authorize(Roles = "Admin,Applicant")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult GetAllScores([FromRoute] int id)
        {
            if (!_applicationRepository.ApplicationExists(id))
                return NotFound();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _applicationRepository.GetApplicationScoreboard(id);

            if (result == null)
            {
                return NotFound();
            }


            return Ok(result);
        }

        // ALL RESPONSE OF A GIVEN USER AT A PARTICULAR APPLICATION
        [HttpGet("{id}/reponses")]
        [Authorize(Roles = "Admin,Applicant")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult GetAllResponses([FromRoute] int id)
        {
            if (!_applicationRepository.ApplicationExists(id))
                return NotFound();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _applicationRepository.GetApplicationResponses(id);

            if (result == null)
            {
                return NotFound();
            }


            return Ok(result);
        }

        // POST: api/Application/Score
        [HttpPost("score")]
        [Authorize(Roles = "Admin,Applicant")]
        [ProducesResponseType(201, Type = typeof(ScoreBoardsModel))]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public IActionResult PostScore([FromBody] ScoreBoardsModel score)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_applicationRepository.AddScoreBoard(score))
            {
                ModelState.AddModelError("", $"Something went wrong saving the score " +
                                            $"{score.Id}");
                return StatusCode(500, ModelState);
            }

            return Ok(new { questionCreated = true });
        }

        // POST: api/Application/Response
        [HttpPost("reponse")]
        [Authorize(Roles = "Admin,Applicant")]
        [ProducesResponseType(201, Type = typeof(ApplicantResponsesModel))]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public IActionResult PostResponse([FromBody] ApplicantResponsesModel response)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_applicationRepository.AddApplicantResponse(response))
            {
                ModelState.AddModelError("", $"Something went wrong saving the response " +
                                            $"{response.Id}");
                return StatusCode(500, ModelState);
            }

            return Ok(new { responseCreated = true });
        }
    }
}




