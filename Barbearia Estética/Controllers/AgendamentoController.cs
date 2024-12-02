using Barbearia_Estética.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiteAgendamento.Controllers;
using SiteAgendamento.Repositorio;
using System.Diagnostics;

namespace Barbearia_Estética.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly AgendamentoRepositorio _agendamentoRepositorio;
        private readonly ILogger<ServicoController> _logger;

        public AgendamentoController(AgendamentoRepositorio agendamentoRepositorio, ILogger<ServicoController> logger)
        {
            _agendamentoRepositorio = agendamentoRepositorio;
            _logger = logger;
        }
        public IActionResult Index()
        {
            // Criar a lista de SelectListItems, onde o 'Value' será o 'Id' e o 'Text' será o 'TipoServico'
            List<SelectListItem> tipoServico = new List<SelectListItem>
             {
                 new SelectListItem { Value = "0", Text = "Designer de cabelos masculino: com cortes ou penteados" },
                 new SelectListItem { Value = "1", Text = "Corte de Cabelo padrão: na máquina ou na tesoura" },
                  new SelectListItem { Value = "2", Text = "Coloração de Cabelo: com estilo ou padrão" },
                 new SelectListItem { Value = "3", Text = "Barba e Bigode: corte, realce e Coloração" },
                  new SelectListItem { Value = "4", Text = "Barba Expressa: na máquina e na navalha" },
                 new SelectListItem { Value = "5", Text = "Pacote de Manutenção Mensal: pagamento uma vez ao mês" }
            };

            // Passar a lista para a View usando ViewBag
            ViewBag.lstTipoServico = new SelectList(tipoServico, "Value", "Text");
            var atendimentos = _agendamentoRepositorio.ListarAgendamentos();
            return View(atendimentos);
        }
        public IActionResult AgendamentoUsuario()
        {
            return View();
        }
        public IActionResult CadastroAgendamento()
        {
            return View();
        }

        // Método para inserir um novo agendamento
        public IActionResult InserirAgendamento(DateTime dtHoraAgendamento, DateOnly dataAgendamento, TimeOnly horario, int fkUsuarioId, int fkServicoId)
        {
            try
            {
                // Chama o método do repositório que realiza a inserção no banco de dados
                var resultado = _agendamentoRepositorio.InserirAgendamento(dtHoraAgendamento, dataAgendamento, horario, fkUsuarioId, fkServicoId);

                // Verifica o resultado da inserção
                if (resultado)
                {
                    // Se o resultado for verdadeiro, significa que o agendamento foi inserido com sucesso
                    return Json(new { success = true, message = "Agendamento inserido com sucesso!" });
                }
                else
                {
                    // Se o resultado for falso, significa que houve um erro ao tentar inserir o agendamento
                    return Json(new { success = false, message = "Erro ao inserir o agendamento. Tente novamente." });
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro inesperado, captura e exibe o erro
                return Json(new { success = false, message = "Erro ao processar a solicitação. Detalhes: " + ex.Message });
            }
        }

        // Método para atualizar um agendamento
        public IActionResult AtualizarAgendamento(int id, DateTime dtHoraAgendamento, DateOnly dataAgendamento, TimeOnly horario, int fkUsuarioId, int fkServicoId)
        {
            try
            {
                // Chama o repositório para atualizar o agendamento
                var resultado = _agendamentoRepositorio.AtualizarAgendamento(id, dtHoraAgendamento, dataAgendamento, horario, fkUsuarioId, fkServicoId);

                if (resultado)
                {
                    return Json(new { success = true, message = "Agendamento atualizado com sucesso!" });
                }
                else
                {
                    return Json(new { success = false, message = "Erro ao atualizar o agendamento. Verifique se o agendamento existe." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Erro ao processar a solicitação. Detalhes: " + ex.Message });
            }
        }

        // Método para excluir um agendamento
        public IActionResult ExcluirAgendamento(int id)
        {
            try
            {
                // Chama o repositório para excluir o agendamento
                var resultado = _agendamentoRepositorio.ExcluirAgendamento(id);

                if (resultado)
                {
                    return Json(new { success = true, message = "Agendamento excluído com sucesso!" });
                }
                else
                {
                    return Json(new { success = false, message = "Erro ao excluir o agendamento. Verifique se o agendamento existe." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Erro ao processar a solicitação. Detalhes: " + ex.Message });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
