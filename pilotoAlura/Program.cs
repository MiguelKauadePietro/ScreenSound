    using static System.Console;

    // Screen Sound
    string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
    //List<string> listaDasBandas = new List<string> { "The chainsmokers", "Blue oyster cult", "Charlie Brown Jr" };

    Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>(); //! dicionário criado, onde a chave seria o nome das bandas
                                                                                           //! e os valores são as notas dessas bandas!
    bandasRegistradas.Add("The chainsmokers", new List<int> { 10, 8, 6 });
    bandasRegistradas.Add("Charlie Brown Jr", new List<int>());

    void ExibirLogo()
    {
        WriteLine(@"
    
        ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
        ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
        ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
        ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
        ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
        ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
        ");
        WriteLine(mensagemDeBoasVindas);
    }

    void ExibirOpcoesDoMenu()
    {
        ExibirLogo();
        WriteLine("\nDigite 1 para registrar uma banda");
        WriteLine("Digite 2 para mostrar todas as bandas");
        WriteLine("Digite 3 para avaliar uma banda");
        WriteLine("Digite 4 parar exibir a média de avaliação de uma banda");
        WriteLine("Digite -1 para sair");

        Write("\n Digite a sua opção: ");
        string opcaoEscolhida = ReadLine()!; //! Variável responsável por ler o valor da opção escolhida
        int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida); //! Variável responsável por passar o valor da opção escolhida para inteiro(um número inteiro)

        switch (opcaoEscolhidaNumerica)
        {
            case 1: RegistrarBanda();
                break;
            case 2: MostrarBandasRegistradas();
                break;
            case 3: AvaliarUmaBanda();
                break;
            case 4: ExibirMediaDeavaliacoes();
                break;
            case -1: WriteLine("falou babaca, os de vdd eu sei qm são"); //! !PHP lixo! 
                break;
            default: WriteLine("Essa opção é inválida");
                break;
        }
    }

    void RegistrarBanda(){

        ExibirLogo();
        Clear();
        ExibirTituloDaOpcao("Registro de bandas");
        Write("Digite o nome da banda que deseja registrar: ");
        string nomeBanda = ReadLine()!; //! "!" está sendo usado para que o valor da variável não seja considerado null
        bandasRegistradas.Add(nomeBanda, new List<int>()); //! Agora com o dictionary criado, está linha foi mudada, além de enviarmos o nomeBanda para o add,
                                                           //! temos que instânciar a lista de inteiros que serão as notas
        WriteLine($"A banda {nomeBanda} foi registrada com sucesso"); // interpolação de string com variável
        Thread.Sleep(2000); //! usado para "pausar" a execuição do programa em um determinado período de tempo
        Clear();
        ExibirOpcoesDoMenu();

    }

    void MostrarBandasRegistradas()
    {
        Clear();
        ExibirTituloDaOpcao("Exibindo todas as bandas registradas na nossa aplicação");
        //for(int i = 0; i < listaDasBandas.Count; i++) // Aqui está sendo utilizado o laço de repetição for, para iterar os elementos da lista e mostrar no console
        //                                              // Lógica: se a contagem das bandas for maior que i, o i é incrementado com uma mensagem no console
        // Aqui está sendo utilizado o método Count, que conta os elementos de uma lista
        //{ 
        //    WriteLine($"Banda: {listaDasBandas[i]}"); // Aqui está sendo usado um índice, para que mostre a banda que está em uma certa posição
        //}

        foreach (string banda in bandasRegistradas.Keys) //! Alteração feita por causa do dictiorary criado, agora quando chamar o
                                                         //! bandasRegistradas(como é um laço de rep) foi adicionado o atributo .Keys, pois só irei utilizar as chaves do dicionário
        {                                                //! Lógica: para cada banda na(in) listaDasBandas escreva o nome dessa banda
            WriteLine($"Banda: {banda}");
        }

        WriteLine("\nDigite uma tecla para voltar ao menu principal");
        ReadKey(); //! serve para fazer a leitura da tecla digitada
        Clear();
        ExibirOpcoesDoMenu();
    }

    void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        WriteLine(asteriscos);
        WriteLine(titulo);
        WriteLine(asteriscos + "\n");
    }

    void AvaliarUmaBanda()
    {
        //digite a banda que deseja avaliar
        //se a banda existir no dicionário >> atribuir uma nota
        //senão existir, levar o usuário de volta ao menu principal
        Clear();
        ExibirTituloDaOpcao("Avaliação das bandas");
        Write("Digite o nome da banda que você deseja avaliar: ");
        string nomeDaBanda = ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda)) //! Verificando se o nome da banda está nas chaves do dicionário criado
        {
            Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
            int nota = int.Parse(ReadLine()!); //! pegando o valor da nota(que está como string) e passando para inteiro
            bandasRegistradas[nomeDaBanda].Add(nota); //! adicionando a nota digitada pelo usuário para os valores do dicionário
            WriteLine($"A nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
            Thread.Sleep(4000);
            Clear();
            ExibirOpcoesDoMenu();
        }
        else
        {
            WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            WriteLine("Digite uma tecla para voltar ao menu principal");
            ReadKey();
            Clear();
            ExibirOpcoesDoMenu();
        }
    

    }

    void ExibirMediaDeavaliacoes()
    {
        Clear();
        ExibirTituloDaOpcao("Média de avaliação das bandas");
        Write("Digite o nome da banda que você deseja saber a média de avaliações: ");
        string nomeDaBanda = ReadLine()!;

        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            double mediaDaBanda = bandasRegistradas[nomeDaBanda].Average();
            WriteLine($"A média da banda {nomeDaBanda} possui uma avaliação média de {mediaDaBanda}");
        }
        else
        {
            WriteLine("Essa banda não existe");
        }
        Clear();
        WriteLine("Digite qualquer tecla para voltar ao menu principal");
        ReadKey();
        ExibirOpcoesDoMenu();
    }

    ExibirOpcoesDoMenu();