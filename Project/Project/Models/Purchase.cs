using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        public int PresentId { get; set; }
        public IEnumerable<Present> Presents { get; set; }
        public Customer Customer { get; set; }
    }
}
