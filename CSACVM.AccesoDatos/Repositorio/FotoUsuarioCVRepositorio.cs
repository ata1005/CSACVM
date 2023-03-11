using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Reflection;

namespace CSACVM.AccesoDatos.Repositorio{
    public class FotoUsuarioCVRepositorio : Repositorio<FotoUsuarioCV>, IFotoUsuarioCVRepositorio {
        private CSACVMContext _db;
        public FotoUsuarioCVRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(FotoUsuarioCV obj)
        {
            _db.FotoUsuarioCV.Update(obj);
        }

        public void ChangePhoto(FotoUsuarioCV foto, string fullpath, string guid, string ext, int idUsuario) {
            foto.Ruta = fullpath;
            foto.Guid = guid;
            foto.Ext = ext;
            foto.FechaActualizacion = DateTime.Now;
            foto.ProcesoActualizacion = MethodBase.GetCurrentMethod().Name;
            foto.UsuarioActualizacion = idUsuario;
            _db.FotoUsuarioCV.Add(foto);
            _db.SaveChanges();
        }

        public void AddPhoto(string fullpath, string guid, string ext, int idUsuario, int idCurriculum) {
            FotoUsuarioCV foto = new FotoUsuarioCV() {
                Ruta = fullpath,
                Guid = guid,
                IdUsuarioCV = idUsuario,
                Ext = ext,
                IdCurriculum = idCurriculum,
                FechaCreacion = DateTime.Now,
                ProcesoCreacion = MethodBase.GetCurrentMethod().Name,
                UsuarioCreacion = idUsuario
            };
           
            _db.FotoUsuarioCV.Add(foto);
            _db.SaveChanges();
        }
        public void EliminarFotoUsuario(FotoUsuarioCV fotoUsuarioCV) {
            _db.FotoUsuarioCV.Remove(fotoUsuarioCV);
            _db.SaveChanges();
        }
    }
}
