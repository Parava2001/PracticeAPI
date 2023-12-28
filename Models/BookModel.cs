using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookModel
    {
        [Key]  // Model Validations
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}