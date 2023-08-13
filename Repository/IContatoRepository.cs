using ControleContatos.Models;

namespace ControleContatos.Repository
{
    public interface IContatoRepository
    {
        List<ContatoModel> GetAll();

        ContatoModel GetById(int id);

        ContatoModel Add(ContatoModel contato);
        ContatoModel Edit(ContatoModel contato);
        bool Delete(int id);
    }
}
