namespace Barbearia_Estética.Models

{
    public class AgendamentoVM
    {
        public int Id { get; set; }

        public DateOnly DtHoraAgendamento { get; set; }

        public DateOnly DataAgendamento { get; set; }

        public TimeOnly Horario { get; set; }

        public int FkUsuarioId { get; set; }

        public int FkServicoId { get; set; }

    }
}
