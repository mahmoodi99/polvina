using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace CommonBaseType.Model
{
    public interface IBaseType
    {

        IEnumerable<TblCommonBaseType> getall();
        TblCommonBaseType getid(int id);
        bool insert(TblCommonBaseType TblCommonBaseType);
        bool edite(TblCommonBaseType TblCommonBaseType);
        bool delete(TblCommonBaseType TblCommonBaseType);
        bool deleteid(int id);
        void savecheng();

    }
}
