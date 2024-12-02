﻿using System;
using System.Collections.Generic;

namespace Barbearia_Estética.ORM;

public partial class TbServico
{
    public int Id { get; set; }

    public string TipoServico { get; set; } = null!;

    public decimal Valor { get; set; }

    public virtual ICollection<TbAgendamento> TbAgendamentos { get; set; } = new List<TbAgendamento>();
}
