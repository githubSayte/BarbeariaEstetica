using Moq;
using Barbearia_Estética;
using Barbearia_Estética.ORM;
using Microsoft.EntityFrameworkCore;
using SiteAgendamento.Repositorio;

namespace TestBarbeariaEstetica
{
    public class UsuarioRepositorioTests
    {
        private BdEsteticaContext CriarContextoEmMemoria()
        {
            var options = new DbContextOptionsBuilder<BdEsteticaContext>()
               .UseInMemoryDatabase("TesteDb") // Usando o banco em memória
                .Options;
            return new BdEsteticaContext(options);
        }

        [Fact]
        public void InserirUsuario_DeveInserirUsuarioComSucesso()
        {
            // Arrange
            var contexto = CriarContextoEmMemoria();
            var repositorio = new UsuarioRepositorio(contexto);

            // Act
            var resultado = repositorio.InserirUsuario("João", "joao@example.com", "123456789", "senha", 1);

            // Assert
            Assert.True(resultado);

            // Verifique se o usuário foi inserido
            var usuario = contexto.TbUsuarios.FirstOrDefault(u => u.Email == "joao@example.com");
            Assert.NotNull(usuario);
            Assert.Equal("João", usuario.Nome);
        }

        [Fact]
        public void ListarUsuarios_DeveRetornarListaDeUsuarios()
        {
            // Arrange
            var contexto = CriarContextoEmMemoria();
            var repositorio = new UsuarioRepositorio(contexto);

            contexto.TbUsuarios.Add(new TbUsuario { Nome = "João", Email = "joao@example.com", Telefone = "123456789", Senha = "senha", TipoUsuario = 1 });
            contexto.SaveChanges();

            // Act
            var usuarios = repositorio.ListarUsuarios();

            // Assert
            Assert.Single(usuarios);
            Assert.Equal("João", usuarios.First().Nome);
        }

        [Fact]
        public void AtualizarUsuario_DeveAtualizarUsuarioComSucesso()
        {
            // Arrange
            var contexto = CriarContextoEmMemoria();
            var repositorio = new UsuarioRepositorio(contexto);

            // Inserir um usuário para atualizar
            contexto.TbUsuarios.Add(new TbUsuario { Nome = "João", Email = "joao@example.com", Telefone = "123456789", Senha = "senha", TipoUsuario = 1 });
            contexto.SaveChanges();

            var usuarioId = contexto.TbUsuarios.First().Id;

            // Act
            var resultado = repositorio.AtualizarUsuario(usuarioId, "João Atualizado", "joao@update.com", "987654321", "novasenha", 2);

            // Assert
            Assert.True(resultado);

            // Verificar se os dados foram atualizados
            var usuarioAtualizado = contexto.TbUsuarios.First(u => u.Id == usuarioId);
            Assert.Equal("João Atualizado", usuarioAtualizado.Nome);
            Assert.Equal("joao@update.com", usuarioAtualizado.Email);
        }

        [Fact]
        public void ExcluirUsuario_DeveExcluirUsuarioComSucesso()
        {
            // Arrange
            var contexto = CriarContextoEmMemoria();
            var repositorio = new UsuarioRepositorio(contexto);

            // Inserir um usuário para excluir
            contexto.TbUsuarios.Add(new TbUsuario { Nome = "João", Email = "joao@example.com", Telefone = "123456789", Senha = "senha", TipoUsuario = 1 });
            contexto.SaveChanges();

            var usuarioId = contexto.TbUsuarios.First().Id;

            // Act
            var resultado = repositorio.ExcluirUsuario(usuarioId);

            // Assert
            Assert.True(resultado);

            // Verificar se o usuário foi excluído
            var usuarioExcluido = contexto.TbUsuarios.FirstOrDefault(u => u.Id == usuarioId);
            Assert.Null(usuarioExcluido);
        }

        [Fact]
        public void ExcluirUsuario_DeveLancarExcecaoQuandoUsuarioNaoExistir()
        {
            // Arrange
            var contexto = CriarContextoEmMemoria();
            var repositorio = new UsuarioRepositorio(contexto);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => repositorio.ExcluirUsuario(999)); // ID que não existe
            Assert.Contains("Erro ao excluir o usuário", exception.Message);
        }
    }
}