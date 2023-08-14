using ControleContatos.Models;

namespace ControleContatos.Repository
{
    public interface IUsuarioRepository
    {
        List<UsuarioModel> GetAll();
        UsuarioModel GetById(int id);
        UsuarioModel Add(UsuarioModel usuario);
        UsuarioModel Edit(UsuarioModel usuario);
        bool Delete(int id);
    }
}
