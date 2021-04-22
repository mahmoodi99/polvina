using CommonBaseData.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonBaseData.Entity.Repository
{
    public class BaseDataRepository : IBaseDataRepository
    {
        private BaseData_Contexts _Context;

        public BaseDataRepository(BaseData_Contexts context)
        {
            _Context = context;
        }

        public async Task<bool> IsExists(int id)
        {
            return await _Context.TblCommonBaseData.AnyAsync(c => c.CommonBaseDataId == id);
        }


        public async Task<bool> IsExistscode(string value)
        {
            return await _Context.TblCommonBaseData.AnyAsync(c => c.BaseValue == value || c.BaseCode == value);
        }



        public async Task<TblCommonBaseData> IsExistsTblsNeed(int id)
        {
            return await _Context.TblCommonBaseData.Include(c => c.TblNeedyAccounts)
                .FirstOrDefaultAsync(f => f.NeedyAccountId== id);
        }

        private TblCommonBaseData ok(object p)
        {
            throw new NotImplementedException();
        }

        //  Guid.NewGuid().ToString("")


        public async Task<TblCommonBaseData> ws_CreateBaseValue(TblCommonBaseData TblCommonBaseData)
        {
            var id = Guid.NewGuid().ToString("000");
            await _Context.TblCommonBaseData.AddAsync(TblCommonBaseData);

            TblCommonBaseData = new TblCommonBaseData
            {

                CommonBaseTypeId = TblCommonBaseData.CommonBaseTypeId,
                BaseValue = TblCommonBaseData.BaseValue,
                BaseCode = TblCommonBaseData.CommonBaseTypeId + "id"
            };


            await _Context.SaveChangesAsync();
            return TblCommonBaseData;
        }




        public async Task<TblCommonBaseData> ws_DeleteBaseValue(int id)
        {
            var baseData = await _Context.TblCommonBaseData.SingleAsync(t => t.CommonBaseDataId == id);
            _Context.TblCommonBaseData.Remove(baseData);
            await _Context.SaveChangesAsync();
            return (baseData);
        }




        public IEnumerable<TblCommonBaseData> loadBaseValue()
        {
            return _Context.TblCommonBaseData.ToList();
        }




        public async Task<TblCommonBaseData> ws_loadBaseValueById(int id)
        {
            return await _Context.TblCommonBaseData.SingleOrDefaultAsync(c => c.CommonBaseDataId == id);
        }




        public async Task<TblCommonBaseData> ws_loadBaseValueByTitle(string value)
        {
            return await _Context.TblCommonBaseData.FirstOrDefaultAsync(c => c.BaseCode == value || c.BaseValue == value);
        }



        public async Task<TblCommonBaseData> ws_UpdateBaseValue(TblCommonBaseData TblCommonBaseData)
        {
            _Context.TblCommonBaseData.Update(TblCommonBaseData);
            await _Context.SaveChangesAsync();
            return (TblCommonBaseData);
        }




    }
}
