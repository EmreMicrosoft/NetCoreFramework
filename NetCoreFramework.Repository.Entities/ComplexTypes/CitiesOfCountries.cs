using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetCoreFramework.Core.Entities;

namespace NetCoreFramework.Repository.Entities.ComplexTypes
{
    public partial class CitiesOfCountry : IView
    {
        public int Id { get; set; }
        public short CountryId { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        public short Expr1 { get; set; }
        [Required]
        [StringLength(64)]
        public string Expr2 { get; set; }
        [Column("Code_Phone")]
        public short CodePhone { get; set; }
        [Required]
        [Column("Code_Alpha2")]
        [StringLength(2)]
        public string CodeAlpha2 { get; set; }
    }
}