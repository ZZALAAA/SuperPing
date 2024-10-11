using System.Diagnostics.Eventing.Reader;
using System.IO;
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


        }
         DispatcherTimer Timer;
        private void timer_Tick (object sender, EventArgs e)
        {

            string indirizzo = txtIP00.Text;
            if (string.IsNullOrEmpty(indirizzo))
            {
                StatIcon.Stretch = Stretch.Fill;
                StatIcon.Source = bi3; // Immagine "errore"
            }
            else
            {
                Ping pinger0 = new Ping();
                PingReply reply0 = pinger0.Send(indirizzo);
                string stato0 = reply0.Status.ToString();
                string tempo0 = reply0.RoundtripTime.ToString();
                txtStatus00.Text = stato0;
                txtMs00.Text = tempo0;
                if (int.Parse(tempo0) < 50)
                {
                    StatIcon.Stretch = Stretch.Fill;
                    StatIcon.Source = bi1; // Immagine "ok"
                }
                else if (int.Parse(tempo0) <= 100)
                {
                    StatIcon.Stretch = Stretch.Fill;
                    StatIcon.Source = bi2; // Immagine "attention"
                }
                else
                {
                    StatIcon.Stretch = Stretch.Fill;
                    StatIcon.Source = bi3; // Immagine "errore"
                }
            }




            string indirizzo1 = txtIP01.Text;
            if (string.IsNullOrEmpty(indirizzo1))
            {
                StatIcon2.Stretch = Stretch.Fill;
                StatIcon2.Source = bi3; // Immagine "errore"
            }
            else
            {
                Ping pinger1 = new Ping();
                PingReply reply1 = pinger1.Send(indirizzo1);
                string stato1 = reply1.Status.ToString();
                string tempo1 = reply1.RoundtripTime.ToString();
                txtStatus01.Text = stato1;
                txtMs01.Text = tempo1;


                else if (int.Parse(tempo1) < 50)
                {
                    StatIcon2.Stretch = Stretch.Fill;
                    StatIcon2.Source = bi1; // Immagine "ok"
                }
                else if (int.Parse(tempo1) <= 100)
                {
                    StatIcon2.Stretch = Stretch.Fill;
                    StatIcon2.Source = bi2; // Immagine "attention"
                }
                else
                {
                    StatIcon2.Stretch = Stretch.Fill;
                    StatIcon2.Source = bi3; // Immagine "errore"
                }
            }




            string indirizzo2 = txtIP02.Text;
            if (string.IsNullOrEmpty(indirizzo2))
            {
                StatIcon3.Stretch = Stretch.Fill;
                StatIcon3.Source = bi3; // Immagine "errore"
            }
            else
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
                else if (int.Parse(tempo2) <= 100)
                {
                    StatIcon3.Stretch = Stretch.Fill;
                    StatIcon3.Source = bi2; // Immagine "attention"
                }
                else
                {
                    StatIcon3.Stretch = Stretch.Fill;
                    StatIcon3.Source = bi3; // Immagine "errore"
                }
            }



            string indirizzo3 = txtIP03.Text;
            if (string.IsNullOrEmpty(indirizzo3))
            {
                StatIcon4.Stretch = Stretch.Fill;
                StatIcon4.Source = bi3; // Immagine "errore"
            }
            else
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
                else if (int.Parse(tempo3) <= 100)
                {
                    StatIcon4.Stretch = Stretch.Fill;
                    StatIcon4.Source = bi2; // Immagine "attention"
                }
                else
                {
                    StatIcon4.Stretch = Stretch.Fill;
                    StatIcon4.Source = bi3; // Immagine "errore"
                }
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

            //FILE
            VerificaEAggiungiIPNelFile();

            timer_Tick(sender, e);
            Timer.Tick += new EventHandler(timer_Tick); //nome della funzione da richiamare
            Timer.Interval = TimeSpan.FromSeconds(30); //30 secondi
            Timer.Start(); // usare Timer.Stop() per fermare il timer

        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            Timer.Stop();
        }


        private void VerificaEAggiungiIPNelFile()
        {
            // Leggi gli IP attualmente presenti nel file config.txt
            string[] ipDaConfig;
            try
            {
                ipDaConfig = File.ReadAllLines("config.txt");
            }
            catch (FileNotFoundException)
            {
                // Se il file non esiste, creiamo un nuovo file
                string filePath = "config.txt";
                File.Create(filePath).Dispose();
                ipDaConfig = new string[0]; // File appena creato, quindi vuoto
            }

            // Controlliamo se gli IP inseriti manualmente nei TextBox sono già nel file
            
        }
    }
}