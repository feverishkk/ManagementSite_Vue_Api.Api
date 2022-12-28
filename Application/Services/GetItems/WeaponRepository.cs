using Application.Interfaces.GetItems;
using CommonDatabase.DapperHelperContext.DapperHelper;
using CommonDatabase.Models.Weapons;
using Dapper;

namespace Application.Services.GetItems
{
    public class WeaponRepository : IWeaponRepository
    {
        private readonly CommonDbContext _commonDbContext;

        public WeaponRepository(CommonDbContext commonDbContext)
        {
            _commonDbContext = commonDbContext;
        }

        public IList<Weapon> GetAll()
        {
            using (var connection = _commonDbContext.CreateConnection())
            {
                var result = connection.Query<Weapon>("usp_GetTotalWeapon",
                                              commandType: System.Data.CommandType.StoredProcedure);

                return (IList<Weapon>)result;
            }
        }

        public Task<Weapon> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
