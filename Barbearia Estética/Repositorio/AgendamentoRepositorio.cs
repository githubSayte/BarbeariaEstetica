using Barbearia_Estética.Models;
using Barbearia_Estética.ORM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

namespace SiteAgendamento.Repositorio
{
    public class AgendamentoRepositorio
    {
        private readonly BdEsteticaContext _context;

        public AgendamentoRepositorio(BdEsteticaContext context)
        {
            _context = context;
        }

        // Inserir Agendamento
        public bool InserirAgendamento(DateTime dtHoraAgendamento, DateOnly dataAgendamento, TimeOnly horario, int fkUsuarioId, int fkServicoId)
        {
            try
            {
                TbAgendamento agendamento = new TbAgendamento
                {
                    DtHoraAgendamento = dtHoraAgendamento,
                    DataAgendamento = dataAgendamento,
                    Horario = horario,
                    FkUsuarioId = fkUsuarioId,
                    FkServicoId = fkServicoId
                };

                _context.TbAgendamentos.Add(agendamento);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Log do erro
                Console.WriteLine($"Erro ao inserir agendamento: {ex.Message}");
                return false;
            }
        }

        // Listar Agendamentos
        public List<ViewAgendamentoVM> ListarAgendamentos()
        {
            var listAgendamentos = new List<ViewAgendamentoVM>();

            var agendamentosDb = _context.ViewAgendamentos.ToList();

            foreach (var agendamento in agendamentosDb)
            {
                var agendamentoVM = new ViewAgendamentoVM
                {
                    Id = agendamento.Id,
                    DtHoraAgendamento = agendamento.DtHoraAgendamento,
                    DataAgendamento = agendamento.DataAgendamento,
                    Horario = agendamento.Horario,
                    Nome = agendamento.Nome,
                    Email = agendamento.Email,
                    Telefone = agendamento.Telefone,
                    TipoServico = agendamento.TipoServico,
                    Valor = agendamento.Valor
                };

                listAgendamentos.Add(agendamentoVM);
            }

            return listAgendamentos;
        }

        // Atualizar Agendamento
        public bool AtualizarAgendamento(int id, DateTime dtHoraAgendamento, DateOnly dataAgendamento, TimeOnly horario, int fkUsuarioId, int fkServicoId)
        {
            try
            {
                var agendamento = _context.TbAgendamentos.FirstOrDefault(a => a.Id == id);
                if (agendamento != null)
                {
                    _context.Entry(agendamento).State = EntityState.Modified;

                    agendamento.DtHoraAgendamento = dtHoraAgendamento;
                    agendamento.DataAgendamento = dataAgendamento;
                    agendamento.Horario = horario;
                    agendamento.FkUsuarioId = fkUsuarioId;
                    agendamento.FkServicoId = fkServicoId;

                    _context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar o agendamento com ID {id}: {ex.Message}");
                return false;
            }
        }

        // Excluir Agendamento
        public bool ExcluirAgendamento(int id)
        {
            try
            {
                var agendamento = _context.TbAgendamentos.FirstOrDefault(a => a.Id == id);
                if (agendamento != null)
                {
                    _context.Entry(agendamento).State = EntityState.Deleted;

                    _context.TbAgendamentos.Remove(agendamento);
                    _context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir o agendamento com ID {id}: {ex.Message}");
                return false;
            }
        }

        public List<AgendamentoVM> ConsultarAgendamento(string datap)
        {
            DateOnly data = DateOnly.ParseExact(datap, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string dataFormatada = data.ToString("yyyy-MM-dd"); // Formato desejado: "yyyy-MM-dd"
            Console.WriteLine(dataFormatada);

            try
            {
                // Consulta ao banco de dados, convertendo para o tipo AtendimentoVM
                var ListaAgendamento = _context.TbAgendamentos
                    .Where(a => a.DataAgendamento == DateOnly.Parse(dataFormatada))
                    .Select(a => new AgendamentoVM
                    {
                        // Mapear as propriedades de TbAtendimento para AtendimentoVM
                        // Suponha que TbAtendimento tenha as propriedades Id, DataAtendimento, e outras:
                        Id = a.Id,
                        DtHoraAgendamento = a.DtHoraAgendamento,
                        DataAgendamento = DateOnly.Parse(dataFormatada),
                        Horario = a.Horario,
                        FkUsuarioId = a.FkUsuarioId,
                        FkServicoId = a.FkServicoId
                    })
                    .ToList(); // Converte para uma lista

                return ListaAgendamento;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar agendamentos: {ex.Message}");
                return new List<AgendamentoVM>(); // Retorna uma lista vazia em caso de erro
            }
        }
    }
}
