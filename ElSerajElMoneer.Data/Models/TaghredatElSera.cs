using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElSerajElMoneer.Data.Models
{
    public class TaghredatElSera
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Duration { get; set; }

        public string Description { get; set; }

        public string DownloadUrl { get; set; }

        public string WatchUrl { get; set; }

        public int NumberOfDownloads { get; set; }

        public int NumberOfWatches { get; set; }
    }
}
