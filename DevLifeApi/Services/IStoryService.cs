using DevLifeApi.Models;
using System.Collections.Generic;

namespace DevLifeApi.Services
{
    public interface IStoryService
    {
        void AddVote(Vote vote);
        Story Create(Story story);
        List<Story> Get();
        Story Get(string id);
        void Remove(Story storyIn);
        void Remove(string id);
        void Update(string id, Story storyIn);
    }
}