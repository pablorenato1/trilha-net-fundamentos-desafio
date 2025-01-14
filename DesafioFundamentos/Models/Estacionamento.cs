using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();


        private Boolean VerificarPlacaSistema(string placa)
        {
            return true;
        }
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo no formato para estacionar, utilizar o formato 'XXX-0000':");
            string placa = Console.ReadLine();

            // TODO: Verificação na Placa, para ver se esta no padrão "XXX-NNNN"    
            Regex regex = new Regex(@"^[a-z]{3}-\d{4}$");
            if (regex.IsMatch(placa))
            { 
                veiculos.Add(placa); // Adicionando um novo veiculo
                Console.WriteLine("Veículo cadastrado com Sucesso!");
            }
            else 
            { // Não está no Padrão de 3 letras - 4 números
                Console.WriteLine("Placa inserida no formato Invalido, por favor utilizar o Formato 'XXX-0000'(3 Letras - 4 Números)");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover ou 'Sair' para Cancelar:");
            string placa = Console.ReadLine();

            if (placa.ToUpper() == "SAIR") {
                return;
            }

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                string horasDecorridaString = Console.ReadLine();            

                decimal valorTotal = 0; 
                if (int.TryParse(horasDecorridaString, out int horas)) // Tentar converter para decimal
                {
                    valorTotal = precoInicial+(horas * precoPorHora);
                    veiculos.Remove(placa); // Removendo um veiculo valido

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                { // Caso seja outro formato e não dê certo a conversão
                    Console.WriteLine($"O valor inserido não é valor válido, por favor repita a ação utilizando somente números");
                }

            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("=============================");
                Console.WriteLine("Os veículos estacionados são:");
                Console.WriteLine("-----------------------------");
                foreach (string placas in veiculos)
                {
                    Console.WriteLine(placas);
                }
                Console.WriteLine("=============================");
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
