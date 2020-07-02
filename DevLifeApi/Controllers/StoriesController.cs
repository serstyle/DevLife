using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevLifeApi.Models;
using DevLifeApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;

namespace DevLifeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly IStoryService _storyService;

        public StoriesController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        // GET: api/Stories
        [HttpGet]
        public ActionResult<IEnumerable<Story>> Get()
        {
            return _storyService.Get();
        }

        // GET: api/Stories/5
        [HttpGet("{id}", Name = "GetStory")]
        public ActionResult<Story> Get(string id)
        {
            var story = _storyService.Get(id);
            if (story == null)
            {
                return NotFound();
            }
            return story;
        }

        // POST: api/Stories
        [HttpPost]
        public ActionResult<Story> Create(Story story)
        {
            _storyService.Create(story);

            return CreatedAtRoute("GetStory", new { id = story.Id.ToString() }, story);

        }

        // PUT: api/Stories/5
        [HttpPut("{id}")]
        public IActionResult Update(string id, Story storyIn)
        {
            var story = _storyService.Get(id);

            if (story == null)
            {
                return NotFound();
            }

            _storyService.Update(id, storyIn);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var story = _storyService.Get(id);
            if (story == null)
            {
                return NotFound();
            }
            _storyService.Remove(story.Id);
            return NoContent();
        }
    }
}
