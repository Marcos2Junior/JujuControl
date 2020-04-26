using System;

namespace JujuControl.Data.Models.dbModels
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }

        public Contato()
        {
        }

        public Contato(int id, string nome, string telefone, string email, string assunto, string mensagem, DateTime data)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Assunto = assunto;
            Mensagem = mensagem;
            Data = data;
        }
    }
}
