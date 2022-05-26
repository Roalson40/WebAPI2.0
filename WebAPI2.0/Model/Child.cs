using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI2._0.Model
{
    public class Child
    {
        [Key]
        public int ChildId { get; set; }
        
        [Required, MaxLength(50)]
        public string Name { get; set; }
        
        [Required, Range(3,6)]
        public int Age { get; set; }
        
        [Required]
        public string Gender { get; set; }
        
        public ICollection<Toy> Toys { get; set; }
    }
}