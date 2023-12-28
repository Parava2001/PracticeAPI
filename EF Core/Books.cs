using System.ComponentModel.DataAnnotations;

namespace BookStore.EF_Core
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<shape> shape { get; set; }   // this is a foreign key
                                                  // Ilist is for shwing many to many or one to many relation
    }

   
}
