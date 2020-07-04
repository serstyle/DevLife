using System;

namespace DevLifeMvc.Models
{
    public interface IStory
    {
        string id { get; set; }
        string main { get; set; }
        string numberVote { get; }
        string title { get; set; }
        DateTime updatedOn { get; set; }
        Vote[] vote { get; set; }
    }
}