using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetCoreFramework.Core.Entities;

namespace NetCoreFramework.Repository.Entities.Concrete
{
    public sealed partial class Country : IEntity
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        [Key]
        public short Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        [Column("Code_Phone")]
        public short CodePhone { get; set; }
        [Required]
        [Column("Code_Alpha2")]
        [StringLength(2)]
        public string CodeAlpha2 { get; set; }

        [InverseProperty(nameof(City.Country))]
        public ICollection<City> Cities { get; set; }
    }
}