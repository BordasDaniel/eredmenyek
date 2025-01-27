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
using System.IO;

namespace eredmenyek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Versenyzo> versenyzok = new();
        public MainWindow()
        {
            InitializeComponent();
            lbxVersenyzok.Items.Clear();
            string tartomany = "Eredmenyek.txt";
            Feltolt(tartomany);

            lbxVersenyzok.ItemsSource = versenyzok;
            //lbxVersenyzok.DisplayMemberPath = "Nev"; 
        }

        public void Feltolt(string tartomany)
        {
            try
            {
                string[] bemenet = File.ReadAllLines(tartomany);
                foreach (string sor in bemenet)
                {
                    string[] adatok = sor.Split(';');
                    versenyzok.Add(new Versenyzo()
                    {
                        Sorszaszam = int.Parse(adatok[0]),
                        Nev = adatok[1],
                        Feladat1 = int.Parse(adatok[2]),
                        Feladat2 = int.Parse(adatok[3]),
                        Feladat3 = int.Parse(adatok[4])
                    });
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("Hiba: " + e.Message);
            }
        }

        private void lbxVersenyzok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbxSorszam.Text = (lbxVersenyzok.SelectedItem as Versenyzo).Sorszaszam.ToString();
            tbxNev.Text = (lbxVersenyzok.SelectedItem as Versenyzo).Nev;
            tbx1feladat.Text = (lbxVersenyzok.SelectedItem as Versenyzo).Feladat1.ToString();
            tbx2feladat.Text = (lbxVersenyzok.SelectedItem as Versenyzo).Feladat2.ToString();
            tbx3feladat.Text = (lbxVersenyzok.SelectedItem as Versenyzo).Feladat3.ToString();
        }
    }
}
