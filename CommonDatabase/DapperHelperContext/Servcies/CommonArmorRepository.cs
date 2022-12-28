using CommonDatabase.DapperHelperContext.DapperHelper;
using CommonDatabase.DapperHelperContext.Interfaces;
using CommonDatabase.Models.Equipment;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.DapperHelperContext.Servcies
{
    public class CommonArmorRepository : ICommonArmorRepository
    {
        private readonly CommonDbContext _dapperContext;

        public CommonArmorRepository(CommonDbContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public IEnumerable<Armor> GetAllArmor()
        {
            using(var connection = _dapperContext.CreateConnection())
            {
                var result = connection.Query<Armor>("usp_GetAllArmor",
                                        commandType:System.Data.CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public Armor CreateArmor(Armor armor)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ArmorId", armor.ArmorId);
            parameters.Add("@Name", armor.Name);
            parameters.Add("@AC", armor.AC);
            parameters.Add("@Class", armor.Class);
            parameters.Add("@Image", armor.Image);
            parameters.Add("@Description", armor.Description);

            using(var connection = _dapperContext.CreateConnection())
            {
                connection.Execute("usp_CreateArmor", parameters, 
                                    commandType: System.Data.CommandType.StoredProcedure);

                return armor;
            }
        }

        public Armor UpdateArmor(Armor armor)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ArmorId", armor.ArmorId);
            parameters.Add("@Name", armor.Name);
            parameters.Add("@AC", armor.AC);
            parameters.Add("@Class", armor.Class);
            parameters.Add("@Image", armor.Image);
            parameters.Add("@Description", armor.Description);

            using( var connection = _dapperContext.CreateConnection())
            {
                connection.Execute("usp_UpdateArmor", parameters, 
                                    commandType: System.Data.CommandType.StoredProcedure);

                return armor;
            }
        }

        public int DeleteArmor(int armorId)
        {
            using( var connection = _dapperContext.CreateConnection())
            {
                connection.Execute("usp_DeleteArmor", new { ArmorId = armorId }, 
                                    commandType: System.Data.CommandType.StoredProcedure);

                return armorId;
            }
        }

        public IEnumerable<Armor> SearchArmorByName(string ArmorName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", ArmorName);

            using(var connection = _dapperContext.CreateConnection())
            {
                var result = connection.Query<Armor>("usp_SearchArmorByName", parameters,
                                        commandType: System.Data.CommandType.StoredProcedure);

                return result;
            }
        }

    }
}
