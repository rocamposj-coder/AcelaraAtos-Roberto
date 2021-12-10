using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApiComEntity
{

    public class Retorno<T>
    {
        public T Data { get;  set; }

        public List<string> Erros { get;  set; } = new(); //Novidade, nao precisa fazer isso no construtor, e o comondo new ja consegue inferir o tipo

    }
}
