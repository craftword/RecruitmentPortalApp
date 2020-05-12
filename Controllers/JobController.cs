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
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;
        public JobController(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        // GET: api/Job
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<JobDto>))]

        public IActionResult GetJobs()
        {
            var jobs = _jobRepository.GetJobs();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_mapper.Map<ICollection<JobsModel>, ICollection<JobDto>>(jobs));

        }

        // GET: api/Job/5
        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(JobDto))]
        public IActionResult GetJob([FromRoute] int id)
        {
            if (!_jobRepository.JobExists(id))
                return NotFound();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _jobRepository.GetJob(id);

            if (result == null)
            {
                return NotFound();
            }


            return Ok(_mapper.Map<JobsModel, JobDto>(result));
        }


        // POST: api/Job
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(201, Type = typeof(JobDto))]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public IActionResult PostJob([FromBody] JobsModel JobModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_jobRepository.CreateJob(JobModel))
            {
                ModelState.AddModelError("", $"Something went wrong saving the job " +
                                            $"{JobModel.Title}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("GetJob", new { id = JobModel.Id }, JobModel);
        }


        // PUT: api/Job/5
        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public IActionResult PutJob([FromRoute] int id, [FromBody] JobsModel JobModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != JobModel.Id)
            {
                return BadRequest();
            }

            if (!_jobRepository.UpdateJob(JobModel))
            {
                ModelState.AddModelError("", $"Something went wrong updating the Product " +
                                            $"{JobModel.Title}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        // DELETE: api/Job/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteJob([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var result = _jobRepository.GetJob(id);
            if (result == null)
            {
                return NotFound();
            }

            _jobRepository.DeleteJob(result);


            return Ok(_mapper.Map<JobsModel, JobDto>(result));
        }

        // GET A PARTICULAR JOB APPLICANTS
        [HttpGet("{id}/applicants")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(JobApplicantsDto))]
        public IActionResult GetAJobApplicants([FromRoute] int id)
        {
            if (!_jobRepository.JobExists(id))
                return NotFound();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _jobRepository.GetJobApplicants(id);

            if (result == null)
            {
                return NotFound();
            }


            return Ok(_mapper.Map<JobsModel, JobApplicantsDto>(result));
        }

        // GET A PARTICULAR JOB STAGES
        [HttpGet("{id}/stages")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(JobApplicantsDto))]
        public IActionResult GetAJobStages([FromRoute] int id)
        {
            if (!_jobRepository.JobExists(id))
                return NotFound();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _jobRepository.GetJobStages(id);

            if (result == null)
            {
                return NotFound();
            }


            return Ok(_mapper.Map<StagesModel, StageDto>(result));
        }

    }
}
