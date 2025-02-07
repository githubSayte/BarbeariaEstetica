
using Barbearia_Estética.Models;
using Barbearia_Estética.ORM;
using Highsoft.Web.Mvc.Charts;
using System.Collections.Generic;


namespace SiteAgendamento.Repositorio
{
    public class DashboardRepositorio
    {

        private BdEsteticaContext _context;

        public DashboardRepositorio(BdEsteticaContext context)
        {
            _context = context;
        }

        public List<LineSeriesData> ObterDadosGrafico()
        {
            return new List<LineSeriesData>
            {
                new LineSeriesData { Y = 10 },
                new LineSeriesData { Y = 25 },
                new LineSeriesData { Y = 35 },
                new LineSeriesData { Y = 50 }
            };
        }


    }
}

