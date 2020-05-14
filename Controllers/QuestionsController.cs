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
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IMapper _mapper;
        public QuestionsController(IQuestionsRepository questionsRepository, IMapper mapper)
        {
            _questionsRepository = questionsRepository;
            _mapper = mapper;
        }

        // GET: api/Questions
        [HttpGet]
        [Authorize(Roles = "Admin,Applicant")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<QuestionsDto>))]

        public IActionResult GetQuestions()
        {
            var questions = _questionsRepository.GetQuestions();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_mapper.Map<ICollection<QuestionsModel>, ICollection<QuestionsDto>>(questions));

        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Applicant")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(QuestionsDto))]
        public IActionResult GetJob([FromRoute] int id)
        {
            if (!_questionsRepository.QuestionsExists(id))
                return NotFound();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _questionsRepository.GetQuestions(id);

            if (result == null)
            {
                return NotFound();
            }


            return Ok(_mapper.Map<QuestionsModel, QuestionsDto>(result));
        }


        // POST: api/Question
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(201, Type = typeof(QuestionsModel))]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public IActionResult PostJob([FromBody] QuestionsModel Model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_questionsRepository.CreateQuestions(Model))
            {
                ModelState.AddModelError("", $"Something went wrong saving the job " +
                                            $"{Model.Id}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("GetJob", new { Jobsid = Model.Id }, Model);
        }


        // PUT: api/Questions/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public IActionResult PutQuestion([FromRoute] int id, [FromBody] QuestionsModel Model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Model.Id)
            {
                return BadRequest();
            }

            if (!_questionsRepository.UpdateQuestions(Model))
            {
                ModelState.AddModelError("", $"Something went wrong updating the Product " +
                                            $"{Model.Id}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        // DELETE: api/Question/5
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


            var result = _questionsRepository.GetQuestions(id);
            if (result == null)
            {
                return NotFound();
            }

            _questionsRepository.DeleteQuestions(result);


            return Ok(_mapper.Map<QuestionsModel, QuestionsDto>(result));
        }

            
    }
}
