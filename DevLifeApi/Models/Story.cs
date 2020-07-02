using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace DevLifeApi.Models
{
    public class Story : IStory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Main { get; set; }
        [BsonDateTimeOptions]
        // attribute to gain control on datetime serialization
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        [BsonDateTimeOptions]
        // attribute to gain control on datetime serialization
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public List<Vote> Vote { get; set; }
    }
}
