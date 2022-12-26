using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CSACVM.AccesoDatos.Repositorio
{
    public class UnitOfWork : IUnitOfWork
    {
        private CSACVMContext _db;

        public UnitOfWork(CSACVMContext db) {
            _db = db;
        }
        public void Save() {
            _db.SaveChanges();
        }
    }
}