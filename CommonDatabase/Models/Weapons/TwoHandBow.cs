﻿using System.ComponentModel.DataAnnotations;

namespace CommonDatabase.Models.Weapons
{
    public class TwoHandBow
    {
        [Key]
        public int TwoHandBowId { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Damage1 { get; set; }
        public int Damage2 { get; set; }
        public string Class { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
