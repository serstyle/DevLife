using System.Collections.Generic;
using System.Threading.Tasks;
using testMvc.Models;

namespace testMvc.Services
{
    public interface IStoryService
    {
        bool GetStoriesError { get; }

        Task Edit(string id, Story storyIn);
        Task<IEnumerable<IStory>> Get();
        Task<IStory> Get(string id);
        Task Create(Story storyIn);
    }
}