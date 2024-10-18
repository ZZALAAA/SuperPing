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
        }
        DispatcherTimer Timer;
        DispatcherTimer Timer2;

        private int tempoTrascorso = 0;

        private void timer_Tick(object sender, EventArgs e)
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

            string indirizzo4 = txtIP04.Text;
            if (!string.IsNullOrEmpty(indirizzo4))
            {

                Ping pinger4 = new Ping();
                PingReply reply4 = pinger4.Send(indirizzo4);
                string stato4 = reply4.Status.ToString();
                string tempo4 = reply4.RoundtripTime.ToString();
                txtStatus04.Text = stato4;
                txtMs04.Text = tempo4;

                if (int.Parse(tempo4) < 50)
                {
                    StatIcon5.Stretch = Stretch.Fill;
                    StatIcon5.Source = bi1; // Immagine "ok"
                }
                else
                {
                    StatIcon5.Stretch = Stretch.Fill;
                    StatIcon5.Source = bi2; // Immagine "attention"
                }
            }


            string indirizzo5 = txtIP05.Text;
            if (!string.IsNullOrEmpty(indirizzo5))
            {

                Ping pinger5 = new Ping();
                PingReply reply5 = pinger5.Send(indirizzo5);
                string stato5 = reply5.Status.ToString();
                string tempo5 = reply5.RoundtripTime.ToString();
                txtStatus05.Text = stato5;
                txtMs05.Text = tempo5;

                if (int.Parse(tempo5) < 50)
                {
                    StatIcon6.Stretch = Stretch.Fill;
                    StatIcon6.Source = bi1; // Immagine "ok"
                }
                else
                {
                    StatIcon6.Stretch = Stretch.Fill;
                    StatIcon6.Source = bi2; // Immagine "attention"
                }
            }

            string indirizzo6 = txtIP06.Text;
            if (!string.IsNullOrEmpty(indirizzo6))
            {

                Ping pinger6 = new Ping();
                PingReply reply6 = pinger6.Send(indirizzo6);
                string stato6 = reply6.Status.ToString();
                string tempo6 = reply6.RoundtripTime.ToString();
                txtStatus06.Text = stato6;
                txtMs06.Text = tempo6;

                if (int.Parse(tempo6) < 50)
                {
                    StatIcon7.Stretch = Stretch.Fill;
                    StatIcon7.Source = bi1; // Immagine "ok"
                }
                else
                {
                    StatIcon7.Stretch = Stretch.Fill;
                    StatIcon7.Source = bi2; // Immagine "attention"
                }
            }


            string indirizzo7 = txtIP07.Text;
            if (!string.IsNullOrEmpty(indirizzo7))
            {

                Ping pinger7 = new Ping();
                PingReply reply7 = pinger7.Send(indirizzo7);
                string stato7 = reply7.Status.ToString();
                string tempo7 = reply7.RoundtripTime.ToString();
                txtStatus07.Text = stato7;
                txtMs07.Text = tempo7;

                if (int.Parse(tempo7) < 50)
                {
                    StatIcon8.Stretch = Stretch.Fill;
                    StatIcon8.Source = bi1; // Immagine "ok"
                }
                else
                {
                    StatIcon8.Stretch = Stretch.Fill;
                    StatIcon8.Source = bi2; // Immagine "attention"
                }
            }


            string indirizzo8 = txtIP08.Text;
            if (!string.IsNullOrEmpty(indirizzo8))
            {

                Ping pinger8 = new Ping();
                PingReply reply8 = pinger8.Send(indirizzo8);
                string stato8 = reply8.Status.ToString();
                string tempo8 = reply8.RoundtripTime.ToString();
                txtStatus08.Text = stato8;
                txtMs08.Text = tempo8;

                if (int.Parse(tempo8) < 50)
                {
                    StatIcon9.Stretch = Stretch.Fill;
                    StatIcon9.Source = bi1; // Immagine "ok"
                }
                else
                {
                    StatIcon9.Stretch = Stretch.Fill;
                    StatIcon9.Source = bi2; // Immagine "attention"
                }
            }



            string indirizzo9 = txtIP09.Text;
            if (!string.IsNullOrEmpty(indirizzo9))
            {

                Ping pinger9 = new Ping();
                PingReply reply9 = pinger9.Send(indirizzo9);
                string stato9 = reply9.Status.ToString();
                string tempo9 = reply9.RoundtripTime.ToString();
                txtStatus09.Text = stato9;
                txtMs09.Text = tempo9;

                if (int.Parse(tempo9) < 50)
                {
                    StatIcon10.Stretch = Stretch.Fill;
                    StatIcon10.Source = bi1; // Immagine "ok"
                }
                else
                {
                    StatIcon10.Stretch = Stretch.Fill;
                    StatIcon10.Source = bi2; // Immagine "attention"
                }
            }


        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            // Inizializza i timer
            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(30);
            Timer.Tick += timer_Tick;
            Timer.Start();

            Timer2 = new DispatcherTimer();
            Timer2.Interval = TimeSpan.FromSeconds(1);
            Timer2.Tick += Timer2_Tick;
            Timer2.Start();

            // Inizializza la progress bar
            tempoTrascorso = 0;
            progressBar.Value = 0;
            progressBar.Visibility = Visibility.Visible;

            // Esegui immediatamente il ping e aggiorna la progress bar
            timer_Tick(this, EventArgs.Empty); // Esegue il ping
            Timer2_Tick(this, EventArgs.Empty); // Inizializza la progress bar
        }


        private void Timer2_Tick(object sender, EventArgs e)
        {
            // Aumenta la progress bar ogni secondo
            tempoTrascorso++;
            progressBar.Value = (tempoTrascorso % 30) * (100 / 30);
            if (tempoTrascorso >= 30)
            {
                tempoTrascorso = 0;
                progressBar.Value = 0;
            }
        }
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (Timer != null)
            {
                Timer.Stop();

                Timer2.Stop();
            }
            progressBar.Value = 0;
            tempoTrascorso = 0;
        }
    }
}

