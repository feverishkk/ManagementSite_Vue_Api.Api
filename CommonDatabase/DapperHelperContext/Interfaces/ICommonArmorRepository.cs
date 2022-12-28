using CommonDatabase.Models.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.DapperHelperContext.Interfaces
{
    public interface ICommonArmorRepository
    {
        public IEnumerable<Armor> GetAllArmor();
        public Armor CreateArmor(Armor armor);
        public Armor UpdateArmor(Armor armor);
        public int DeleteArmor(int armorId);
        public IEnumerable<Armor> SearchArmorByName(string name);
    }
}
