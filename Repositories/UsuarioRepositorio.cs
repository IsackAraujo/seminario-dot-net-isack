using PW45S.Data;
using PW45S.Models;
using PW45S.Repositories.Interfaces;

namespace PW45S.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public readonly SistemasTarefasDbContext _context;
        public UsuarioRepositorio(SistemasTarefasDbContext context)
        {
            _context = context;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return _context.Usuarios.ToList();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            _context.Usuarios.Add(usuario); 
            await _context.SaveChangesAsync();
            return usuario;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel user = await BuscarPorId(id);
            if (user == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }
            user.Nome = usuario.Nome;
            user.Email = usuario.Email;
            _context.Usuarios.Update(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel user = await BuscarPorId(id);
            if (user == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }
            _context.Usuarios.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}

