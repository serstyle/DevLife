using DevLifeApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevLifeApi.Services
{
    public class VoteService
    {
        private readonly IMongoCollection<Vote> _votes;

        public VoteService(IDevLifeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _votes = database.GetCollection<Vote>("Votes");
        }

        public List<Vote> Get() =>
            _votes.Find(vote => true).ToList();

        public Vote Get(string id) =>
            _votes.Find<Vote>(vote => vote.Id == id).FirstOrDefault();
        public List<Vote> GetByStoryId(Story story) =>
            _votes.Find<Vote>(vote => vote.StoryId == story.Id).ToList();

        public Vote Create(Vote vote)
        {
            _votes.InsertOne(vote);
            
            return vote;
        }

        public void Update(string id, Vote voteIn) =>
            _votes.ReplaceOne(vote => vote.Id == id, voteIn);

        public void Remove(Vote voteIn) =>
            _votes.DeleteOne(vote => vote.Id == voteIn.Id);


        public void Remove(string id) =>
            _votes.DeleteOne(vote => vote.Id == id);
    }
}
