using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLambda
{
    public class Disciplina //: IComparable<Disciplina>
    {
        public int id;
        public string nome;

        public int CompareTo(Disciplina obj)
        {
            
            return id.CompareTo(obj.id);

            
        }





        /* public int CompareTo(object obj)
         {
             int retorno = 0;
             Disciplina teste = (Disciplina)obj;
            
             if (teste.id > id)
             {
                 retorno = -1;
             }
             else if (teste.id < id)
             {
                 retorno = 1;
             }
             else
                 retorno = 0;


             return retorno;
         }
         */


    }
}
