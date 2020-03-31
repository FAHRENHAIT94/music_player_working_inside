using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Windows.Threading;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;





namespace musicplayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();

        public MainWindow()
        {
            
            InitializeComponent();
          

        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null)
            {
                //txt_sure.Text = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));

            }
            else { }
            //txt_sure.Text = "No file selected...";
        }





        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        int sayac = 0;
        
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (sayac % 2 == 0)
            {
                for (int i = 0; i < lstbox_music.Items.Count; i++)
                {
                    if (musicplayer[lstbox_music.SelectedIndex].Numara == i)
                    {

                        mediaPlayer.Open(new Uri(openFileDialog.FileNames[i]));
                        parca_adı.Text = musicplayer[lstbox_music.SelectedIndex].Parça_ad;
                        mediaPlayer.Play();
                        playiconmeterial.Kind = PackIconKind.Pause;


        
                    }

                }






            }
            else
            {
                mediaPlayer.Pause();
                playiconmeterial.Kind = PackIconKind.Play;
            }
            sayac++;




        }



        private void btn_restart(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            mediaPlayer.Play();
        }

        private class parcaproperty
        {
            public string Parça_ad { get; set; }
            public Int64 Numara { get; set; }
            public string Parca_date { get; set; }

        }
        ObservableCollection<parcaproperty> musicplayer = new ObservableCollection<parcaproperty>();


        OpenFileDialog openFileDialog = new OpenFileDialog();
        private void btn_add(object sender, RoutedEventArgs e)
        {
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                mediaPlayer.Open(new Uri(openFileDialog.FileName));


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            ////////////////////
            //musicname.Text = openFileDialog.SafeFileName;

            string[] listselectedmusic = openFileDialog.SafeFileNames;
            for (int i = 0; i < listselectedmusic.ToList().Count; i++)
            {
                lstbox_music.Items.Add(openFileDialog.SafeFileNames[i]);

                musicplayer.Add(new parcaproperty
                {
                    Numara = i,
                    Parca_date = openFileDialog.FileNames.ToString(),
                    Parça_ad = listselectedmusic[i].ToString()
                });
            }





            //lstbox_music.ItemsSource = musicplayer ;




        }

        private void lstbox_music_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < lstbox_music.Items.Count; i++)
            {
                if (musicplayer[lstbox_music.SelectedIndex].Numara == i)
                {

                    mediaPlayer.Open(new Uri(openFileDialog.FileNames[i]));
                    mediaPlayer.Play();
                    playiconmeterial.Kind = PackIconKind.Pause;
                    parca_adı.Text = musicplayer[lstbox_music.SelectedIndex].Parça_ad;
                }

            }

        }
    }
}
