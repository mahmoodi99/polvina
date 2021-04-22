
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CommonBaseType.Model
{
    public class BaseTypeRepository : IBaseTypeRepository
    {

        private BaseType_Context _context;
        public BaseTypeRepository(BaseType_Context context)
        {
            _context = context;
        }



        public async Task<bool> IsExists(int id)
        {
            return await _context.TblCommonBaseTypes.AnyAsync(c => c.CommonBaseTypeId == id);
        }



        public async Task<TblCommonBaseType> ExistsModel(TblCommonBaseType tblCommonBaseType)
        {
            
            tblCommonBaseType = new TblCommonBaseType
            {
                BaseTypeCode = tblCommonBaseType.BaseTypeCode,
                BaseTypeTitle = tblCommonBaseType.BaseTypeTitle
            };
            return (tblCommonBaseType);
        }


        public async Task<bool> IsExistscode(string value)
        {
            return await _context.TblCommonBaseTypes.AnyAsync(c => c.BaseTypeCode == "value" || c.BaseTypeTitle == "value");
        }


        public async Task<TblCommonBaseType> ws_CreateBaseType(TblCommonBaseType tblcommandBasetype)
        {
            await _context.TblCommonBaseTypes.AddAsync(tblcommandBasetype);
            await _context.SaveChangesAsync();
            return tblcommandBasetype;
        }

        public async Task<TblCommonBaseType> ws_DeleteBaseType(int id)
        {
            var baseType = await _context.TblCommonBaseTypes.SingleAsync(t => t.CommonBaseTypeId == id);
            _context.TblCommonBaseTypes.Remove(baseType);
            await _context.SaveChangesAsync();
            return (baseType);
        }

        public IEnumerable<TblCommonBaseType> ws_loadBaseType()
        {
            return _context.TblCommonBaseTypes.ToList();
        }


        public async Task<TblCommonBaseType> ws_loadBaseTypeById(int id)
        {
            return await _context.TblCommonBaseTypes.SingleOrDefaultAsync(t => t.CommonBaseTypeId == id);
        }



        public async Task<TblCommonBaseType> ws_loadBaseTypeByTitle(string value)
        {
            return await _context.TblCommonBaseTypes.FirstOrDefaultAsync(c => c.BaseTypeCode == value || c.BaseTypeTitle == value);
        }


        public async Task<TblCommonBaseType> ws_UpdateBaseType(TblCommonBaseType tblcommandBasetype)
        {
            _context.TblCommonBaseTypes.Update(tblcommandBasetype);
            await _context.SaveChangesAsync();
            return (tblcommandBasetype);
        }

        
    }

}


