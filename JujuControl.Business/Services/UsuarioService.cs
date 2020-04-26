using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JujuControl.Data;
using JujuControl.Data.Models.dbModels;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace JujuControl.Business.Services
{
    public class UsuarioService : Data.JujuControl
    {
        private ExceptionFull exception = new ExceptionFull();

        public UsuarioService(DataContext context) : base(context) { }


        /// <summary>
        /// Adiciona, atualiza ou remove usuario de acordo com parametros
        /// </summary>
        /// <param name="usuario">Classe modelo usuario</param>
        /// <param name="crud">add = 0; update = 1; delete = 2</param>
        /// <returns>True para confirmar que gravou no banco</returns>
        public async Task<bool> CRUD(Usuario usuario, int crud)
        {
            Usuario user = new Usuario();
            //Verifica se existe usuario para metodo update/delete
            if (crud != 0)
            {
                user = await GetUsuarioAsync(usuario.Id);
                if (user == null)
                    return false;
            }

            switch (crud)
            {
                case 0:
                    exception = Add(usuario);
                    break;
                case 1:
                    user.Login = usuario.Login;
                    user.Nascimento = usuario.Nascimento;
                    user.Nome = usuario.Nome;
                    user.Perfil = usuario.Perfil;
                    user.Senha = usuario.Senha;
                    user.Cadastro = usuario.Cadastro;
                    exception = Update(user);
                    break;
                case 2:
                    exception = Delete(user);
                    break;
                default:
                    return false;
            }

            if (exception.Status)
                exception = await SaveChangesAsync();

            if (!exception.Status)
            {
                Erro(new ExceptionFull(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Name,
                    GetType().Name,
                    System.Reflection.MethodBase.GetCurrentMethod().Name,
                    exception.Mensagem, exception.Status, DateTime.Now, null)
                    );
                return false;
            }

            return true;
        }

        public async Task<Usuario> GetUsuarioAsync(int id)
        {
            return await _context.Usuario.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Usuario>> GetAllUsuarioAsync() => await GetAllAsync<Usuario>();

    }
}
