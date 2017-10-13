using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BDProjeto.Dominio
{
    public class Usuario
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Preencha o nome do Usuário")]
        public string Nome { get; set; }

        [DisplayName("Cargo")]
        [Required(ErrorMessage = "Preencha o cargo")]
        public string Cargo { get; set; }

        [DisplayName("Data")]
        [Required(ErrorMessage = "Preencha a data de cadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
    }
}
