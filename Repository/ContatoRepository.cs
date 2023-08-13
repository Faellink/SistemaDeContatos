using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repository
{
    public class ContatoRepository: IContatoRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ContatoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public ContatoModel Add(ContatoModel contato)
        {
            _databaseContext.Contatos.Add(contato);
            _databaseContext.SaveChanges();

            return contato;
        }

        public ContatoModel Edit(ContatoModel contato)
        {
            ContatoModel contatoDb = GetById(contato.Id);

            if (contatoDb == null)
                throw new System.Exception("Contato não encontrado");

            contatoDb.Name = contato.Name;
            contatoDb.Email = contato.Email;
            contatoDb.Phone = contato.Phone;

            _databaseContext.Contatos.Update(contatoDb);
            _databaseContext.SaveChanges();

            return contatoDb;
        }

        public bool Delete(int id)
        {
            ContatoModel contatoDb = GetById(id);

            if (contatoDb == null)
                throw new System.Exception("Contato não existe");

            _databaseContext.Contatos.Remove(contatoDb);
            _databaseContext.SaveChanges();

            return true;
        }

        public ContatoModel Delete(ContatoModel contato)
        {
            throw new NotImplementedException();
        }

        public List<ContatoModel> GetAll()
        {
            return _databaseContext.Contatos.ToList();
        }

        public ContatoModel GetById(int id)
        {
            return _databaseContext.Contatos.FirstOrDefault(contato => contato.Id == id);
        }
    }
}
