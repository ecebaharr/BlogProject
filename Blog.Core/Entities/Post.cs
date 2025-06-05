namespace Blog.Core.Entities
{
    public class Post
    {
        public string Id { get; set; }                         // Primary Key
        public string Title { get; set; }                   // Başlık
        public string Content { get; set; }                 // İçerik
        public string? ImageUrl { get; set; }               // Opsiyonel: Görsel yolu
        public DateTime CreatedDate { get; set; } = DateTime.Now;  // Otomatik zaman
        public bool IsPublished { get; set; } = true;       // Yayınlandı mı?

        // İlişkili alanlar
        public int CategoryId { get; set; }                 // Foreign Key
        public Category Category { get; set; }
    }
}
