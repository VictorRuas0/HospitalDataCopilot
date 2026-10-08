using System;
using HospitalDataCopilot.Models;

namespace HospitalDataCopilot.Services
{
    public class PacienteService
    {
        private List<Paciente> pacientes = new List<Paciente>();

        private int proximoId = 1;

        public void CadastrarPaciente(Paciente paciente)
        {
            paciente.Id = proximoId;
            proximoId++;

            pacientes.Add(paciente);
        }

        public List<Paciente> ListarPacientes()
        {
            return pacientes;
        }

        public Paciente? BuscarPorId(int id)
        {
            return pacientes.FirstOrDefault(p => p.Id == id);
        }
        public Paciente CriarPaciente()
        {
            Paciente paciente = new Paciente();

            Console.Write("Digite o nome do paciente: ");
            string nome = Console.ReadLine() ?? "";

            paciente.Nome = nome;
        }
    }
}