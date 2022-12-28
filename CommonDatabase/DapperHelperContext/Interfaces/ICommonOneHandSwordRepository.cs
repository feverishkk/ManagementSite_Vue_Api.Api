using CommonDatabase.Models.TotalItems;
using CommonDatabase.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.DapperHelperContext.Interfaces
{
    public interface ICommonOneHandSwordRepository
    {
        public IEnumerable<OneHandSword> GetAllOneHandSword();
        public OneHandSword CreateOneHandSword(OneHandSword oneHandSword);
        public OneHandSword UpdateOneHandSword(OneHandSword oneHandSword);
        public int DeleteOneHandSword(int oneHandSwordId);
        public IEnumerable<OneHandSword> SearchOneHandSwordByName(string name);
    }
}
