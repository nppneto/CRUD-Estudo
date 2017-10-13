using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProjeto.Dominio.Contrato
{
    // onde T recebe como parâmetro qualquer classe
    public interface IRepositorio<T> where T : class 
    {
        void Save(T entidade);

        void Delete(T entidade);

        IEnumerable <T> SelectAll();

        T SelectById(string id);

    }
}
