//Acessando as variáveis de ambiente
/*string id = Environment.GetEnvironmentVariable("USUARIO_ID");
string nome = Environment.GetEnvironmentVariable("USUARIO_NOME");
string email = Environment.GetEnvironmentVariable("USUARIO_EMAIL");
string telefone = Environment.GetEnvironmentVariable("USUARIO_TELEFONE");
string senha = Environment.GetEnvironmentVariable("USUARIO_senha");
string tipoUsuario = Environment.GetEnvironmentVariable("USUARIO_TIPO");
// Se não encontrar o usuário, retorna null ou uma exceção
*/

//Environment.SetEnvironmentVariable("USUARIO_SENHA", usuario.Senha);

//fonte: French Script MT

// public DateTime DataHoraCadastro { get; set; }

//@model IEnumerable<Barbearia_Estética.Models.RelatorioVM>

/* <style>
    .scissors {
    position: relative;
    width: 64px;
    height: 64px;
    }

    .scissors .blade {
    position: absolute;
    width: 50%;
    height: 6px;
    background: #000;
    top: 50%;
    left: 50%;
    transform-origin: left center;
    transform: rotate(0deg);
    transition: transform 0.3s ease-in-out;
    }

    .scissors .blade-1 {
    transform-origin: left center;
    }

    .scissors .blade-2 {
    transform-origin: left center;
    transform: rotate(180deg);
    }

    .scissors:hover .blade-1 {
    transform: rotate(30deg);
    }

    .scissors:hover .blade-2 {
    transform: rotate(150deg);
    }
</style> 
*/

/*<style>
    .dropdown-content {
    display: none;
    position: absolute;
    background-color: #f9f9f9;
    min-width: 200px;
    box-shadow: 0px 8px 16px 0px rgba(0, 0, 0, 0.2);
    z-index: 1;
    padding: 8px;
    border-radius: 3%;
    right: 0;
    /* Alinha o submenu à direita 

    }

    .dropdown - content a 
    {
    color: black;
    padding: 7px;
    text - decoration: none;
    display: flex;
    align - items: center;
    margin: 5px;
    color: black;
    padding: 18px;
    /* Adiciona padding 

    /*text - decoration: none;
    display: flex;
    margin: 1px;
    /* Adiciona a margem 
    border - radius: 3 %;
    }

    .dropdown - content a: hover 
    {
    background - color: #ddd;
    border: #725f47 solid 2px;
    border - radius: 3 %;
    }

    .dropdown: hover.dropdown - content {
    display: block;
    }
</ style > */

/* < style >
        
    /* Estilo para o overlay (fundo escuro) 
    # overlay {
            position: fixed;
    top: 0;
    left: 0;
    width: 100 %;
    height: 100 %;
    background - color: rgba(0, 0, 0, 0.5); /* Cor escura com transparência 
    z - index: 9998; /* Colocar abaixo do loader 
    display: none; /* Inicialmente escondido 
        }

        /* Estilo para o loader 
        #loader {
            position: fixed;
    top: 50 %;
    left: 50 %;
    transform: translate(-50 %, -50 %);
    padding: 15px 30px;
    background - color: rgba(0, 0, 0, 0.7); /* Fundo escuro para o loader 
    color: white;
    border - radius: 5px;
    font - size: 16px;
    z - index: 9999; /* Colocar acima do overlay 
    display: none; /* Inicialmente escondido 
        }
</ style > */

