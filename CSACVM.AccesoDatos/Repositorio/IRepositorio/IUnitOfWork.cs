using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnitOfWork
    {
        void Save();
    }
}