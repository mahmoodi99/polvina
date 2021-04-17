
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CommonBaseType.Model
{
    public class BaseTypeService :IBaseType
    {
       
        
            Contexts db = new Contexts();

            public BaseTypeService(Contexts context)
            {
                this.db = new Contexts();
            }

            public IEnumerable<TblCommonBaseType> getall()
            {
                return db.TblCommonBaseTypes;
            }

            public TblCommonBaseType getid(int id)
            {
                return db.TblCommonBaseTypes.Find(id);
            }

            public bool insert(TblCommonBaseType TblCommonBaseType)
            {
                try
                {
                    db.TblCommonBaseTypes.Add(TblCommonBaseType);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            public bool edite(TblCommonBaseType TblCommonBaseType)
            {
                try
                {


                    db.Entry(TblCommonBaseType).State = EntityState.Modified;
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public bool delete(TblCommonBaseType TblCommonBaseType)
            {
                try
                {


                    db.TblCommonBaseTypes.Remove(TblCommonBaseType);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }





            public bool deleteid(int id)
            {
                try
                {


                    db.Entry(id).State = EntityState.Deleted;
                    db.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                };
            }
            public void savecheng()
            {
                db.SaveChanges();
            }

        }
    }

