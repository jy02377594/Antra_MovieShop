using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class MovieCast
    {
        public int MovieId { get; set; }
        public int CastId { get; set; }
        [MaxLength(450)]
        public string Character { get; set; }
        public Movie Movie { get; set; }
        public Cast Cast { get; set; }

    }
}