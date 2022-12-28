using CommonDatabase.Models.Accessories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.DapperHelperContext.Interfaces
{
    public interface ICommonBeltRepository
    {
        public IEnumerable<Belt> GetAllBelt();
        public Belt CreateBelt(Belt belt);
        public Belt UpdateBelt(Belt belt);
        public int DeleteBelt(int beltId);
        public IEnumerable<Belt> SearchBeltByName(string name);
    }
}
