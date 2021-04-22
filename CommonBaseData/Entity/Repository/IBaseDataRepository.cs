using CommonBaseData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonBaseData.Entity.Repository
{
    public interface IBaseDataRepository
    {
        Task<TblCommonBaseData> ws_loadBaseValueById(int id);
        IEnumerable<TblCommonBaseData> loadBaseValue();
        Task<TblCommonBaseData> ws_loadBaseValueByTitle(string value);
        Task<TblCommonBaseData> ws_CreateBaseValue(TblCommonBaseData TblCommonBaseData);
        Task<TblCommonBaseData> ws_UpdateBaseValue(TblCommonBaseData TblCommonBaseData);
        Task<TblCommonBaseData> ws_DeleteBaseValue(int id);
        Task<bool> IsExists(int id);
        Task<bool> IsExistscode(string value);
        Task<TblCommonBaseData> IsExistsTblsNeed(int id);
    }
}
