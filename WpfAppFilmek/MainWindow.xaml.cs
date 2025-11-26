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

namespace WpfAppFilmek
{
    public class Film
    {
        public  string Cim {  get; set; }
        public  string Mufaj {  get; set; }
        public  int Hossz {  get; set; }
        public  double Ertekeles {  get; set; }

        public Film(string cim, string mufaj, int hossz, double ertekeles)
        {
            Cim = cim;
            Mufaj = mufaj;
            Hossz = hossz;
            Ertekeles = ertekeles;
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Film> filmList = new List<Film>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FilmBetolt_Click(object sender, RoutedEventArgs e)
        {
            filmList.Clear();
            filmList.Add(new Film("Csillagok Háborúja", "sci-fi", 121, 8.6));
            filmList.Add(new Film("Titanic", "dráma", 195, 7.8));
            filmList.Add(new Film("A Gyűrük Ura", "fantasy", 201, 8.8));
            filmList.Add(new Film("Mátrix", "sci-fi", 136, 8.7));
            filmList.Add(new Film("Shrek", "animáció", 90, 7.9));
            FilmekDG.ItemsSource = filmList;
        }

        private void FilmekSzama_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Összesen {filmList.Count} film van");
        }

        private void LeghosszabbFilmClick(object sender, RoutedEventArgs e)
        {
            if (filmList != null && filmList.Count>0)
            {
                MessageBox.Show("A leghosszabb film: " + filmList.OrderByDescending(f => f.Hossz).First().Cim);
            }
            else
            {
                MessageBox.Show("Nincsenek betöltve a filmek.");
            }
        }

        private void AtlagErtekeles(object sender, RoutedEventArgs e)
        {
            double atlag = 0;
            int index = 0;
            foreach (var item in filmList)
            {
                atlag += item.Ertekeles;
                index++;
            }
            MessageBox.Show($"{atlag / index} a filmek értékelésének átlaga");
        }

        private void CsakScifiSzures(object sender, RoutedEventArgs e)
        {
            var scifi = filmList.Where(f=>f.Mufaj.Equals("sci-fi")).ToList();
            FilmekDG.ItemsSource=scifi;
        }

        public class cimNevek()
        {
            public string Cim { get; set; } 
        }

        private void CsakCimek(object sender, RoutedEventArgs e)
        {
            List<cimNevek> cimNevek = new List<cimNevek>();
            foreach (var item in filmList)
            {
                cimNevek.Add(new cimNevek { Cim = item.Cim });
            }
            FilmekDG.ItemsSource = cimNevek;
        }

        private void jolErtekelt(object sender, RoutedEventArgs e)
        {
            var ertekeles = filmList.Where(f => f.Ertekeles>8).ToList();
            FilmekDG.ItemsSource = ertekeles;
        }

        private void cimRend(object sender, RoutedEventArgs e)
        {
            var rendezes = filmList.OrderBy(f=> f.Cim).ToList();
            FilmekDG.ItemsSource =rendezes;
        }
    }
}