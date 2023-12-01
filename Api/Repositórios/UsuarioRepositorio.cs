using Api.Data;
using Api.Models;
using Api.Repositórios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositórios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefaDbContext _dbContext;
        private IUsuarioRepositorio usuarioRepositorio;

        public UsuarioRepositorio(SistemaTarefaDbContext sistemaTarefaDbContext)
        {
            _dbContext = sistemaTarefaDbContext;
        }

       

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
                return await _dbContext.Usuarios.ToListAsync();
            }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
           await  _dbContext.Usuarios.AddAsync(usuario);
           await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {

            UsuarioModel apagar = await BuscarPorId(id);
            if (apagar == null)
            {
                throw new Exception($"Usuario do id {id} não encontrado");
            }

            _dbContext.Usuarios.Remove(apagar);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel atualiza = await BuscarPorId(id);
            if (atualiza == null)
            {
                throw new Exception($"Usuario do id {id} não encontrado");
            }


            atualiza.Name = usuario.Name;
            atualiza.Email = usuario.Email;
            _dbContext.Usuarios.Update(atualiza);
            await _dbContext.SaveChangesAsync();
            return atualiza;
        }

      
    }
}
