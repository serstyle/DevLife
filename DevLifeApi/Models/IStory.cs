using System;
using System.Collections.Generic;

namespace DevLifeApi.Models
{
    public interface IStory
    {
        DateTime CreateAt { get; set; }
        string Id { get; set; }
        string Main { get; set; }
        string Title { get; set; }
        DateTime UpdatedOn { get; set; }
        List<Vote> Vote { get; set; }
    }
}