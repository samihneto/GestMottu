using MottuGestor.Domain.Enums;

namespace MottuGestor.Domain.Entities
{
    public class Moto
    {
        public int Id { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Cor { get; set; } = string.Empty;

        public StatusMoto Status { get; set; }
    }
}