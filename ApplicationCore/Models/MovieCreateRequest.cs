using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    class MovieCreateRequest
    {
        public int Id { get; set; }
        [MaxLength(150, ErrorMessage = "the length is over max"),Required]
        public string Title { get; set; }
        [StringLength(2084, MinimumLength = 0)]
        public string Overview { get; set; }
        [StringLength(2084, MinimumLength = 0)]
        public string Tagline { get; set; }
        [Range(0, 500000000)]
        public double Budget { get; set; }
        [Range(0, 5000000000), RegularExpression(@"^(\d{1,18})(.\d{1})?$",ErrorMessage = "The input is not follow the rule")]
        public double Revenue { get; set; }
        public string ImdbUrl { get; set; }
        public string TmdbUrl { get; set; }
        [Required]
        public string PosterUrl { get; set; }
        [Required]
        public string BackdropUrl { get; set; }
        public string OriginalLanguage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RunTime { get; set; }
        public double Price { get; set; }
        public ICollection<Genre> Genre { get; set; } = new List<Genre>(); // default value
    }
}
