using DevLifeApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevLifeApi.Services
{
    public class StoryService : IStoryService
    {
        private readonly IMongoCollection<Story> _stories;

        public StoryService(DbStartup database)
        {
            _stories = database.GetMongo().GetCollection<Story>("Stories");
        }

        public List<Story> Get()
        {
            var stories = _stories.Find(story => true);
            if (stories.ToList().Count > 0)
            {
                return stories.SortByDescending(story => story.CreateAt).ToList();
            }
            else return stories.ToList();

        }

        public Story Get(string id) =>
            _stories.Find<Story>(story => story.Id == id).FirstOrDefault();

        public Story Create(Story story)
        {
            _stories.InsertOne(story);
            return story;
        }

        public void Update(string id, Story storyIn)
        {
            Story oldStory = this.Get(id);
            storyIn.CreateAt = oldStory.CreateAt;
            storyIn.UpdatedOn = DateTime.Now;
            _stories.ReplaceOne(story => story.Id == id, storyIn);
        }

        public void AddVote(Vote vote)
        {
            var storyIn = _stories.Find<Story>(story => story.Id == vote.StoryId).FirstOrDefault();
            if (storyIn.Vote == null)
            {
                storyIn.Vote = new List<Vote>();
            }
            storyIn.Vote.Add(vote);
            Update(storyIn.Id, storyIn);
        }
        public void Remove(Story storyIn) =>
            _stories.DeleteOne(story => story.Id == storyIn.Id);


        public void Remove(string id) =>
            _stories.DeleteOne(story => story.Id == id);

    }
}
