
using Barbearia_Estética.Models;
using Barbearia_Estética.ORM;
using System.Drawing;

namespace SiteAgendamento.Repositorio
{
    public class ServicoRepositorio
    {

        private BdEsteticaContext _context;
        public ServicoRepositorio(BdEsteticaContext context)
        {
            _context = context;
        }
        public bool InserirServico(string tiposervico, decimal valor)
        {
            try
            {
                TbServico servico = new TbServico();
                servico.TipoServico = tiposervico;
                servico.Valor = valor;


                _context.TbServicos.Add(servico);  // Supondo que _context.TbServicos seja o DbSet para a entidade de TbServico
                _context.SaveChanges();

                return true;  // Retorna true para indicar sucesso
            }
            catch (Exception ex)
            {
                // Trate o erro ou faça um log do ex.Message se necessário
                return false;  // Retorna false para indicar falha
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
                    Valor = item.Valor = item.Valor,
                   
                };

                listFun.Add(servicos);
            }

            return listFun;
        }

        public bool AtualizarServicos(int id, string tiposervico, decimal valor)
        {
            try
            {
                // Busca os servicos pelo ID
                var servicos = _context.TbServicos.FirstOrDefault(u => u.Id == id);
                if (servicos != null)
                {
                    // Atualiza os dados dos servicos
                    servicos.TipoServico = tiposervico; 
                    servicos.Valor = valor; 

                    // Salva as mudanças no banco de dados
                    _context.SaveChanges();

                    return true;  // Retorna verdadeiro se a atualização for bem-sucedida
                }
                else
                {
                    return false;  // Retorna falso se o servico não foi encontrado
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar o serviço com ID {id}: {ex.Message}");
                return false;
            }
        }

        public bool ExcluirServicos(int id)
        {
            try
            {
                // Busca o servico pelo ID
                var servicos = _context.TbServicos.FirstOrDefault(u => u.Id == id);
                if (servicos != null)
                {
                    // Remove o servico do banco de dados
                    _context.TbServicos.Remove(servicos);
                    _context.SaveChanges();

                    return true;  // Retorna verdadeiro se a exclusão for bem-sucedida
                }
                else
                {
                    return false;  // Retorna falso se o servico não foi encontrado
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir o serviço com ID {id}: {ex.Message}");
                return false;
            }
        }
    }
}

