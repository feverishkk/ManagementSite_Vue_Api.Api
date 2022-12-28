using CommonDatabase.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.GetItems
{
    public interface IWeaponRepository : IGenericRepository<Weapon>
    {
    }
}
