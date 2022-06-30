using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeuSiteMVC.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o e-mail")]
        [EmailAddress(ErrorMessage ="O e-mail informado não é válido")]        
        public string Email {get;set;}
        [Required(ErrorMessage ="Digite o celular")]
        [Phone(ErrorMessage =" O celular informado não é válido!")]        
        public string Celular { get; set; }
        
    }
}
