using BackendMillonAndUpDataAccess.Interfaces;
using BackendMillonUpDomain.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using BackendMillonAndUpDataAccess.Interfaces.Owners;

namespace BackendMillonAndUpDataAccess.Repositories.Owners
{
    public class OwnerD : IOwnerD
    {
        private readonly ParameterContext _ParameterContext;
        public OwnerD(ParameterContext paramContext)
        {
            _ParameterContext = paramContext;
        }

        public RtaOwner DeleteOwner(int IdOwner)
        {
            SqlParameter[] sqlParam = new SqlParameter[] {
                  new SqlParameter("@IdOwner", IdOwner),
                     };

            var sp = _ParameterContext.dsRtaOwner.FromSql("EXEC Sp_DeleteOwner   @IdOwner", sqlParam).FirstOrDefault();

            return sp;
        }

        public List<Owner> GetOwnerId(int IdOwner)
        {
            SqlParameter[] sqlParam = new SqlParameter[] {
                  new SqlParameter("@IdOwner", IdOwner)
            };
            var sp = _ParameterContext.dsOwner.FromSql("EXEC Sp_OwnerId   @IdOwner", sqlParam).ToList();
            return sp;
        }

        public List<Owner> GetOwners()
        {
            var sp = _ParameterContext.dsOwner.FromSql("EXEC Sp_SelectOwner").ToList();
            return sp;
        }
        

        public RtaOwner InsertOwner(Owner model)
        {

                  SqlParameter[] sqlParam = new SqlParameter[] {
                  //new SqlParameter("@IdOwner", model.IdOwner),
                  new SqlParameter("@NamesOwner", model.NamesOwner),
                  new SqlParameter("@AdressOwner", model.AdressOwner),
                  new SqlParameter("@Age", model.Age),
                  new SqlParameter("@Telephone", model.Telephone),
                  new SqlParameter("@Email", model.Email),

            };

            var sp = _ParameterContext.dsRtaOwner.FromSql("EXEC Sp_InsertOwner  @NamesOwner,  @AdressOwner,   @Age,   @Telephone,   @Email", sqlParam).FirstOrDefault();

            return sp;
        }

        public RtaOwner UpdateOwner(Owner model)
        {
            SqlParameter[] sqlParam = new SqlParameter[] {
                  new SqlParameter("@IdOwner", model.IdOwner),
                  new SqlParameter("@NamesOwner", model.NamesOwner),
                  new SqlParameter("@AdressOwner", model.AdressOwner),
                  new SqlParameter("@Age", model.Age),
                  new SqlParameter("@Telephone", model.Telephone),
                  new SqlParameter("@Email", model.Email),

            };

            var sp = _ParameterContext.dsRtaOwner.FromSql("EXEC Sp_UpdateOwner @IdOwner,  @NamesOwner,  @AdressOwner,   @Age,   @Telephone,   @Email", sqlParam).FirstOrDefault();

            return sp;
        }
    }
}
