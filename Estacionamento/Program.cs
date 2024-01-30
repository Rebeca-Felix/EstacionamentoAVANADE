using System;
using System.Collections.Generic;

class Program
{
    static Chave <string, DateTime> veiculos = new Chave <string, DateTime>();
    //Dicionário para criar chaves de valor, no caso veiculos, dessa forma se cria propriedades dentro da keys-value

    static void Main()
{
    string entradaCarro;

    do
    {
        MostrarMenu();
        Console.Write("Escolha uma opção: ");
        entradaCarro = Console.ReadLine(); //String de entrada para cadastro do Menu

        switch (entradaCarro)
        {
            case "1":
                CadastrarVeiculo();
                break;
            case "2":
                ListarVeiculosPorHora();
                break;
            case "3":
                SaidaVeiculo();
                break;
            case "4":
                Console.WriteLine("Finalizado. Até Breve!");
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }

    } while (entradaCarro != "4"); //Opções permitidas de 1 a 4
}


    static void MostrarMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Cadastro da Placa do Veículo");
        Console.WriteLine("2. Lista de carros");
        Console.WriteLine("3. Saída do carro e pagamento");
        Console.WriteLine("4. Sair do programa");
    }

    static void CadastrarVeiculo()
    {
        Console.Write("Digite a placa do veículo: ");
        string placa = Console.ReadLine();

        if (veiculos.ContainsKey(placa))
        {
            Console.WriteLine("Veículo já cadastrado.");
        }
        else
        {
            veiculos.Add(placa, DateTime.Now);
            Console.WriteLine($"Veículo {placa} cadastrado com sucesso!");
        }
    }

    static void ListarVeiculosPorHora()
    {
        Console.WriteLine("Lista de carros cadastrados:");
        foreach (var veiculo in veiculos)
        {
            Console.WriteLine($"Placa: {veiculo.Key}, Data e Hora: {veiculo.Value}");
        }
    }

    static void SaidaVeiculo()
    {
        Console.Write("Digite a placa do veículo que está saindo: ");
        string placa = Console.ReadLine();

        if (veiculos.ContainsKey(placa))
        {
            DateTime horaEntrada = veiculos[placa];
            DateTime horaSaida = DateTime.Now;
            TimeSpan tempoEstacionado = horaSaida - horaEntrada;

            Double valorAPagar = tempoEstacionado.TotalMinutes*0.50; //O valor do tempo em minuto pode ser modificado.
            string totalPagar = valorAPagar.ToString("F2"); //Conversão de double para String para ter apenas 2 casas depois da vírgula
            
            Console.WriteLine($"Valor a pagar: R$ {totalPagar}");

            veiculos.Remove(placa);
        }
        else
        {
            Console.WriteLine("Veículo não encontrado.");
        }
    }

}
