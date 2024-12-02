using Barbearia_Estética.Models;
using Barbearia_Estética.ORM;
using Microsoft.EntityFrameworkCore;
using Moq;
using SiteAgendamento.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SiteAgendamento.Tests
{
    public class AgendamentoRepositorioTests
    {
        private readonly Mock<BdEsteticaContext> _mockContext;
        private readonly AgendamentoRepositorio _repositorio;

        public AgendamentoRepositorioTests()
        {
            // Criando o mock para o contexto BdEsteticaContext
            _mockContext = new Mock<BdEsteticaContext>();
            _repositorio = new AgendamentoRepositorio(_mockContext.Object);
        }

        [Fact]
        public void InserirAgendamento_DeveRetornarTrue_QuandoInserirComSucesso()
        {
            // Arrange
            var dtHoraAgendamento = new DateTime(2024, 12, 5);
            var dataAgendamento = new DateOnly(2024, 12, 6);
            var horario = new TimeOnly(10, 30);
            var fkUsuarioId = 1;
            var fkServicoId = 2;

            var mockDbSet = new Mock<DbSet<TbAgendamento>>();
            _mockContext.Setup(m => m.TbAgendamentos).Returns(mockDbSet.Object);

            // Act
            var resultado = _repositorio.InserirAgendamento(dtHoraAgendamento, dataAgendamento, horario, fkUsuarioId, fkServicoId);

            // Assert
            Assert.True(resultado);
            mockDbSet.Verify(m => m.Add(It.IsAny<TbAgendamento>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ListarAgendamentos_DeveRetornarListaDeAgendamentos()
        {
            // Arrange
            var agendamentos = new List<ViewAgendamentoVM>
            {
                new ViewAgendamentoVM
                {
                    Id = 1,
                    DtHoraAgendamento = new DateTime(2024, 12, 5),
                    DataAgendamento = new DateOnly(2024, 12, 6),
                    Horario = new TimeOnly(10, 30),
                    Nome = "João",
                    Email = "joao@example.com",
                    Telefone = "123456789",
                    TipoServico = "Corte de cabelo",
                    Valor = 30m
                },
                new ViewAgendamentoVM
                {
                    Id = 2,
                    DtHoraAgendamento = new DateTime(2024, 12, 7),
                    DataAgendamento = new DateOnly(2024, 12, 8),
                    Horario = new TimeOnly(11, 00),
                    Nome = "Maria",
                    Email = "maria@example.com",
                    Telefone = "987654321",
                    TipoServico = "Design de sobrancelhas",
                    Valor = 40m
                }
            };

           /* var mockDbSet = new Mock<DbSet<ViewAgendamentoVM>>();
            _mockContext.Setup(m => m.ViewAgendamentos).Returns(mockDbSet.Object);
           */

            // Act
            var resultado = _repositorio.ListarAgendamentos();

            // Assert
            Assert.Equal(2, resultado.Count);
            Assert.Equal("João", resultado[0].Nome);
            Assert.Equal(30m, resultado[0].Valor);
            Assert.Equal("Maria", resultado[1].Nome);
            Assert.Equal(40m, resultado[1].Valor);
        }

        [Fact]
        public void AtualizarAgendamento_DeveRetornarTrue_QuandoAtualizacaoForBemSucedida()
        {
            // Arrange
            var id = 1;
            var dtHoraAgendamento = new DateTime(2024, 12, 5);
            var dataAgendamento = new DateOnly(2024, 12, 6);
            var horario = new TimeOnly(10, 30);
            var fkUsuarioId = 1;
            var fkServicoId = 2;

            var agendamento = new TbAgendamento
            {
                Id = id,
                DtHoraAgendamento = new DateTime(2024, 12, 1),
                DataAgendamento = new DateOnly(2024, 12, 2),
                Horario = new TimeOnly(9, 30),
                FkUsuarioId = 3,
                FkServicoId = 4
            };

            var mockDbSet = new Mock<DbSet<TbAgendamento>>();
            mockDbSet.As<IQueryable<TbAgendamento>>().Setup(m => m.Provider).Returns(new List<TbAgendamento> { agendamento }.AsQueryable().Provider);
            mockDbSet.As<IQueryable<TbAgendamento>>().Setup(m => m.Expression).Returns(new List<TbAgendamento> { agendamento }.AsQueryable().Expression);
            mockDbSet.As<IQueryable<TbAgendamento>>().Setup(m => m.ElementType).Returns(new List<TbAgendamento> { agendamento }.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<TbAgendamento>>().Setup(m => m.GetEnumerator()).Returns(new List<TbAgendamento> { agendamento }.AsQueryable().GetEnumerator());

            _mockContext.Setup(m => m.TbAgendamentos).Returns(mockDbSet.Object);

            // Act
            var resultado = _repositorio.AtualizarAgendamento(id, dtHoraAgendamento, dataAgendamento, horario, fkUsuarioId, fkServicoId);

            // Assert
            Assert.True(resultado);
            Assert.Equal(dtHoraAgendamento, agendamento.DtHoraAgendamento);
            Assert.Equal(dataAgendamento, agendamento.DataAgendamento);
            Assert.Equal(horario, agendamento.Horario);
            Assert.Equal(fkUsuarioId, agendamento.FkUsuarioId);
            Assert.Equal(fkServicoId, agendamento.FkServicoId);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ExcluirAgendamento_DeveRetornarTrue_QuandoExcluirComSucesso()
        {
            // Arrange
            var id = 1;
            var agendamento = new TbAgendamento
            {
                Id = id,
                DtHoraAgendamento = new DateTime(2024, 12, 5),
                DataAgendamento = new DateOnly(2024, 12, 6),
                Horario = new TimeOnly(10, 30),
                FkUsuarioId = 1,
                FkServicoId = 2
            };

            var agendamentos = new List<TbAgendamento> { agendamento }.AsQueryable();

            var mockDbSet = new Mock<DbSet<TbAgendamento>>();
            mockDbSet.As<IQueryable<TbAgendamento>>().Setup(m => m.Provider).Returns(agendamentos.Provider);
            mockDbSet.As<IQueryable<TbAgendamento>>().Setup(m => m.Expression).Returns(agendamentos.Expression);
            mockDbSet.As<IQueryable<TbAgendamento>>().Setup(m => m.ElementType).Returns(agendamentos.ElementType);
            mockDbSet.As<IQueryable<TbAgendamento>>().Setup(m => m.GetEnumerator()).Returns(agendamentos.GetEnumerator());

            _mockContext.Setup(m => m.TbAgendamentos).Returns(mockDbSet.Object);

            // Act
            var resultado = _repositorio.ExcluirAgendamento(id);

            // Assert
            Assert.True(resultado);
            mockDbSet.Verify(m => m.Remove(It.IsAny<TbAgendamento>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
