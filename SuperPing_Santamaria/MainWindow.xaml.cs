using System.Net.NetworkInformation;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;
using System.Net;



namespace SuperPing_Santamaria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage bi0 = new BitmapImage();
        BitmapImage bi1 = new BitmapImage();
        BitmapImage bi2 = new BitmapImage();
        BitmapImage bi3 = new BitmapImage();

        public MainWindow()
        {
            InitializeComponent();
            bi0.BeginInit();
            bi0.UriSource = new Uri(" ", UriKind.Relative);
            bi0.EndInit();

            bi1.BeginInit();
            bi1.UriSource = new Uri("ok.png", UriKind.Relative);
            bi1.EndInit();

            bi2.BeginInit();
            bi2.UriSource = new Uri("attention.png", UriKind.Relative);
            bi2.EndInit();


            bi3.BeginInit();
            bi3.UriSource = new Uri("error.png", UriKind.Relative);
            bi3.EndInit();


            CaricoIpDaConfig();
        }
         DispatcherTimer Timer;
         private int tempoTrascorso = 0;

        private void timer_Tick (object sender, EventArgs e)
        {

            string indirizzo = txtIP00.Text;
            if (!string.IsNullOrEmpty(indirizzo))
            {
                Ping pinger = new Ping();
                PingReply reply = pinger.Send(indirizzo);
                string stato = reply.Status.ToString();
                string tempo = reply.RoundtripTime.ToString();
                txtStatus00.Text = stato;
                txtMs00.Text = tempo;
                StatIcon.Stretch = Stretch.Fill;
                StatIcon.Source = bi3; // Immagine "ok"

                if (int.Parse(tempo) < 50)
                {
                    StatIcon.Stretch = Stretch.Fill;
                    StatIcon.Source = bi1; // Immagine "ok"
                }
                else
                {
                    StatIcon.Stretch = Stretch.Fill;
                    StatIcon.Source = bi2; // Immagine "attention"
                }
            }

            string indirizzo1 = txtIP01.Text;
            if (!string.IsNullOrEmpty(indirizzo1))
            {
                Ping pinger1 = new Ping();
                PingReply reply1 = pinger1.Send(indirizzo1);
                string stato1 = reply1.Status.ToString();
                string tempo1 = reply1.RoundtripTime.ToString();
                txtStatus01.Text = stato1;
                txtMs01.Text = tempo1;

                if (int.Parse(tempo1) < 50)
                {
                    StatIcon2.Stretch = Stretch.Fill;
                    StatIcon2.Source = bi1; // Immagine "ok"
                }
                else
                {
                    StatIcon2.Stretch = Stretch.Fill;
                    StatIcon2.Source = bi2; // Immagine "attention"
                }
            }

            string indirizzo2 = txtIP02.Text;
            if (!string.IsNullOrEmpty(indirizzo2))
            {

                Ping pinger2 = new Ping();
                PingReply reply2 = pinger2.Send(indirizzo2);
                string stato2 = reply2.Status.ToString();
                string tempo2 = reply2.RoundtripTime.ToString();
                txtStatus02.Text = stato2;
                txtMs02.Text = tempo2;

                if (int.Parse(tempo2) < 50)
                {
                    StatIcon3.Stretch = Stretch.Fill;
                    StatIcon3.Source = bi1; // Immagine "ok"
                }
                else
                {
                    StatIcon3.Stretch = Stretch.Fill;
                    StatIcon3.Source = bi2; // Immagine "attention"
                }
            }


            string indirizzo3 = txtIP03.Text;
            if (!string.IsNullOrEmpty(indirizzo3))
            {

                Ping pinger3 = new Ping();
                PingReply reply3 = pinger3.Send(indirizzo3);
                string stato3 = reply3.Status.ToString();
                string tempo3 = reply3.RoundtripTime.ToString();
                txtStatus03.Text = stato3;
                txtMs03.Text = tempo3;

                if (int.Parse(tempo3) < 50)
                {
                    StatIcon4.Stretch = Stretch.Fill;
                    StatIcon4.Source = bi1; // Immagine "ok"
                }
                else
                {
                    StatIcon4.Stretch = Stretch.Fill;
                    StatIcon4.Source = bi2; // Immagine "attention"
                }
            }


            //PROGRESS BAR
            tempoTrascorso++;
            progressBar.Value = (tempoTrascorso / 30.0) * 100;
            if (tempoTrascorso >= 30)
            {
                Timer.Stop();
                progressBar.Value = 0;
                tempoTrascorso = 0;
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //TIMER
            timer_Tick(sender, e);
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(timer_Tick);
            Timer.Interval = TimeSpan.FromSeconds(30);
            Timer.Start();


            //PROGRESS BAR
            progressBar.Visibility = Visibility.Visible;
            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(1); // 1 secondo
            Timer.Tick += timer_Tick;
            Timer.Start();

            //CREA FILE 

            VerificaEAggiungiIPNelFile();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (Timer != null)
            {
                Timer.Stop();
                Timer = null;
            }
            progressBar.Value = 0;
            tempoTrascorso = 0;
        }


        private void VerificaEAggiungiIPNelFile()
        {
            string filePath = "config.txt";
            string[] ipAddresses = new string[] { txtIP00.Text, txtIP01.Text, txtIP02.Text, txtIP03.Text };

            // Verifica se il file esiste
            if (File.Exists(filePath))
            {
                // Leggi gli IP dal file
                string[] existingIPs = File.ReadAllLines(filePath);

                // Aggiungi gli IP nuovi al file
                foreach (string ipAddress in ipAddresses)
                {
                    if (!existingIPs.Contains(ipAddress))
                    {
                        File.AppendAllLines(filePath, new string[] { ipAddress });
                    }
                }
            }
            else
            {
                // Crea il file e scrivi gli IP
                File.WriteAllLines(filePath, ipAddresses);
            }
        }

        private void CaricoIpDaConfig()
        {
            StringBuilder ipAddressText = new StringBuilder();

            using (StreamReader sr = new StreamReader("config.txt"))
            {
                string[] ipDaConfig = File.ReadAllLines("config.txt");

                for (int i = 0; i < ipDaConfig.Length && i < 10; i++)
                {
                    if (!string.IsNullOrWhiteSpace(ipDaConfig[i]))
                    {
                        ipAddressText.AppendLine(ipDaConfig[i]);
                    }
                }
            }
        }
    }

}

