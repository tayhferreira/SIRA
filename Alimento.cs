using System;

namespace SIRA.Domain
{
    public class Alimento
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public double Quantidade { get; private set; }
        public string Status { get; private set; }

        public Alimento(int id, string descricao, DateTime dataValidade, double quantidade)
        {
            if (dataValidade < DateTime.Now.Date) throw new ArgumentException("Não é possível cadastrar alimentos já vencidos.");
            
            Id = id;
            Descricao = descricao;
            DataValidade = dataValidade;
            Quantidade = quantidade;
            Status = "Disponível";
        }

        public void AtualizarStatus(string novoStatus)
        {
            Status = novoStatus;
        }

        public bool VerificarVencimento()
        {
            return DataValidade < DateTime.Now.Date;
        }
    }
}