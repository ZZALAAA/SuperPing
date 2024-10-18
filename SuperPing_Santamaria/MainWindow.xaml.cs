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


        string[] ipAddresses = new string[10];
        Image[] ImageArray = new Image[10];
        TextBox[] IPAddressArray = new TextBox[10];
        TextBox[] StatusArray = new TextBox[10];
        TextBox[] MsArray = new TextBox[10];
        Ping pinger = new Ping();

        DispatcherTimer Timer;
        DispatcherTimer Timer2;


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

            Timer = new DispatcherTimer(); // Inizializza il timer qui
            Timer.Interval = TimeSpan.FromSeconds(1); // Imposta l'intervallo a 1 secondo
            Timer.Tick += timer_Tick; // Assegna l'evento Tick


            //image creation
            for (int i = 0; i < 10; i++)
            {
                ImageArray[i] = new Image();
                ImageArray[i].Source = new BitmapImage(new Uri("error.png", UriKind.Relative));
                ImageArray[i].Source = new BitmapImage(new Uri("attention.png", UriKind.Relative));
                ImageArray[i].Source = new BitmapImage(new Uri("ok.png", UriKind.Relative));
                Grid.SetRow(ImageArray[i], i + 2);
                Grid.SetColumn(ImageArray[i], 3);
                this.gridPing.Children.Add(ImageArray[i]);
                ImageArray[i].Visibility = Visibility.Hidden;
            }


            //IPAddress array creation
            for (int i = 0; i < 10; i++)
            {
                IPAddressArray[i] = new TextBox();
                IPAddressArray[i].Text = "";
                Grid.SetRow(IPAddressArray[i], i + 2);
                Grid.SetColumn(IPAddressArray[i], 1);
                this.gridPing.Children.Add(IPAddressArray[i]);
            }

            //Status array creation
            for (int i = 0; i < 10; i++)
            {
                StatusArray[i] = new TextBox();
                StatusArray[i].Text = " ";
                StatusArray[i].IsReadOnly = true;
                Grid.SetRow(StatusArray[i], i + 2);
                Grid.SetColumn(StatusArray[i], 2);
                this.gridPing.Children.Add(StatusArray[i]);
            }

            //Ms array creation
            for (int i = 0; i < 10; i++)
            {
                MsArray[i] = new TextBox();
                MsArray[i].Text = " ";
                MsArray[i].IsReadOnly = true;
                Grid.SetRow(MsArray[i], i + 2);
                Grid.SetColumn(MsArray[i], 4);
                this.gridPing.Children.Add(MsArray[i]);
            }

            // Leggo file config 

            CaricoIpDaConfig(); // chiamo la funzione per caricare gli ip da config
        }

        private int tempoTrascorso = 0;


        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            VerificaEAggiungiIPNelFile();

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
            progressBar.Maximum = 30;

            // Esegui immediatamente il ping e aggiorna la progress bar
            timer_Tick(this, EventArgs.Empty); // Esegue il ping
            Timer2_Tick(this, EventArgs.Empty); // Inizializza la progress bar
        }
        void timer_Tick(object sender, EventArgs e)
        {
            //ping
            string ipDaPingare = null;

            for (int i = 0; i < 10; i++)
            {
                ipDaPingare = IPAddressArray[i].Text;
                if (ipDaPingare == " " || ipDaPingare == "" || ipDaPingare == null)
                {
                    return;
                }

                PingReply reply = pinger.Send(ipDaPingare);
                string status = reply.Status.ToString();
                string millisec = reply.RoundtripTime.ToString();
                double millisecNum = reply.RoundtripTime;
                StatusArray[i].Text = status;
                MsArray[i].Text = millisec;
                if (status == "Success" && millisecNum < 50)
                {
                    ImageArray[i].Visibility = Visibility.Visible;
                    ImageArray[i].Source = new BitmapImage(new Uri("ok.png", UriKind.Relative));

                }
                else if (status == "Success" && millisecNum > 50)
                {
                    ImageArray[i].Visibility = Visibility.Visible;
                    ImageArray[i].Source = new BitmapImage(new Uri("attention.png", UriKind.Relative));

                }
                else
                {
                    ImageArray[i].Visibility = Visibility.Visible;
                    ImageArray[i].Source = new BitmapImage(new Uri("error.png", UriKind.Relative));

                }
            }
        }


        private void Timer2_Tick(object sender, EventArgs e)
        {
            // Aumenta la progress bar ogni secondo
            tempoTrascorso++;

            // Imposta il valore della progress bar
            progressBar.Value = tempoTrascorso;

            // Controlla se il tempo trascorso ha raggiunto il limite
            if (tempoTrascorso >= 30)
            {
                // Resetta il tempo e la progress bar
                tempoTrascorso = 0;
                progressBar.Value = 0;
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {

            Timer.Stop();

            Timer2.Stop();

            progressBar.Value = 0;
            tempoTrascorso = 0;
        }


        private void CaricoIpDaConfig()
        {
            try
            {
                StreamReader sr = new StreamReader("config.txt");
                string[] ipDaConfig = File.ReadAllLines("config.txt");



                for (int i = 0; i < ipDaConfig.Length && i < 10; i++)
                {
                    if (!string.IsNullOrWhiteSpace(ipDaConfig[i]))
                    {
                        IPAddressArray[i].Text = ipDaConfig[i];
                    }
                }

            }
            catch (System.IO.FileNotFoundException)
            {
                string filePath = "config.txt";
                File.Create(filePath).Dispose();
            }
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
            for (int i = 0; i < 10; i++)
            {
                string ipInserito = IPAddressArray[i].Text;

                if (!string.IsNullOrWhiteSpace(ipInserito) && !ipDaConfig.Contains(ipInserito))
                {
                    // Se l'IP non è nel file, lo aggiungiamo
                    using (StreamWriter sw = File.AppendText("config.txt"))
                    {
                        sw.WriteLine(ipInserito);
                    }
                    MessageBox.Show($"Aggiunto nuovo IP nel file config: {ipInserito}");
                }
            }
        }
    }
}

