using System.ComponentModel.DataAnnotations;

namespace WebAPILayer.DAL.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
