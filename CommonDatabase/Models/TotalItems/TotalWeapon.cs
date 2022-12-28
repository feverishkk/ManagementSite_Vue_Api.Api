using CommonDatabase.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.TotalItems
{
    public class TotalWeapon
    {
        public virtual Dagger Dagger { get; set; } = default!;

        public virtual OneHandBow OneHandBow { get; set; } = default!;
        public virtual OneHandStick OneHandStick { get; set; } = default!;
        public virtual OneHandSword OneHandSword { get; set; } = default!;

        public virtual TwoHandBow TwoHandBow { get; set; } = default!;
        public virtual TwoHandStick TwoHandStick { get; set; } = default!;
        public virtual TwoHandSword TwoHandSword { get; set; } = default!;

    }
}
