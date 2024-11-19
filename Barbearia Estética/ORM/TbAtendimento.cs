﻿using System;
using System.Collections.Generic;

namespace Barbearia_Estética.ORM;

public partial class TbAtendimento
{
    public int Id { get; set; }

    public DateOnly DtHoraAgendamento { get; set; }

    public DateOnly DataAtendimento { get; set; }

    public TimeOnly Horario { get; set; }

    public int FkUsuarioId { get; set; }

    public int FkServicoId { get; set; }
}
