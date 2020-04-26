using System;

namespace JujuControl.Data.Models.dbModels
{
    public class Imagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Posicao { get; set; }
        public DateTime Data { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public Imagem()
        {
        }

        public Imagem(int id, string nome, int posicao, DateTime data, Usuario usuario)
        {
            Id = id;
            Nome = nome;
            Posicao = posicao;
            Data = data;
            Usuario = usuario;
        }
    }
}
