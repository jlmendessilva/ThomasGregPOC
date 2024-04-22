namespace ClienteAPI.Models
{
    public class ClienteModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[]? Logotipo { get; set; } // Use byte array para armazenar logotipos
        public ICollection<LogradouroModel> Logradouros { get; set; } // Relação um-para-muitos
    }
}
