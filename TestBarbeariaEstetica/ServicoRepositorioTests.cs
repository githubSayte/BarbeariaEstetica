
using Barbearia_Estética.ORM;
using Microsoft.EntityFrameworkCore;
using Moq;
using SiteAgendamento.Repositorio;

public class ServicoRepositorioTests
{
    private readonly Mock<BdEsteticaContext> _mockContext;
    private readonly ServicoRepositorio _repositorio;

    public ServicoRepositorioTests()
    {
        // Criando um Mock para o DbSet de TbServico
        _mockContext = new Mock<BdEsteticaContext>();
        _repositorio = new ServicoRepositorio(_mockContext.Object);
    }

    [Fact]
    public void InserirServico_DeveRetornarTrue_QuandoInserirComSucesso()
    {
        // Arrange
        var tipoServico = "Designer de cabelos masculino: com cortes ou penteados";
        var valor = 50m;

        var mockDbSet = new Mock<DbSet<TbServico>>();
        _mockContext.Setup(m => m.TbServicos).Returns(mockDbSet.Object);

        // Act
        var resultado = _repositorio.InserirServico(tipoServico, valor);

        // Assert
        Assert.True(resultado);
        mockDbSet.Verify(m => m.Add(It.IsAny<TbServico>()), Times.Once);
        _mockContext.Verify(m => m.SaveChanges(), Times.Once);
    }

    [Fact]
    public void ListarServicos_DeveRetornarListaDeServicos()
    {
        // Arrange
        var servicos = new List<TbServico>
        {
            new TbServico { Id = 1, TipoServico = "Designer de cabelos masculino: com cortes ou penteados", Valor = 50m },
            new TbServico { Id = 2, TipoServico = "Corte de Cabelo padrão: na máquina ou na tesoura", Valor = 10m },
            new TbServico { Id = 3, TipoServico = "Coloração de Cabelo: com estilo ou padrão", Valor = 25m },
            new TbServico { Id = 4, TipoServico = "Barba e Bigode: corte, realce e Coloração", Valor = 15m },
            new TbServico { Id = 5, TipoServico = "Barba Expressa: na máquina e na navalha", Valor = 5m },
            new TbServico { Id = 6, TipoServico = "Pacote de Manutenção Mensal: pagamento uma vez ao mês valor:", Valor = 150m }
        }.AsQueryable();

        var mockDbSet = new Mock<DbSet<TbServico>>();
        mockDbSet.As<IQueryable<TbServico>>().Setup(m => m.Provider).Returns(servicos.Provider);
        mockDbSet.As<IQueryable<TbServico>>().Setup(m => m.Expression).Returns(servicos.Expression);
        mockDbSet.As<IQueryable<TbServico>>().Setup(m => m.ElementType).Returns(servicos.ElementType);
        mockDbSet.As<IQueryable<TbServico>>().Setup(m => m.GetEnumerator()).Returns(servicos.GetEnumerator());

        _mockContext.Setup(m => m.TbServicos).Returns(mockDbSet.Object);

        // Act
        var resultado = _repositorio.ListarServicos();

        // Assert
        Assert.Equal(6, resultado.Count);
        Assert.Equal("Designer de cabelos masculino: com cortes ou penteados", resultado[0].TipoServico);
        Assert.Equal(50m, resultado[0].Valor);
        Assert.Equal("Corte de Cabelo padrão: na máquina ou na tesoura", resultado[1].TipoServico);
        Assert.Equal(10m, resultado[1].Valor);
    }

    [Fact]
    public void AtualizarServico_DeveRetornarTrue_QuandoAtualizacaoForBemSucedida()
    {
        // Arrange
        var id = 1;
        var tipoServico = "Designer de cabelos masculino: com cortes ou penteados Atualizado";
        var valor = 55m;
        var servico = new TbServico { Id = id, TipoServico = "Designer de cabelos masculino: com cortes ou penteados", Valor = 50m };

        var mockDbSet = new Mock<DbSet<TbServico>>();
        mockDbSet.As<IQueryable<TbServico>>()
                 .Setup(m => m.Provider).Returns(new List<TbServico> { servico }.AsQueryable().Provider);
        mockDbSet.As<IQueryable<TbServico>>()
                 .Setup(m => m.Expression).Returns(new List<TbServico> { servico }.AsQueryable().Expression);
        mockDbSet.As<IQueryable<TbServico>>()
                 .Setup(m => m.ElementType).Returns(new List<TbServico> { servico }.AsQueryable().ElementType);
        mockDbSet.As<IQueryable<TbServico>>()
                 .Setup(m => m.GetEnumerator()).Returns(new List<TbServico> { servico }.AsQueryable().GetEnumerator());

        _mockContext.Setup(m => m.TbServicos).Returns(mockDbSet.Object);

        // Act
        var resultado = _repositorio.AtualizarServico(id, tipoServico, valor);

        // Assert
        Assert.True(resultado);
        Assert.Equal(tipoServico, servico.TipoServico);
        Assert.Equal(valor, servico.Valor);
        _mockContext.Verify(m => m.SaveChanges(), Times.Once);
    }

    [Fact]
    public void ExcluirServico_DeveRetornarTrue_QuandoExcluirComSucesso()
    {
        // Arrange
        var id = 1;
        var servico = new TbServico { Id = id, TipoServico = "Designer de cabelos masculino: com cortes ou penteados", Valor = 50m };

        var servicos = new List<TbServico> { servico }.AsQueryable();

        var mockDbSet = new Mock<DbSet<TbServico>>();
        mockDbSet.As<IQueryable<TbServico>>()
                 .Setup(m => m.Provider).Returns(servicos.Provider);
        mockDbSet.As<IQueryable<TbServico>>()
                 .Setup(m => m.Expression).Returns(servicos.Expression);
        mockDbSet.As<IQueryable<TbServico>>()
                 .Setup(m => m.ElementType).Returns(servicos.ElementType);
        mockDbSet.As<IQueryable<TbServico>>()
                 .Setup(m => m.GetEnumerator()).Returns(servicos.GetEnumerator());

        _mockContext.Setup(m => m.TbServicos).Returns(mockDbSet.Object);

        // Act
        var resultado = _repositorio.ExcluirServico(id);

        // Assert
        Assert.True(resultado);
        mockDbSet.Verify(m => m.Remove(It.IsAny<TbServico>()), Times.Once);
        _mockContext.Verify(m => m.SaveChanges(), Times.Once);
    }
}
