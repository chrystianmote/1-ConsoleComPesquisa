using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImovelCadastro
{
    class Program
    {
        enum Pesquisa
        {
            Por_Código = 1,
            Por_Endereço,
            Por_Cidade
        }
        static byte Opcoes()
        {
            Console.Clear();
            Console.Title = "Cadastro de Imóveis";
            Console.WriteLine("\n---------------------------------- ");
            Console.WriteLine("\tCadastro de Imóveis  ");
            Console.WriteLine("----------------------------------\n\n");
            Console.WriteLine(" 1 - Cadastrar um Imóvel ");
            Console.WriteLine(" 2 - Excluir Imóvel ");
            Console.WriteLine(" 3 - Alterar Imóvel ");
            Console.WriteLine(" 4 - Pesquisar Imóvel");
            Console.WriteLine(" 5 - Listar Imóveis ");
            Console.WriteLine(" 6 - Cadastrar Cidade");
            Console.WriteLine(" 7 - Excluir Cidade ");
            Console.WriteLine(" 8 - Alterar Cidade ");
            Console.WriteLine(" 9 - Listar Cidades ");
            Console.WriteLine(" 0 - Sair \n\n");
            Console.WriteLine("---------------------");
            Console.Write(" Informe a Opção Desejada: ");
            byte op = Convert.ToByte(Console.ReadLine());
            if (op != 0)
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\n\nObrigado por utilizar este programa...");
                Console.ReadKey();
            }
            return op;
        }

        static List<Imovel> Imoveis = new List<Imovel>();
        static List<Cidade> ListCid = new List<Cidade>();

        static void Main(string[] args)
        {
            List<Imovel> resultado;
            Cidade c;
            Imovel im;
            int cdgo = 0;
            int ind = 0;
            bool sair = false;
            do
            {
                switch (Opcoes())
                {
                    case 1:
                        im = new Imovel();
                        im.Inserir(ref Imoveis, ListCid);
                        break;
                    case 2:
                        if (Imoveis.Count != 0)
                        {
                            Imovel imvexc = null;
                            Imovel.ListarImoveis(Imoveis);
                            Console.WriteLine("\n\n");
                            Console.WriteLine("\t-------------------------------------");
                            Console.Write("\n\t Digite o código do Imóvel para excluir: ");
                            cdgo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\t-------------------------------------");
                            foreach (Imovel imv in Imoveis)
                            {
                                if (cdgo == imv.codigo)
                                {
                                    imvexc = imv;
                                    break;
                                }
                            }
                            if (imvexc != null)
                            {
                                imvexc.Excluir(ref Imoveis);
                                Console.WriteLine("\n\n\t Imóvel Excluído com sucesso!");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("\n\n\t Imóvel não Encontrado!");
                                Console.ReadKey();
                                goto case 2;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\n\t Cadastre um Imóvel!");
                            Console.ReadKey();
                            goto case 1;
                        }
                        break;
                    case 3:
                        if (Imoveis.Count != 0)
                        {
                            Imovel imvalt = new Imovel();
                            Imovel excl = null;
                            Console.WriteLine("\n\n");
                            Console.WriteLine("\t-------------------------------------");
                            Console.Write("\n\t Digite o código do Imóvel para Alterar: ");
                            cdgo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\t-------------------------------------");
                            for (int i = 0; i < Imoveis.Count; i++)
                            {
                                if (cdgo == Imoveis[i].codigo)
                                {
                                    excl = Imoveis[i];
                                    imvalt.codigo = cdgo;
                                    Console.Write("\t Digite o Endereço do Imóvel: ");
                                    imvalt.ende = Console.ReadLine();
                                    Console.Write("\t Digite o Bairro do Imóvel: ");
                                    imvalt.bairro = Console.ReadLine();
                                    Console.WriteLine(" ");
                                    Cidade.Listar(ListCid);
                                    Console.WriteLine("\n");
                                    Console.Write("\t Digite o nome da Cidade do Imóvel: ");
                                    string nomecidade = Console.ReadLine();
                                    foreach (Cidade ci in ListCid)
                                    {
                                        if (nomecidade.ToUpper() == ci.nome.ToUpper())
                                        {
                                            imvalt.cidade = ci;
                                            Console.WriteLine("\n\n\t Cadastro Efetuado com Sucesso!!");
                                            break;
                                        }
                                    }
                                    ind = i;
                                    break;
                                }
                            }
                            if (excl != null)
                            {
                                Imoveis.Insert(ind, imvalt);
                                excl.Excluir(ref Imoveis);
                                Console.WriteLine("\n\n\t Cadastro Alterado com Sucesso!!");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("\n\n\t Imóvel não Encontrado!");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\n\t Imóvel não localizado para Alteração");
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        Console.Title = "Pesquisar";
                        for (Pesquisa i = Pesquisa.Por_Código; i <= Pesquisa.Por_Cidade; i++)
                        {
                            Console.WriteLine("\n\t {0} - {1}", (int)i, i.ToString().Replace("_", " "));
                        }
                        Console.WriteLine("--------------------------");
                        Console.Write("Escolha a sua opção de Pesquisa: ");
                        switch (Convert.ToByte(Console.ReadLine()))
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("\n\n");
                                Console.WriteLine("\t-------------------------------------");
                                Console.Write("\n\t Digite o código do Imóvel: ");
                                Imovel obj = Imovel.Pesquisar(Convert.ToInt32(Console.ReadLine()), Imoveis);
                                if (obj != null)
                                {
                                    Console.WriteLine("\n\n");
                                    Console.WriteLine("\t--------------------------------------------");
                                    Console.WriteLine("\t {0:D3}", obj.codigo);
                                    Console.WriteLine("\t {0:D4} - {1}", obj.cidade.cod, obj.cidade.nome);
                                    Console.WriteLine("\t {0}", obj.bairro);
                                    Console.WriteLine("\t {0}", obj.ende);
                                    Console.WriteLine("\t--------------------------------------------");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("\n\n");
                                    Console.WriteLine("\t--------------------------");
                                    Console.WriteLine("\t Nenhum Imóvel Encontrado!");
                                    Console.WriteLine("\t--------------------------");
                                    Console.ReadKey();
                                }
                                break;
                            case 2:
                                Console.Clear();
                                resultado = new List<Imovel>();
                                Console.WriteLine("\n\n");
                                Console.WriteLine("\t-------------------------------------");
                                Console.Write("\n\t Digite o Endereço/Bairro do Imóvel: ");
                                resultado = Imovel.Pesquisar(Console.ReadLine(), Imoveis);
                                if (resultado.Count != 0)
                                {
                                    Imovel.ListarImoveis(resultado);
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("\n\n");
                                    Console.WriteLine("\t--------------------------");
                                    Console.WriteLine("\t Nenhum Imóvel Encontrado!");
                                    Console.WriteLine("\t--------------------------");
                                    Console.ReadKey();
                                }
                                break;
                            case 3:
                                Console.Clear();
                                c = new Cidade();
                                resultado = new List<Imovel>();
                                Cidade.Listar(ListCid);
                                Console.WriteLine("\n\n");
                                Console.WriteLine("\t-------------------------------------");
                                Console.Write("\n\t Código da cidade a pesquisar o seu Imóvel : ");
                                c.cod = Convert.ToInt32(Console.ReadLine());
                                resultado = Imovel.Pesquisar(c, Imoveis);
                                if (resultado.Count != 0)
                                {
                                    Imovel.ListarImoveis(resultado);
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("\n\n");
                                    Console.WriteLine("\t--------------------------");
                                    Console.WriteLine("\t Nenhum Imóvel Encontrado!");
                                    Console.WriteLine("\t--------------------------");
                                    Console.ReadKey();
                                }
                                break;
                            default:
                                Console.WriteLine("\t----------------");
                                Console.WriteLine("\t Opção Inválida!");
                                Console.WriteLine("\t----------------");
                                Console.ReadKey();
                                break;
                        }
                        break;
                    case 5:
                        Imovel.ListarImoveis(Imoveis);
                        Console.ReadKey();
                        break;
                    case 6:
                        c = new Cidade();
                        c.Inserir(ref ListCid);
                        break;
                    case 7:
                        if (ListCid.Count != 0)
                        {
                            Cidade.Listar(ListCid);
                            Console.WriteLine("\n\n");
                            Console.WriteLine("\t-------------------------------------");
                            Console.Write("\n\t Digite o código da Cidade para excluir: ");
                            cdgo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\t-------------------------------------");
                            Cidade cexc = null;
                            foreach (Cidade p in ListCid)
                            {
                                if (p.cod == cdgo)
                                {
                                    cexc = p;
                                    break;
                                }
                            }
                            if (cexc != null)
                            {
                                cexc.Excluir(ref ListCid);
                                Console.WriteLine("\n\n\t Cidade Excluída com sucesso!");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("\n\n\t Cidade não Encontrada!");
                                Console.ReadKey();
                                goto case 7;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\n\t Cadastre uma Cidade!");
                            Console.ReadKey();
                            goto case 6;
                        }
                        break;
                    case 8:
                        if (ListCid.Count != 0)
                        {
                            ind = 0;
                            Cidade cidalt = new Cidade();
                            Cidade ciexcl = null;
                            Console.WriteLine("\n\n");
                            Console.WriteLine("\t-------------------------------------");
                            Console.Write("\n\t Digite o código da Cidade para Alterar: ");
                            cdgo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\t-------------------------------------");
                            for (int i = 0; i < ListCid.Count; i++)
                            {
                                if (cdgo == ListCid[i].cod)
                                {
                                    ciexcl = ListCid[i];
                                    cidalt.cod = ListCid[i].cod;
                                    Console.Write("\tDigite o Nome da Cidade: ");
                                    cidalt.nome = Console.ReadLine();
                                    Console.Write("\tDigite o UF da Cidade: ");
                                    cidalt.UF = Console.ReadLine();
                                    Console.WriteLine("\n\n\tCadastro Efetuado com Sucesso!!");
                                    ind = i;
                                    break;
                                }

                            }
                            if (ciexcl != null)
                            {
                                ListCid.Insert(ind, cidalt);
                                ciexcl.Excluir(ref ListCid);
                                Console.WriteLine("\n\n\t Cadastro Alterado com Sucesso!!");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("\n\n\t Cidade não Encontrada!");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\n\t Cidade não localizada para Alteração");
                            Console.ReadKey();
                        }
                        break;
                    case 9:
                        Cidade.Listar(ListCid);
                        Console.ReadKey();
                        break;
                    case 0:
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("\n\n\t Opção Inválida!");
                        Console.ReadKey();
                        break;
                }
            } while (!sair);
        }
    }
}
