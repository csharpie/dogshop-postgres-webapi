using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogShop.Models
{
    [Table("dog", Schema = "public")]
    public class Dog
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("breed")]
        public string Breed { get; set; }
        [Column("is_vaccinated")]
        public bool IsVaccinated { get; set; }
    }
}