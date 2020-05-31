using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueJSAspNetCoreWeb.Models
{
    public class Pipeline
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PipelineId { get; set; }
        public List<User> Users{ get; set; }
        public List<Project> Projects { get; set; }
        public TimeSpan TotalTime { get; set; }
    }
}
