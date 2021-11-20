using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Aula2Exemplo
{

    class Diretorio
    {
        public string Nome;
        public List<Diretorio> SubDiretorios;

        public Diretorio(string nome)
        {
            this.Nome = nome;
            SubDiretorios = new List<Diretorio>();
        }
    }
    
    class Program
    {
        static void Main()
        {            
            Diretorio raiz = new Diretorio("C:\\dev");
            raiz = DescobrirEstrutura("C:\\dev", raiz);

            //atribuindo novo caminho
            var novo = "C:\\NOVO";

            CriarDiretorios(raiz, ref raiz.Nome, ref novo);
            
        }

        static Diretorio DescobrirEstrutura(string caminho, Diretorio raiz)
        {
            var subDirs = Directory.GetDirectories(caminho);

            if(subDirs.Length > 0)
            {
                for(int i=0; i<subDirs.Length; i++)
                {
                    Diretorio dir = new Diretorio(subDirs[i]);
                    dir = DescobrirEstrutura(subDirs[i], dir);
                    raiz.SubDiretorios.Add(dir);
                }
            }

            return raiz;
        }

        public static void CriarDiretorios(Diretorio raiz, ref string antigo, ref string novo)
        {
            if (raiz.SubDiretorios.Count > 0)
            {
                foreach (var dir in raiz.SubDiretorios)
                {
                    CriarDiretorios(dir, ref antigo, ref novo);
                }
            }
            else
            {
                raiz.Nome = raiz.Nome.Replace(antigo, novo);
                Directory.CreateDirectory(raiz.Nome);
            }
        }

    }



}
