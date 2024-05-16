using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Explore:BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string Title { get; set; } = null!;
        
        [StringLength(10)]
        public string Subtitle { get; set; } = null!;
        [StringLength(30)]
        public string Description { get; set; } = null!;
        public string? ImgUrl { get; set; } = null!;
        [NotMapped]
        public IFormFile PhotoFile { get; set; } = null!;
    }
}
