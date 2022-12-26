﻿using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface INotasUsuarioRepositorio : IRepositorio<NotasUsuario> {
        void Update(NotasUsuario obj);
    }
}