//css para index relatorio index
/*<style>
    /* Estilo para a box-container 
    .box-container {
        padding: 30px;
        margin-bottom: 30px;
        background-color: #EAE7DC;
        border-radius: 8px;
        box-shadow: 0 4px 8px #867f58;
        height: auto; /* Ajuste para a altura ser dinâmica 
    }

    /* Estilo para a container da página 
    .container.page-maneger {
        padding: 20px;
        background-color: #EAE7DC;
        border-radius: 8px;
        box-shadow: 0 8px 8px #867f58;
        min-height: 400px; /* Altura mínima para a div 
        height: auto; /* Deixe a altura da div crescer conforme o conteúdo 
        border-top: 4px solid #867f58; /* Borda no topo 
    }

    /* Filtro Input e Select 
    .filter-group {
        display: flex;
        justify-content: space-between;
        margin-bottom: 20px;
    }

        .filter-group > div {
            flex: 1;
            margin-right: 10px;
        }

            .filter-group > div:last-child {
                margin-right: 0;
            }

    .filter-input,
    .filter-select {
        width: 100%;
        padding: 12px;
        font-size: 16px;
        border-radius: 5px;
        border: 1px solid #725f47;
        box-sizing: border-box;
        transition: all 0.3s ease;
    }

        .filter-input:focus,
        .filter-select:focus {
            border-color: #725f47;
            outline: none;
        }

    /* Botão de pesquisa 
    .btn {
        padding: 12px 25px;
        background-color: #867f58;
        color: #fff;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        transition: background-color 0.3s ease;
    }

        .btn:hover {
            background-color: #867f58;
        }

   

    /* Estilos para a tabela 

    #tabelaAgendamentos 
    {
        margin-top: 20px;
        width: 100%;
        color: white; /* Texto verde 
        background-color: white; /* Fundo preto para a tabela 
        border-collapse: collapse; /* Garante que as bordas fiquem colapsadas 
        font-family: Arial, sans-serif; /* Fonte mais clean 
    }

        /* Estilo das células da tabela 
        #tabelaAgendamentos th, #tabelaAgendamentos td {
            padding: 12px 15px;
            text-align: left; /* Alinha o texto à esquerda 
            border: 1px solid #fff; /* Cor escura nas bordas 
        }

        /* Estilo para os cabeçalhos da tabela 
        #tabelaAgendamentos th {
            background-color: #725f47; /* Fundo escuro para os cabeçalhos 
            color: white; /* Cor verde neon para o texto dos cabeçalhos 
            font-weight: bold;
        }

        /* Estilo para as linhas da tabela (alternando a cor das linhas para facilitar leitura) 
        #tabelaAgendamentos tr:nth-child(even) {
            background-color: #725f47; /* Cor escura para linhas pares 
        }

        #tabelaAgendamentos tr:nth-child(odd) {
            background-color: #725f47; /* Cor um pouco mais clara para as linhas ímpares 
        }

        /* Estilo para o foco nos links (caso haja links na tabela) 
        #tabelaAgendamentos a {
            color: #91917a; /* Verde neon para links 
            text-decoration: none; /* Remove o sublinhado 
        }

            #tabelaAgendamentos a:hover {
                text-decoration: underline; /* Sublinha ao passar o mouse 
            }

        /* Estilo para o botão de pesquisa 
        .btn-pesquisar {
            background-color: #725f47; /* Cor verde 
            color: white;
            padding: 8px 16px; /* Diminuir o tamanho do botão 
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

            .btn-pesquisar:hover {
                background-color: #725f47; /* Cor verde mais escura ao passar o mouse 
            }

        /* Estilo para centralizar os botões de exportação 
        .center-buttons {
            text-align: center;
            margin-bottom: 20px; /* Para dar um espaçamento entre os botões e a tabela 
            margin-top: 20px; /* Espaçamento superior para os botões de exportação 
        }

            .center-buttons .btn {
                display: inline-block;
                margin: 0 10px; /* Espaçamento entre os botões 
                background-color: #725f47; /* Cor verde 
                color: white;
                padding: 8px 16px; /* Botões menores 
                border: none;
                border-radius: 5px;
                cursor: pointer;
            }

                .center-buttons .btn:hover {
                    background-color: #725f47; /* Cor verde mais escura ao passar o mouse 
                }

        /* Adicionando espaçamento entre a tabela e o "Mostrar registros" 
        .dataTables_info {
            margin-top: 20px; /* Espaço superior maior entre a tabela e a contagem 
        }

        #tabelaAgendamentos_filter {
            padding: 2px; /* Espaçamento interno ao redor do campo de filtro 
            border-radius: 2px; /* Borda arredondada 
        }

            #tabelaAgendamentos_filter input {
                border: none; /* Remove a borda do campo de entrada 
                padding: 5px; /* Ajusta o preenchimento interno do campo de entrada 
                color: white; /* Cor do texto no campo 
                background-color: #725f47; /* Cor de fundo preta para o campo de entrada 
            }

</style>*/

// css cadastro
/*<style>
    /* Estilo para o overlay (fundo escuro) 
    #overlay {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, 0.5); /* Cor escura com transparência 
        z-index: 9998; /* Colocar abaixo do loader 
        display: none; /* Inicialmente escondido 
    }

    /* Estilo para o loader 
    #loader {
        position: fixed;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
        padding: 15px 30px;
        background-color: rgba(0, 0, 0, 0.7); /* Fundo escuro para o loader 
        color: white;
        border-radius: 5px;
        font-size: 16px;
        z-index: 9999; /* Colocar acima do overlay 
        display: none; /* Inicialmente escondido 
    }
    /* Ajuste o tamanho do popup (caixa) 
    .custom-popup {
        width: 400px !important; /* Garante que a largura seja exatamente 400px 
        padding: 20px !important; /* Ajuste o padding da caixa 
    }

    /* Ajusta o tamanho do botão para que ele tenha a mesma largura que a caixa 
    .custom-button {
        width: 100% !important; /* O botão ocupa 100% da largura da caixa 
        box-sizing: border-box; /* Inclui o padding e a borda no cálculo da largura 
    }
</style>*/

/**/
// css serviço index
/*<style>
    /* Estilo para o overlay (fundo escuro) 
    #overlay {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, 0.5); /* Cor escura com transparência 
        z-index: 9998; /* Colocar abaixo do loader 
        display: none; /* Inicialmente escondido 
    }

    /* Estilo para o loader 
    #loader {
        position: fixed;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
        padding: 15px 30px;
        background-color: rgba(0, 0, 0, 0.7); /* Fundo escuro para o loader 
        color: white;
        border-radius: 5px;
        font-size: 16px;
        z-index: 9999; /* Colocar acima do overlay 
        display: none; /* Inicialmente escondido 
    }
</style>*/
