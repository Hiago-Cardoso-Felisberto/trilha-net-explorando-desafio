using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Pessoa> hospedes = new List<Pessoa>();
List<Suite> suites = new List<Suite>();

int opcao = 0;
do
{
    Console.WriteLine("Bem vindo ao nosso Hotel, por favor, selecione uma das nossa opções de menu: \n" +
    "1 - Cadastrar hospedes \n 2 - Cadastrar Suites \n 3 - Fazer reserva \n 4 - Sair");
    opcao = Convert.ToInt32(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            Console.WriteLine("Informe o nome do hóspede:");
                string nome = Console.ReadLine();
            hospedes.Add(new Pessoa { Nome = nome });
            break;
        case 2:
            Console.Write("Digite o tipo da suíte: ");
                string TipoSuite = Console.ReadLine();
            Console.Write("Digite a capacidade: ");
                int Capacidade = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor da diária: ");
                decimal ValorDiaria = decimal.Parse(Console.ReadLine());
            suites.Add(new Suite(TipoSuite, Capacidade, ValorDiaria));
            break;
        case 3:
            Console.Write("Em qual suíte deseja permanecer?");
            int i = 1;
            foreach (Suite suite in suites)
            {
                Console.WriteLine($"\nSuite{i}: {suite.TipoSuite}\n Capacidade: {suite.Capacidade}\n Valor da diária: {suite.ValorDiaria}");
                i++;
            }
                int opcaoSuite = Convert.ToInt32(Console.ReadLine());
                if (opcaoSuite >= 1 && opcaoSuite <= suites.Count)
                {
                    Suite selecionada = suites[opcaoSuite - 1];

                        if (selecionada.Capacidade >= hospedes.Count)
                        {
                            Console.WriteLine($"Suíte '{selecionada.TipoSuite}' selecionada com sucesso!");

                            Console.Write("Quantos dias deseja reservar? ");
                            int diasReservados = Convert.ToInt32(Console.ReadLine());

                            Reserva reserva = new Reserva(diasReservados);
                            reserva.CadastrarSuite(selecionada);
                            reserva.CadastrarHospedes(hospedes);

                            Console.WriteLine($"Reserva realizada com sucesso para {reserva.ObterQuantidadeHospedes()} hóspedes na suíte {selecionada.TipoSuite} por {diasReservados} dias.");
                            Console.WriteLine($"Valor total da reserva: {reserva.CalcularValorDiaria():C}");
                        }
                        else
                        {
                            Console.WriteLine("Essa suíte não comporta o número de pessoas. Tente outra.");
                        }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }
            break;
        case 4:
            Console.WriteLine("Saindo do sistema...");
            break;
        default:
            Console.WriteLine("Opção inválida, por favor, tente novamente.");
            break;    
    }

} while (opcao != 4);