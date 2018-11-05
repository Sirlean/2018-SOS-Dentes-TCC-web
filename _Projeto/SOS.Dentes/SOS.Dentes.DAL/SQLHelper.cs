using System.Collections.Generic;

namespace SOS.Dentes.DAL
{
    public interface SQLHelper<QualquerClasse>
    {
        void create(QualquerClasse obj);
        void delete(QualquerClasse obj);
        void update(QualquerClasse obj);
        bool find(QualquerClasse obj);
        List<QualquerClasse> findAll();


    }
}
