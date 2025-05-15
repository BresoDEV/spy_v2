using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.Win32;


namespace spy
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            spybot.inicializar(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
           // label1.Text = "Nome: " + spybot.MEU_NOME +
           //     "\nMac: " + spybot.MEU_MAC +
           //     "\nAcao: " + spybot.ACAO +
           //     "\nData: " + spybot.DATA +
           //     "\nTUDO_OK: " + spybot.TUDO_OK +
           //     "\nbateuData(): " + spybot.bateuData() +
           //     "\nVerificarInternet(): " + spybot.VerificarInternet() +
           //     "\nestaNavegandoInternet(): " + spybot.estaNavegandoInternet() +
           //     "\nFRASE: " + spybot.FRASE;

            // this.Text=spybot.contador.ToString();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }



       




        private void button2_Click_1(object sender, EventArgs e)
        {

           
        }
    }
}
