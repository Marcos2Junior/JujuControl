using System;

namespace JujuControl.Data.Models.dbModels
{
    public class Permissao
    {
        public int Id { get; set; }
        public string Chave { get; set; }
        public Perfil Perfil { get; set; }

        /// <summary>
        /// Validade em dias que a chave será valida após criada
        /// </summary>
        public int Validade { get; set; }
        public DateTime Data { get; set; }

        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        

        public Permissao()
        {
        }

        public Permissao(int id, string chave, Perfil perfil, int validade, DateTime data, Usuario usuario)
        {
            Id = id;
            Chave = chave;
            Perfil = perfil;
            Validade = validade;
            Data = data;
            Usuario = usuario;
        }
    }
}
