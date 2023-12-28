using System.ComponentModel.DataAnnotations;

namespace BookStore.EF_Core
{

        public class shape
    {
            [Key]
         public string ShapeId { get; set; }
        [Required]
         public int Id { get; set; }
         public Books Books { get; set; } // establishing a connection with the Books class
         public string shapeName { get; set; }
         public int shapeDim { get; set; }

        }
   
}
