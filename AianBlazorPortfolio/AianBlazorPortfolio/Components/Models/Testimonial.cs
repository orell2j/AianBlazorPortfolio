using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace AianBlazorPortfolio.Components.Models {

    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Comment { get; set; }
        public DateTime SubmittedOn { get; set; }
        public bool Approved { get; set; }
        public bool Featured { get; set; }
        public double Rating { get; set; }
    }

}