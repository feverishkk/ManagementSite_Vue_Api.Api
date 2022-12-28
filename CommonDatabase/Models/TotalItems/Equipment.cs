using CommonDatabase.Models.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.TotalItems
{
    public class Equipment
    {
        public virtual Armor Armor { get; set; } = default!;
        public virtual Boots Boots { get; set; } = default!;
        public virtual Cape Cape { get; set; } = default!;
        public virtual Globe Globe { get; set; } = default!;
        public virtual Guard Guard { get; set; } = default!;
        public virtual Helmet Helmet { get; set; } = default!;
        public virtual TShirt TShirt { get; set; } = default!;
    }
}
