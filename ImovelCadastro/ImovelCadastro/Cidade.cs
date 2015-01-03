using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImovelCadastro
{
    class Cidade
    {
        public int cod;
        public string nome;
        public string UF;

        public static void Listar(List<Cidade> Lista)
        {
            Console.WriteLine("\t-----------------------------");
            Console.WriteLine("\tCód Nome                 UF");
            Console.WriteLine("\t-----------------------------\n\n");
            foreach (Cidade c in Lista)
            {
                Console.WriteLine("\t{0:D4} {1} {2} ", c.cod, c.nome.PadRight(20), 
                    c.UF.PadRight(10));
            }
        }

        public void Excluir(ref List<Cidade> Lista) 
        {
            Lista.Remove(this);
        }

        public void Inserir(ref List<Cidade> Lista)
        {
            PreencherCidade();
            Lista.Add(this);
        }

        private void PreencherCidade()
        {
            Console.WriteLine("\n\t-----------------------------------------------");
            Console.WriteLine("\t-----------------------------------------------");
            Console.Write("\n\tDigite o Código da Cidade: ");
            this.cod = Convert.ToInt32(Console.ReadLine());
            Console.Write("\tDigite o Nome da Cidade: ");
            this.nome = Console.ReadLine();
            Console.Write("\tDigite o UF da Cidade: ");
            this.UF = Console.ReadLine();
            Console.WriteLine("\n\n\tCadastro Efetuado com Sucesso!!");
            Console.ReadKey();
        }
    }
}
