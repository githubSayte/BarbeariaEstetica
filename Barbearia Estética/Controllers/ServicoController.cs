using Barbearia_Estética.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiteAgendamento.Repositorio;
using System.Diagnostics;

namespace SiteAgendamento.Controllers
{
    public class ServicoController : Controller
    {
        private readonly ServicoRepositorio _servicoRepositorio;
        private readonly ILogger<ServicoController> _logger;

        public ServicoController(ServicoRepositorio servicoRepositorio, ILogger<ServicoController> logger)
        {
            _servicoRepositorio = servicoRepositorio;
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Cadastro()
        {
            return View();

        }

        public IActionResult Index()
        {

            // Chama o método ListarNomesAgendamentos para obter a lista de usuários
            var nomeServicos = _servicoRepositorio.ListarNomesServicos();

            if (nomeServicos != null && nomeServicos.Any())
            {
                // Cria a lista de SelectListItem
                var selectList = nomeServicos.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),  // O valor do item será o ID do usuário
                    Text = u.TipoServico             // O texto exibido será o nome do usuário
                }).ToList();

                // Passa a lista para o ViewBag para ser utilizada na view
                ViewBag.Servicos = selectList;
            }

            var Servicos = _servicoRepositorio.ListarServicos();
            return View(Servicos);
        }

        // Método para inserir um novo serviço
        public IActionResult InserirServico(string TipoServico, decimal Valor)
        {
            try
            {
                // Chama o método do repositório que realiza a inserção no banco de dados
                var resultado = _servicoRepositorio.InserirServico(TipoServico, Valor);

                // Verifica o resultado da inserção
                if (resultado)
                {
                    // Se o resultado for verdadeiro, significa que o serviço foi inserido com sucesso
                    return Json(new { success = true, message = "Serviço inserido com sucesso!" });
                }
                else
                {
                    // Se o resultado for falso, significa que houve um erro ao tentar inserir o serviço
                    return Json(new { success = false, message = "Erro ao inserir o serviço. Tente novamente." });
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro inesperado, captura e exibe o erro
                return Json(new { success = false, message = "Erro ao processar a solicitação. Detalhes: " + ex.Message });
            }
        }

        // Método para atualizar um serviço
        public IActionResult AtualizarServico(int id, string TipoServico, decimal Valor)
        {
            try
            {
                // Chama o repositório para atualizar o serviço
                var resultado = _servicoRepositorio.AtualizarServico(id, TipoServico, Valor);

                if (resultado)
                {
                    return Json(new { success = true, message = "Serviço atualizado com sucesso!" });
                }
                else
                {
                    return Json(new { success = false, message = "Erro ao atualizar o serviço. Verifique se o serviço existe." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Erro ao processar a solicitação. Detalhes: " + ex.Message });
            }
        }

        // Método para excluir um serviço
        public IActionResult ExcluirServico(int id)
        {
            try
            {
                // Chama o repositório para excluir o serviço
                var resultado = _servicoRepositorio.ExcluirServico(id);

                if (resultado)
                {
                    return Json(new { success = true, message = "Serviço excluído com sucesso!" });
                }
                else
                {
                    return Json(new { success = false, message = "Erro ao excluir o serviço. Verifique se o serviço existe." });
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
