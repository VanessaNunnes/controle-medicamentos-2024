
using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;
using System;

namespace ControleMedicamentos.ConsoleApp
{
    public class TelaRequisicao
    {
        private readonly RepositorioMedicamento repositorioMedicamento;
        private readonly RepositorioPaciente repositorioPaciente;
        private readonly RepositorioRequisicao repositorioRequisicao;

        public TelaRequisicao(RepositorioMedicamento repositorioMedicamento, RepositorioPaciente repositorioPaciente, RepositorioRequisicao repositorioRequisicao)
        {
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioRequisicao = repositorioRequisicao;
        }

        public void CadastrarRequisicao()
        {
            Console.WriteLine("Cadastrando Requisição...");

            Console.WriteLine();

            Console.Write("Digite o ID do medicamento: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            // Verifica se o repositório de medicamentos foi inicializado corretamente
            if (repositorioMedicamento == null)
            {
                Console.WriteLine("Erro: Repositório de medicamentos não foi inicializado corretamente.");
                return;
            }

            Console.WriteLine($"Procurando medicamento com ID '{idMedicamento}'...");

            Medicamento medicamento = repositorioMedicamento.SelecionarMedicamentoPorId(idMedicamento);
            if (medicamento == null)
            {
                Console.WriteLine($"O medicamento com o ID '{idMedicamento}' não foi encontrado no sistema.");
                Console.ReadLine();
                return;
            }

            Console.Write("Digite o nome do paciente: ");
            string nomePaciente = Console.ReadLine();

            Paciente paciente = repositorioPaciente.SelecionarPacientePorNome(nomePaciente);
            if (paciente == null)
            {
                Console.WriteLine("Paciente não encontrado.");
                Console.ReadLine();
                return;
            }

            Console.Write("Digite a quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a data de validade (DD/MM/AAAA): ");
            DateOnly dataValidade = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            Requisicao requisicao = new Requisicao(medicamento, paciente, quantidade, dataValidade);

            repositorioRequisicao.CadastrarRequisicao(requisicao);
        }


        public char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("1 - Cadastrar Requisição");
            Console.WriteLine("2 - Editar Requisição");
            Console.WriteLine("3 - Excluir Requisição");
            Console.WriteLine("4 - Visualizar Requisiçãos");

            Console.WriteLine("S - Voltar");


            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Console.ReadLine()[0];

            return operacaoEscolhida;
        }


        public void VisualizarRequisicoes()
        {
            Console.WriteLine("{0, -15} | {1, -15} | {2, -15} | {3, -15} | {4, -10} |",
                "Medicamento", "Paciente", "CPF", "Endereço", "Quantidade");

            Requisicao[] requisicoes = repositorioRequisicao.SelecionarRequisicao();

            foreach (Requisicao requisicao in requisicoes)
            {
                if (requisicao == null)
                    continue;

                Console.WriteLine("{0, -15} | {1, -15} | {2, -15} | {3, -15} | {4, -10} |",
                    requisicao.Medicamento, requisicao.Paciente.Nome, requisicao.Paciente.Cpf,
                    requisicao.Paciente.Endereco, requisicao.Quantidade);
            }

            Console.ReadLine();
        }

    }

}