using SOS.Dentes.DAL;
using SOS.Dentes.Model;

namespace SOS.Dentes.BLL
{
    public class PreCadastroBLL
    {
        private PreCadastroDAL dal;

        public PreCadastroBLL()
        {
            this.dal = new PreCadastroDAL();
        }
        public void create(PreCadastro model)
        {
            dal.create(obj: model);
        }

    }
}
