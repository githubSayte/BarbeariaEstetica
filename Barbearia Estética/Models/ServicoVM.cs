﻿namespace Barbearia_Estética.Models
{
    public class ServicoVM
    {
        public int Id { get; set; }

        public string TipoServico { get; set; } = null!;

        public decimal Valor { get; set; }
    }
}
