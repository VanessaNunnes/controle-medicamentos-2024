

using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;


namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class RepositorioRequisicao
    {
        public RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();
        Requisicao[] requisicoes = new Requisicao[100];
        public void CadastrarRequisicao(Requisicao requisicao)
        {
            Console.WriteLine("Cadastrando Requisição...");

            Console.WriteLine();

            Console.Write("Digite o ID do medicamento: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamento = repositorioMedicamento.SelecionarMedicamentoPorId(idMedicamento);
            if (medicamento == null)
            {
                Console.WriteLine($"O medicamento com o ID '{idMedicamento}' não foi encontrado no sistema.");
                return;
            }
        }

            public void Registrar(Requisicao requisicao)
        {
            for (int i = 0; i < requisicoes.Length; i++)
            {
                if (requisicoes[i] != null)
                    continue;
                else
                {
                    requisicoes[i] = requisicao;
                    break;
                }
            }
        }

        public Requisicao[] SelecionarRequisicao()
        {
            Requisicao[] requisicoesExistentes = new Requisicao[100];

            int contadorElementosExistentes = 0;

            for (int i = 0; i < requisicoes.Length; i++)
            {
                if (requisicoes[i] == null)
                    continue;
                else
                {
                    requisicoesExistentes[i] = requisicoes[i];
                    contadorElementosExistentes++;
                }
            }

            return requisicoesExistentes;
        }
    }
}
