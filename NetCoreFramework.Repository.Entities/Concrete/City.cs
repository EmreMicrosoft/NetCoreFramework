using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetCoreFramework.Core.Entities;

namespace NetCoreFramework.Repository.Entities.Concrete
{
    public class City : IEntity
    {
        [Key]
        public int Id { get; set; }
        public short CountryId { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Cities")]
        public virtual Country Country { get; set; }
    }
}