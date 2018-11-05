using SOS.Dentes.DAL;
using SOS.Dentes.Model;

namespace SOS.Dentes.BLL
{
    public class ContatoBLL
    {
        private ContatoDAL dal;
        public ContatoBLL()
        {
            this.dal = new ContatoDAL();
        }
        public void create(Contato model)
        {
            dal.create(model);
        }
    }
}