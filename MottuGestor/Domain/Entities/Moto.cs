namespace GestMottu.API.Domain.Entities
{
    public class Moto
    {
        public int Id { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Rfid { get; set; } = string.Empty;
        public string PosicaoAtual { get; set; } = string.Empty;
    }
}