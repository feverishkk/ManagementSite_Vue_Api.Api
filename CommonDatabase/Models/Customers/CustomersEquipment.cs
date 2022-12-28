using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.TotalItems;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDatabase.Models.Customers
{
    public class CustomersEquipment
    {
        [Key]
        public int UserId { get; set; }

        public string ID { get; set; } = string.Empty;

        public virtual TotalWeapons TotalWeaponId { get; set; } = default!;

        public virtual TShirt TShirt { get; set; } = default!;

        public virtual Armor Armor { get; set; } = default!;

        public virtual Cape Cape { get; set; } = default!;
        
        public virtual Boots Boots { get; set; } = default!;

        public virtual Globe Globe { get; set; } = default!;

        public virtual Ring1 Ring1 { get; set; } = default!;

        public virtual Ring2 Ring2 { get; set; } = default!;

        public virtual Neckless Neckless { get; set; } = default!;

        public virtual Guard Guard { get; set; } = default!;

        public virtual Helmet Helmet { get; set; } = default!;

        [ForeignKey("BeltId")]
        public virtual Belt Belt { get; set; } = default!;

        public virtual EarRing EarRing { get; set; } = default!;
    }

}
