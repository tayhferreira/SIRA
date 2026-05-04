using System;

namespace SIRA.Domain
{
    public class Instituicao : Usuario
    {
        public string RegistroSocial { get; private set; }

        public Instituicao(int id, string nome, string email, string senha, string registroSocial) 
            : base(id, nome, email, senha)
        {
            RegistroSocial = registroSocial;
        }

        public void SolicitarReserva(Alimento alimento)
        {
            if (alimento.Status == "Disponível")
            {
                alimento.AtualizarStatus("Reservado");
                Console.WriteLine($"[LOG]: Instituição {Nome} reservou o item {alimento.Descricao} com sucesso.");
            }
            else
            {
                Console.WriteLine($"[LOG]: O item {alimento.Descricao} não está disponível para reserva.");
            }
        }
    }
}