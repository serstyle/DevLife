using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testMvc.Models
{
    public class StoryModel
    {
        public Story[] Stories { get; set; }
    }

    public class Story : IStory
    {
        public string id { get; set; }
        public string title { get; set; }
        public string main { get; set; }
        public DateTime updatedOn { get; set; }
        public Vote[] vote { get; set; }
        public string numberVote
        {
            get
            {
                if (vote == null || vote.Length < 1) return "0";
                return vote.Sum(m => m.upDown).ToString();
            }
        }
    }

}
