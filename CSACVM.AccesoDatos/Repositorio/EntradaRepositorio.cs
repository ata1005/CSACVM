using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;
using System.Reflection;

namespace CSACVM.AccesoDatos.Repositorio{
    public class EntradaRepositorio : Repositorio<Entrada>, IEntradaRepositorio
    {
        private CSACVMContext _db;
        public EntradaRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Entrada obj)
        {
            _db.Entrada.Update(obj);
        }

        public List<ListaEntradaVM> ObtenerListaEntradaVM() {
            List<ListaEntradaVM> listaEntradas = new List<ListaEntradaVM>();

            List<Entrada> entradas = _db.Entrada.OrderByDescending(e => e.FechaCreacion).ToList();

            foreach(Entrada entrada in entradas) { 
                Usuario user = _db.Usuario.Where(u => u.IdUsuario == entrada.IdUsuario).FirstOrDefault();

                ListaEntradaVM listaModel = new ListaEntradaVM() {
                    Usuario = user,
                    Entrada = entrada
                };  

                listaEntradas.Add(listaModel);
            }

            

            return listaEntradas;
        }

        public void NuevaEntrada(EntradaVM model, int idUser) {
            Entrada entrada = new Entrada() {
                IdUsuario = idUser,
                Descripcion = model.TextoPublicacion,
                ProcesoCreacion = MethodBase.GetCurrentMethod().Name,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = idUser
            };

            _db.Entrada.Add(entrada);
            _db.SaveChanges();
        }
    }
}
