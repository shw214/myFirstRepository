using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int Password { get; set; }
        public IEnumerable<Present> Present { get; set; }
    }
}
