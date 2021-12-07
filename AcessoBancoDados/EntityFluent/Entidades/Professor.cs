using System;
using System.Collections.Generic;


namespace EntityDataAnnotations
{
    
    public class Professor
    {
        public long Id { get; set; }
        
        public String Nome { get; set; }
        
        public string Cpf { get; set; }

        public DateTime DataRegistro { get; set; }
        public List<Disciplina> Disciplinas { get; set; }

       
     }
}
