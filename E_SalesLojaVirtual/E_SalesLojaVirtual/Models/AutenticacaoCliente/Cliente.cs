using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace E_SalesLojaVirtual.Models.AutenticacaoCliente
{
    public class Cliente
    {
        public int id { get; set; }
        [Required]
        [Display(Name="Nome")]
        public string nome { get; set; }
        [Required]
        [Display(Name = "Sobrenome")]
        public string sobrenome { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Senha")]
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres")]
        public string senha { get; set; }
        [Required]
        [Compare("senha", ErrorMessage ="As senhas não conferem")]
        [Display(Name = "Confirmar Senha")]
        public string confirmarSenha { get; set; }
        [Required]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }
    }
}