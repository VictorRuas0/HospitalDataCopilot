using HospitalDataCopilot.Models;
using HospitalDataCopilot.Services;

PacienteService pacienteService = new PacienteService();

bool executando = true;

while (executando)
{
    Console.WriteLine();
    Console.WriteLine("===== HOSPITAL DATA COPILOT =====");
    Console.WriteLine("1 - Cadastrar paciente");
    Console.WriteLine("2 - Listar pacientes");
    Console.WriteLine("3 - Buscar paciente por ID");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");

    string opcao = Console.ReadLine() ?? "";

    switch (opcao)
    {
        case "1":
            Console.Write("Digite o nome do paciente: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine() ?? "";

            DateTime dataNascimento = default;
            bool dataValida = false;

            while (!dataValida)
            {
                Console.Write("Digite a data de nascimento (dd/MM/yyyy): ");
                string dataDigitada = Console.ReadLine() ?? "";

                if (DateTime.TryParse(dataDigitada, out dataNascimento))
                {
                    dataValida = true;
                }
                else
                {
                    Console.WriteLine("Data inválida. Tente novamente.");
                }
            }

            Paciente paciente = new Paciente();

            paciente.Nome = nome;
            paciente.CPF = cpf;
            paciente.DataNascimento = dataNascimento;

            pacienteService.CadastrarPaciente(paciente);

            Console.WriteLine("Paciente cadastrado com sucesso!");
            break;

        case "2":
            List<Paciente> pacientes = pacienteService.ListarPacientes();

            if (pacientes.Count == 0)
            {
                Console.WriteLine("Nenhum paciente registrado.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("===== PACIENTES =====");

                foreach (Paciente pacienteCadastrado in pacientes)
                {
                    Console.WriteLine($"ID: {pacienteCadastrado.Id}");
                    Console.WriteLine($"Nome: {pacienteCadastrado.Nome}");
                    Console.WriteLine($"CPF: {pacienteCadastrado.CPF}");
                    Console.WriteLine($"Nascimento: {pacienteCadastrado.DataNascimento:dd/MM/yyyy}");
                    Console.WriteLine("---------------------------");
                }
            }

            break;

        case "3":
            Console.Write("Digite o ID do paciente: ");
            string idDigitado = Console.ReadLine() ?? "";

            int id;

            if (int.TryParse(idDigitado, out id))
            {
                // aqui vamos continuar a busca
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }

            Paciente? pacienteEncontrado = pacienteService.BuscarPorId(id);

            if (pacienteEncontrado != null)
            {
                Console.WriteLine();
                Console.WriteLine("Paciente encontrado:");
                Console.WriteLine($"ID: {pacienteEncontrado.Id}");
                Console.WriteLine($"Nome: {pacienteEncontrado.Nome}");
                Console.WriteLine($"CPF: {pacienteEncontrado.CPF}");
                Console.WriteLine($"Nascimento: {pacienteEncontrado.DataNascimento:dd/MM/yyyy}");
            }
            else
            {
                Console.WriteLine("Paciente não encontrado.");
            }

            break;

        case "0":
            executando = false;
            Console.WriteLine("Sistema encerrado.");
            break;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}