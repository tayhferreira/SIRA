using System;

namespace SIRA.Domain
{
    public class Transacao
    {
        public int Id { get; private set; }
        public DateTime DataHora { get; private set; }
        public string StatusTransacao { get; private set; }
        public Alimento Item { get; private set; }

        public Transacao(int id, Alimento item)
        {
            Id = id;
            Item = item;
            DataHora = DateTime.Now;
            StatusTransacao = "Pendente";
        }

        public void ConfirmarRetirada()
        {
            StatusTransacao = "Concluída";
            Item.AtualizarStatus("Entregue");
            Console.WriteLine($"[SISTEMA]: Transação {Id} finalizada. Alimento entregue.");
        }

        public string GerarRecibo()
        {
            return $"--- RECIBO SIRA ---\nID: {Id}\nItem: {Item.Descricao}\nData: {DataHora}\nStatus: {StatusTransacao}\n-------------------";
        }
    }
}