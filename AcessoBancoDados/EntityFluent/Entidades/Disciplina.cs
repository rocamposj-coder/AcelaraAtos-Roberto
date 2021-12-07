using System;
using System.Collections.Generic;


namespace EntityDataAnnotations
{
    
    public class Disciplina
    {
        public long Id { get; set; }

        public String Nome { get; set; }

        public int CargaHoraria { get; set; }

        //public long IdProfessor { get; set; }
        //public Professor Professor { get; set; }

        public List<Professor> Professores { get; set; }

    }
}
