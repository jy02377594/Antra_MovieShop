using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public Guid PurchaseNumber { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public DateTime PurchaseDateTime { get; set; }
        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
