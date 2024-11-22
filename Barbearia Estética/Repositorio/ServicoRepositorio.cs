using Barbearia_Estética.Models;
using Barbearia_Estética.ORM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteAgendamento.Repositorio
{
    public class ServicoRepositorio
    {
        private readonly BdEsteticaContext _context;

        public ServicoRepositorio(BdEsteticaContext context)
        {
            _context = context;
        }

        public bool InserirServico(string tipoServico, decimal valor)
        {
            try
            {
                TbServico servico = new TbServico
                {
                    TipoServico = tipoServico,
                    Valor = valor
                };

                _context.TbServicos.Add(servico);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Log do erro
                Console.WriteLine($"Erro ao inserir serviço: {ex.Message}");
                return false;
            }
        }

        public List<ServicoVM> ListarServicos()
        {
            List<ServicoVM> listFun = new List<ServicoVM>();

            var listTb = _context.TbServicos.ToList();

            foreach (var item in listTb)
            {
                var servicos = new ServicoVM
                {
                    Id = item.Id,
                    TipoServico = item.TipoServico,
                    Valor = item.Valor
                };

                listFun.Add(servicos);
            }

            return listFun;
        }

        public bool AtualizarServico(int id, string tipoServico, decimal valor)
        {
            try
            {
                var servico = _context.TbServicos.FirstOrDefault(s => s.Id == id);
                if (servico != null)
                {
                    servico.TipoServico = tipoServico;
                    servico.Valor = valor;

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
                Console.WriteLine($"Erro ao atualizar o serviço com ID {id}: {ex.Message}");
                return false;
            }

            throw new NotImplementedException();
        }

        public bool ExcluirServico(int id)
        {
            try
            {
                var servico = _context.TbServicos.FirstOrDefault(s => s.Id == id);
                if (servico != null)
                {
                    _context.TbServicos.Remove(servico);
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
                Console.WriteLine($"Erro ao excluir o serviço com ID {id}: {ex.Message}");
                return false;
            }

            throw new NotImplementedException();
        }     
    }
}
