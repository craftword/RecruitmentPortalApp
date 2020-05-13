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
    public class StageController : ControllerBase
    {
        private readonly IStagesRepository _stageRepository;
        private readonly IMapper _mapper;
        public StageController(IStagesRepository stageRepository, IMapper mapper)
        {
            _stageRepository = stageRepository;
            _mapper = mapper;
        }

        // GET: api/Stage
        [HttpGet]
        [Authorize(Roles = "Admin,Applicant")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StageDto>))]

        public IActionResult GetStages()
        {
            var stages = _stageRepository.GetStages();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_mapper.Map<ICollection<StagesModel>, ICollection<StageDto>>(stages));

        }

        // GET: api/Stage/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Applicant")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(StageDto))]
        public IActionResult GetSatge([FromRoute] int id)
        {
            if (!_stageRepository.StageExists(id))
                return NotFound();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _stageRepository.GetStage(id);

            if (result == null)
            {
                return NotFound();
            }


            return Ok(_mapper.Map<StagesModel, StageDto>(result));
        }


        // POST: api/Stage
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(201, Type = typeof(StagesModel))]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public IActionResult PostSatge([FromBody] StagesModel Model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_stageRepository.CreateStages(Model))
            {
                ModelState.AddModelError("", $"Something went wrong saving the job " +
                                            $"{Model.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("GetJob", new { id = Model.Id }, Model);
        }


        // PUT: api/Stage/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public IActionResult PutStage([FromRoute] int id, [FromBody] StagesModel Model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Model.Id)
            {
                return BadRequest();
            }

            if (!_stageRepository.UpdateStages(Model))
            {
                ModelState.AddModelError("", $"Something went wrong updating the Product " +
                                            $"{Model.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        // DELETE: api/Stage/5
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


            var result = _stageRepository.GetStage(id);
            if (result == null)
            {
                return NotFound();
            }

            _stageRepository.DeleteStages(result);


            return Ok(_mapper.Map<StagesModel, StageDto>(result));
        }

        // GET: api/Stage/5/questions
        [HttpGet("{id}/questions")]
        [Authorize(Roles = "Admin,Applicant")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(StagesModel))]
        public IActionResult GetSatgeQuestions([FromRoute] int id)
        {
            if (!_stageRepository.StageExists(id))
                return NotFound();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _stageRepository.GetStageQuestions(id);

            if (result == null)
            {
                return NotFound();
            }


            return Ok(result);
        }
    }
}
