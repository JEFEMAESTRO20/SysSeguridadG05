using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
//**************************
using Microsoft.EntityFrameworkCore;
using SysSeguridadG05.EN;

namespace SysSeguridadG05.DAL
{
    public class UsuarioDAL
    {
        private static void EncriptarMD5(Usuario pUsuario)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(pUsuario.Password));
                var strEncriptar = "";
                for (int i = 0; i < result.Length; i++)
                    strEncriptar += result[i].ToString("x2").ToLower();
                pUsuario.Password = strEncriptar;
            }
        }

        private static async Task<bool> ExisteLogin(Usuario pUsuario, DBContexto pDbContexto)            
        {
            bool result = false;
            var loginUsuarioExiste = await pDbContexto.Usuarios.FirstOrDefaultAsync(a => a.Login == pUsuario.Login && a.Id != pUsuario.Id);
            if (loginUsuarioExiste != null && loginUsuarioExiste.Id > 0 && loginUsuarioExiste.Login == pUsuario.Login)
                result = true;
            return result;
        }
        #region "CRUD"
            public static async Task<int> GuardarAsync(Usuario pUsuario)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    bool existeLogin = await ExisteLogin(pUsuario, dbContexto);
                    if (existeLogin == false)
                    {
                        pUsuario.FechaRegistro = DateTime.Now;
                        EncriptarMD5(pUsuario);
                        dbContexto.Add(pUsuario);
                        result = await dbContexto.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("Login ya existe");
                    }
                }
            }
            catch (Exception ex)
            {
                result = 0;
                throw new Exception("Ocurrió un error externo");
            }
            return result;
            }
        #endregion
    }
}
