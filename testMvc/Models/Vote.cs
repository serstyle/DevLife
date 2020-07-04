using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevLifeMvc.Models
{
    public class Vote
    {
        public string id { get; set; }
        public string storyId { get; set; }
        public int upDown { get; set; }
    }
}
