using _2TDSPG.API.Domain.Enums;

namespace _2TDSPG.API.Domain.Entity
{
    public class Moto
    {
        public Guid MotoId { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string RfidTag { get; private set; }
        public int Ano { get; set; }
        public DateTime DataCadastro { get; private set; }
        public string Problema { get; set; }
        public string Localizacao { get; set; }
        public StatusMoto Status { get; set; }

        public Moto(string rfidTag)
        {
            RfidTag = rfidTag;
            DataCadastro = DateTime.UtcNow;
            Status = StatusMoto.Disponivel; // Valor padrão
        }

        // Construtor sem parâmetros, exigido pelo EF
        public Moto() { }
    }
}
