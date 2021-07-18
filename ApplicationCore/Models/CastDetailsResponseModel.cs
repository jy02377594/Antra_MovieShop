using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class CastDetailsResponseModel
    {
        public int Id { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TmdbUrl { get; set; }
        [MaxLength(2084)]
        public string ProfilePath { get; set; }
        public List<MovieCardResponseModel> Movies { get; set; }
    }
}
