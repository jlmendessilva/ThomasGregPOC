using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebConsumoAPI.Models
{
    public class ClienteModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[]? Logotipo { get; set; }

        [BindProperty, Display(Name = "Logotipo")] 
        public IFormFile Upload { get; set; }

        public ICollection<LogradouroModel> Logradouros { get; set; } 
    }
}
