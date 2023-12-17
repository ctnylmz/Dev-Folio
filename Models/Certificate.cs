using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_Folio.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public string ThumbnailUrl { get; set; }
        [NotMapped]
        public IFormFile? Thumbnail {  get; set; }
    }
}
