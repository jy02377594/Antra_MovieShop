using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class test
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public ICollection<MovieTest> MovieTests { get; set; }
    }
}
