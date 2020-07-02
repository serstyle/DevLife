using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevLifeApi.Models;
using DevLifeApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevLifeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly VoteService _voteService;
        private readonly IStoryService _storyService;
        public VotesController(VoteService voteService, IStoryService storyService)
        {
            _voteService = voteService;
            _storyService = storyService;
        }

        // GET: api/Stories
        [HttpGet]
        public ActionResult<IEnumerable<Vote>> Get()
        {
            return _voteService.Get();
        }

        // GET: api/Stories/5
        [HttpGet("{id}", Name = "GetVote")]
        public ActionResult<Vote> Get(string id)
        {
            var vote = _voteService.Get(id);
            if (vote == null)
            {
                return NotFound();
            }
            return vote;
        }

        // POST: api/Stories
        [HttpPost]
        public ActionResult<Vote> Create(Vote vote)
        {
            _voteService.Create(vote);
            _storyService.AddVote(vote);
            return CreatedAtRoute("GetVote", new { id = vote.Id.ToString() }, vote);

        }

        // PUT: api/Stories/5
        [HttpPut("{id}")]
        public IActionResult Update(string id, Vote voteIn)
        {
            var vote = _voteService.Get(id);

            if (vote == null)
            {
                return NotFound();
            }

            _voteService.Update(id, voteIn);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var vote = _voteService.Get(id);
            if (vote == null)
            {
                return NotFound();
            }
            _voteService.Remove(vote.Id);
            return NoContent();
        }
    }
}