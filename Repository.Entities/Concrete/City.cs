﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Repository.Entities.Concrete
{
    public partial class City : IEntity
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