using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImovelCadastro
{
    class Imovel
    {
        public int codigo;
        public string ende;
        public string bairro;
        public Cidade cidade;

        public static Imovel Pesquisar(int cod, List<Imovel> ListA)
        {
            foreach (Imovel item in ListA)
            {
                if (item.codigo == cod)
                {
                    return item;
                }
            }
            return null;
        }
        public static List<Imovel> Pesquisar(string endereco, List<Imovel> ListB)
        {  
            //o contains retorna true se o texto 
            //que foi digitado contem senão retorna false

            List<Imovel> resultado = new List<Imovel>();
            foreach (Imovel item in ListB)
            {
                if (item.ende.Contains(endereco) || (item.bairro.Contains(endereco)))
                {
                    resultado.Add(item);
                }    
            }
            return resultado;
        }
        public static List<Imovel> Pesquisar(Cidade Cidade, List<Imovel> ListC)
        {
            List<Imovel> resultado = new List<Imovel>();
            foreach (Imovel item in ListC)
            {
                if (item.cidade.cod == Cidade.cod)
                {
                    resultado.Add(item);
                }
            }
            return resultado;
        }
        public void Excluir(ref List<Imovel> Lista)
        {
            Lista.Remove(this);
        }
        public void Inserir(ref List<Imovel> Lista, List<Cidade> Cid)
        {
            string nomecidade;
            Console.WriteLine("\n\t-----------------------------------------------");
            Console.WriteLine("\t-----------------------------------------------");
            Console.Write("\n\t Digite o Código do Imóvel: ");
            this.codigo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\t Digite o Endereço do Imóvel: ");
            this.ende = Console.ReadLine();
            Console.Write("\t Digite o Bairro do Imóvel: ");
            this.bairro = Console.ReadLine();
            Console.WriteLine(" ");
            if (Cid.Count != 0)
            {
                Cidade.Listar(Cid);
                Console.WriteLine("\n");
                Console.Write("\t Digite o nome da Cidade do Imóvel: ");
                nomecidade = Console.ReadLine();
                bool aux = false;
                foreach (Cidade c in Cid)
                {
                    if (nomecidade.ToUpper() == c.nome.ToUpper())
                    {
                        aux = true;
                        this.cidade = c;
                        Console.WriteLine("\n\n\t Cadastro Efetuado com Sucesso!!");
                        Lista.Add(this);
                        Console.ReadKey();
                        break;
                    }
                }
                if (!aux)
                {
                    Console.WriteLine("\n\n\t Cadastre a sua Cidade");
                    Cidade ci = new Cidade();
                    ci.Inserir(ref Cid);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n\n\t Cadastre a Cidade Antes do seu Imóvel");
                Cidade ci = new Cidade();
                ci.Inserir(ref Cid);  
            }
        }
        public static void ListarImoveis(List<Imovel> Lista)
        {
            Console.WriteLine(" ");
            Console.WriteLine("\t IMÓVEIS");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Cód  Cidade                 Bairro                 Endereço");
            Console.WriteLine("-------------------------------------------------------------\n\n");
            foreach (Imovel imv in Lista)
            {
                Console.WriteLine("{0:D3} {1} {2} {3}", imv.codigo, imv.cidade.nome.PadRight(20),
                    imv.bairro.PadRight(25), imv.ende.PadRight(20));
            }
        }
    }
}
