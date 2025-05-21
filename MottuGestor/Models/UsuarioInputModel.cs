namespace MottuGestor.Models
{
    public class UsuarioInputModel
    {
        public string Nome { get; internal set; }
        public string Email { get; internal set; }
        public string SenhaHash { get; internal set; }
    }
}