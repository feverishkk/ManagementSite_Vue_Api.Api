using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.Customers
{
    public class CustomerEquipment
    {
        public string ID { get; set; } = string.Empty;
        
        public string WeaponImage { get; set; } = string.Empty;
        public string WeaponName { get; set; } = string.Empty;

        public string TShirtImage { get; set; } = string.Empty;
        public string TShirtName { get; set; } = string.Empty;

        public string ArmorImage { get; set; } = string.Empty;
        public string ArmorName { get; set; } = string.Empty;

        public string CapeImage { get; set; } = string.Empty;
        public string CapeName { get; set; } = string.Empty;

        public string BootsImage { get; set; } = string.Empty;
        public string BootsName { get; set; } = string.Empty;

        public string GlobeImage { get; set; } = string.Empty;
        public string GlobeName { get; set; } = string.Empty;

        public string Ring1Image { get; set; } = string.Empty;
        public string Ring1Name { get; set; } = string.Empty;

        public string Ring2Image { get; set; } = string.Empty;
        public string Ring2Name { get; set; } = string.Empty;

        public string NecklessImage { get; set; } = string.Empty;
        public string NecklessName { get; set; } = string.Empty;

        public string GuardImage { get; set; } = string.Empty;
        public string GuardName { get; set; } = string.Empty;

        public string HelmetImage { get; set; } = string.Empty;
        public string HelmetName { get; set; } = string.Empty;

        public string BeltImage { get; set; } = string.Empty;
        public string BeltName { get; set; } = string.Empty;

        public string EarRingImage { get; set; } = string.Empty;
        public string EarRingName { get; set; } = string.Empty;

    }


}
