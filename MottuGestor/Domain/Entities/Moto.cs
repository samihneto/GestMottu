using _2TDSPG.API.Domain.Enums;

namespace _2TDSPG.API.Domain.Entity
{
    public class Moto
    {
        public Guid MotoId { get; private set; }
        public string Placa { get; private set; }
        public string Modelo { get; private set; }
        public string Marca { get; private set; }
        public string RfidTag { get; private set; }
        public int Ano { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Problema { get; private set; }
        public string Localizacao { get; private set; }
        public StatusMoto Status { get; private set; }

        // Construtor que garante que RFID e demais dados sejam fornecidos ao criar
        public Moto(string rfidTag, string placa, string modelo, string marca, int ano, string problema = null, string localizacao = null)
        {
            MotoId = Guid.NewGuid();
            RfidTag = ValidateRfid(rfidTag);
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            Ano = ano;
            Problema = problema;
            Localizacao = localizacao;
            DataCadastro = DateTime.UtcNow;
            Status = StatusMoto.Disponivel;
        }

        // Validação simples para RFID
        private string ValidateRfid(string rfid)
        {
            if (string.IsNullOrWhiteSpace(rfid))
                throw new ArgumentException("RfidTag não pode ser vazia.");

            return rfid;
        }

        // Construtor vazio para EF
        public Moto() { }

        // Métodos para alterar campos, se quiser controlar modificações:
        public void AtualizarLocalizacao(string novaLocalizacao)
        {
            Localizacao = novaLocalizacao;
        }

        public void AtualizarProblema(string novoProblema)
        {
            Problema = novoProblema;
        }

        public void AlterarStatus(StatusMoto novoStatus)
        {
            Status = novoStatus;
        }
    }
}
