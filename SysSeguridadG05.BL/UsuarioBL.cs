﻿using SysSeguridadG05.DAL;
using SysSeguridadG05.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysSeguridadG05.BL
{
    public class UsuarioBL
    {
        public static async Task<int> CrearAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.GuardarAsync(pUsuario);

        }
        public static async Task<int> ModificarAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.ModificarAsync(pUsuario);
        }
        public static async Task<int> DeleteAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.EliminarAsync(pUsuario);
        }
        public static async Task<Usuario> ObtenerPorIdAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.ObtenerPorIdAsync(pUsuario);
        }
        public static async Task<List<Usuario>> ObtenerTodosAsync()
        {
            return await UsuarioDAL.ObtenerTodosAsync();
        }
        public static async Task<List<Usuario>> BuscarAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.BuscarAsync(pUsuario);
        }
        public static async Task<List<Usuario>> BuscarIncluirRolAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.BuscarIncluirRolAsync(pUsuario);
        }
        public static async Task<Usuario> LoginAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.LoginAsync(pUsuario);
        }
        public static async Task<int> CambiarPasswordAsync(Usuario pUsuario, string pPasswordAnt)
        {
            return await UsuarioDAL.CambiarPasswordAsync(pUsuario, pPasswordAnt);
        }
    }
}
