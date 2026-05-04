using System;

namespace SIRA.Domain
{
    public abstract class Usuario
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        private string _senha;

        protected Usuario(int id, string nome, string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("O nome é obrigatório.");
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("O e-mail é obrigatório.");

            Id = id;
            Nome = nome;
            Email = email;
            _senha = senha; 
        }

        public bool Autenticar(string email, string senha)
        {
            return Email.Equals(email, StringComparison.OrdinalIgnoreCase) && _senha == senha;
        }

        public virtual void AtualizarPerfil(string novoNome)
        {
            if (!string.IsNullOrWhiteSpace(novoNome))
            {
                Nome = novoNome;
            }
        }
    }
}