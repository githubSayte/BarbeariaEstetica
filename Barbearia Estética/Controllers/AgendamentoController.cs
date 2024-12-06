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
                 new SelectListItem { Value = "1", Text = "Designer de cabelos masculino: com cortes ou penteados" },
                 new SelectListItem { Value = "2", Text = "Corte de Cabelo padrão: na máquina ou na tesoura" },
                  new SelectListItem { Value = "3", Text = "Coloração de Cabelo: com estilo ou padrão" },
                 new SelectListItem { Value = "4", Text = "Barba e Bigode: corte, realce e Coloração" },
                  new SelectListItem { Value = "5", Text = "Barba Expressa: na máquina e na navalha" },
                 new SelectListItem { Value = "6", Text = "Pacote de Manutenção Mensal: pagamento uma vez ao mês" }
            };

            // Passar a lista para a View usando ViewBag
            ViewBag.lstTipoServico = new SelectList(tipoServico, "Value", "Text");

            // Chama o método ListarNomesAgendamentos para obter a lista de usuários
            var usuarios = _agendamentoRepositorio.ListarNomesAgendamentos();

            if (usuarios != null && usuarios.Any())
            {
                // Cria a lista de SelectListItem
                var selectList = usuarios.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),  // O valor do item será o ID do usuário
                    Text = u.Nome             // O texto exibido será o nome do usuário
                }).ToList();

                // Passa a lista para o ViewBag para ser utilizada na view
                ViewBag.Usuarios = selectList;
            }
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
        public IActionResult InserirAgendamento(DateTime dtHoraAgendamento, DateOnly dataAgendamento, TimeOnly horario, int fkUsuarioId, int fkServicoId)
        {
            try
            {
                // Chama o método do repositório que realiza a inserção no banco de dados
                var resultado = _agendamentoRepositorio.InserirAgendamento(dtHoraAgendamento, dataAgendamento, horario, fkUsuarioId, fkServicoId);

                // Verifica o resultado da inserção
                if (resultado)
                {
                    return Json(new { success = true, message = "Atendimento inserido com sucesso!" });
                }
                else
                {
                    return Json(new { success = false, message = "Erro ao inserir o atendimento. Tente novamente." });
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro inesperado, captura e exibe o erro
                return Json(new { success = false, message = "Erro ao processar a solicitação. Detalhes: " + ex.Message });
            }
        }
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
       public IActionResult ConsultarAgendamento(string data)
        {

            var agendamento = _agendamentoRepositorio.ConsultarAgendamento(data);

            if (agendamento != null)
            {
                return Json(agendamento);
            }
            else
            {
                return NotFound();
            }

        }
       [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
