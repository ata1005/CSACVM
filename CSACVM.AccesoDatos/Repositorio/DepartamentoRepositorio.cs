using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace CSACVM.AccesoDatos.Repositorio{
    public class DepartamentoRepositorio : Repositorio<Departamento>, IDepartamentoRepositorio
    {
        private CSACVMContext _db;
        public DepartamentoRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Departamento obj)
        {
            _db.Departamento.Update(obj);
        }

        public IEnumerable<SelectListItem> ObtenerDepartamentos() {
            return from d in _db.Departamento
                   select new SelectListItem {
                       Text = d.Descripcion,
                       Value = d.IdDepartamento.ToString()
                   };
        }
    }
}
