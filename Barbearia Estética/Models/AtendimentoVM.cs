namespace Barbearia_Estética.Models
{
    public class AtendimentoVM
    {
        public int Id { get; set; }

        public DateOnly DtHoraAgendamento { get; set; }

        public DateOnly DataAtendimento { get; set; }

        public TimeOnly Horario { get; set; }
    }
}
