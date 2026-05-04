using System;

namespace SIRA.Domain
{
    public class Estabelecimento : Usuario
    {
        public string CNPJ { get; private set; }
        public string Endereco { get; private set; }

        public Estabelecimento(int id, string nome, string email, string senha, string cnpj, string endereco) 
            : base(id, nome, email, senha)
        {
            CNPJ = cnpj;
            Endereco = endereco;
        }

        public void PostarAlimento(Alimento alimento)
        {
            Console.WriteLine($"[LOG]: O estabelecimento {Nome} (CNPJ: {CNPJ}) disponibilizou o item: {alimento.Descricao}.");
        }
    }
}