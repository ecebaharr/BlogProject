using System.Text.Json.Serialization;

namespace Blog.Core.Entities
{
    public class Post
    {
        public string? Id { get; set; }  // Mongo otomatik oluşturur

        public string Title { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsPublished { get; set; }
        public int CategoryId { get; set; }

        [JsonIgnore] // Swagger'da görünmesin, istekte zorunlu olmasın
        public Category? Category { get; set; }
    }
}
