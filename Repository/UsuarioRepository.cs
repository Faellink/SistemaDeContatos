using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UsuarioRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public UsuarioModel Add(UsuarioModel usuario)
        {
            usuario.Created = DateTime.Now;
            _databaseContext.Usuarios.Add(usuario);
            _databaseContext.SaveChanges();

            return usuario;
        }

        public UsuarioModel Edit(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = GetById(usuario.Id);

            if (usuarioDb == null)
                throw new System.Exception("Contato não encontrado");

            usuarioDb.Name = usuario.Name;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Password = usuario.Password;
            usuarioDb.Profile = usuario.Profile;
            usuarioDb.LastUpdated = DateTime.Now;

            _databaseContext.Usuarios.Update(usuarioDb);
            _databaseContext.SaveChanges();

            return usuarioDb;
        }

        public bool Delete(int id)
        {
            UsuarioModel usuarioDb = GetById(id);

            if (usuarioDb == null)
                throw new System.Exception("Contato não existe");

            _databaseContext.Usuarios.Remove(usuarioDb);
            _databaseContext.SaveChanges();

            return true;
        }

        public UsuarioModel Delete(UsuarioModel contato)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioModel> GetAll()
        {
            return _databaseContext.Usuarios.ToList();
        }

        public UsuarioModel GetById(int id)
        {
            return _databaseContext.Usuarios.FirstOrDefault(contato => contato.Id == id);
        }
    }
}
