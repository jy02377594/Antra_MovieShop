using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class ReviewDetailsModel
    {
        public decimal? Rating { get; set; }
        public string ReviewText { get; set; }
        public string MovieName { get; set; }
        public string UserName { get; set; }
    }
}
