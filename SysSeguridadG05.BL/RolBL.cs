﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//***********************
using SysSeguridadG05.DAL;
using SysSeguridadG05.EN;

namespace SysSeguridadG05.BL
{
    public class RolBL
    {
        public static async Task<int> CrearAsync(Rol pRol)
        {
            return await RolDAL.CrearAsync(pRol);

        }
        public static async Task<int> ModificarAsync(Rol pRol)
        {
            return await RolDAL.ModificarAsync(pRol);
        }
        public static async Task<int> DeleteAsync(Rol pRol)
        {
            return await RolDAL.DeleteAsync(pRol);
        }
        public static async Task<Rol> ObtenerPorIdAsync(Rol pRol)
        {
            return await RolDAL.ObtenerPorIdAsync(pRol);
        }
        public static async Task<List<Rol>> ObtenerTodosAsync()
        {
            return await RolDAL.ObtenerTodosAsync();
        }
        public static async Task<List<Rol>> BuscarAsync(Rol pRol)
        {
            return await RolDAL.BuscarAsync(pRol);
        }
    }
}