using App.Entities_Base;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperrDAL
{
    public class AlumnoDapperDAL : DALBase
    {
        public List<Alumno> ListAllAlumno()
        {
            using (var connection = getConnection())
            {
                return connection.GetAll<Alumno>().ToList();
            }
        }

        public void RegisterAlumno(Alumno alumno)
        {
            using (var connection = getConnection())
            {
                connection.Insert(alumno);
            }
        }
        public void UpdateAlumno(Alumno alumno)
        {
            using (var connection = getConnection())
            {
                connection.Update(alumno);
            }
        }
        public void DeleteAlumno(int id)
        {
            using (var connection = getConnection())
            {
                connection.Delete(new Alumno { Id = id });
               // var isSuccess = connection.Delete(new InvoiceContrib { InvoiceID = 1 });

            }
        }
    }
}
