﻿using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;
using Microsoft.AspNetCore.Http;
namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface ICurriculumRepositorio : IRepositorio<Curriculum> {
        void Update(Curriculum obj);
        public List<Curriculum> ObtenerCurriculumsUsuario(int idUsuario);
        public void GuardarNuevoCurriculum(string titulo, int idUsuario);
        public void EliminarCurriculum(Curriculum curriculum);
        public void ActualizarNombre(Curriculum curriculum, CurriculumModelVM model);
    }
}
