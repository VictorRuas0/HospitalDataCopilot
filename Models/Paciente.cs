using System;
namespace HospitalDataCopilot.Models
{
    public class Paciente    
    {
        public int Id {  get; set; }
        public string Nome {  get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF {  get; set; }

    }
}
