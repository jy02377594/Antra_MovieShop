using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MovieTest
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public Movie Movie { get; set; }
        public test Test { get; set; }
    }
}
