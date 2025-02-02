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
        static int[][] PontAranyok;

        public MainWindow()
        {
            InitializeComponent();
            lbxVersenyzok.Items.Clear();
            string tartomany = "Eredmenyek.txt";
            Feltolt(tartomany);

            lbxVersenyzok.ItemsSource = versenyzok;
            //lbxVersenyzok.DisplayMemberPath = "Nev"; 
            PontAranyok = PontszamHely();

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
                        Sorszam = int.Parse(adatok[0]),
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

        private static int[][] PontszamHely()
        {
            static int[][] MatrixFeltolt(int[][] pontAranyok)
            {
                int sor = 0;
                List<int> FeladatPontszamai;

                for (int j = 0; j < pontAranyok.Length; j++)
                {
                    FeladatPontszamai = [];
                    foreach (Versenyzo v in versenyzok)
                    {
                        switch (j)
                        {
                            case 0:
                                FeladatPontszamai.Add(v.Feladat1);
                                break;
                            case 1:
                                FeladatPontszamai.Add(v.Feladat2);
                                break;
                            case 2:
                                FeladatPontszamai.Add(v.Feladat3);
                                break;
                        }
                    }
                    FeladatPontszamai.Sort();
                    FeladatPontszamai.Reverse();

                    for (int i = 0; i < 3; i++)
                    {
                        pontAranyok[sor][i] = FeladatPontszamai[i];
                    }
                    sor++;
                }

                return pontAranyok;
            }

            int[][] pontAranyok =
            {
                new int[3], // Az első feladat top 3 helyezettjeinek pontszámai
                new int[3], // A második feladat top 3 helyezettjeinek pontszámai
                new int[3]  // A harmadik feladat top 3 helyezettjeinek pontszámai
            };

            return MatrixFeltolt(pontAranyok);
        }

        private void lbxVersenyzok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (lbxVersenyzok.SelectedItem != null)
            {
                int index = 0;
                while (index < versenyzok.Count && versenyzok[index].Nev != lbxVersenyzok.SelectedItem.ToString())
                {
                    index++;
                }
                tbxSorszam.Text = versenyzok[index].Sorszam.ToString();
                tbxNev.Text = versenyzok[index].Nev;
                tbx1feladat.Text = versenyzok[index].Feladat1.ToString();
                tbx2feladat.Text = versenyzok[index].Feladat2.ToString();
                tbx3feladat.Text = versenyzok[index].Feladat3.ToString();

                switch(versenyzok[index].Feladat1)
                {
                    case int n when n == PontAranyok[0][0]:
                        imgMedall1.Source = new BitmapImage(new Uri("Images/gold.jpg", UriKind.Relative));
                        break;
                    case int n when n == PontAranyok[0][1]:
                        imgMedall1.Source = new BitmapImage(new Uri("Images/silver.jpg", UriKind.Relative));
                        break;
                    case int n when n == PontAranyok[0][2]:
                        imgMedall1.Source = new BitmapImage(new Uri("Images/bronze.jpg", UriKind.Relative));
                        break;
                    default:
                        imgMedall1.Source = new BitmapImage(new Uri("Images/empty.jpg", UriKind.Relative));
                       
                        break;
                }

                switch (versenyzok[index].Feladat2)
                {
                    case int n when n == PontAranyok[1][0]:
                        imgMedall2.Source = new BitmapImage(new Uri("Images/gold.jpg", UriKind.Relative));
                        break;
                    case int n when n == PontAranyok[1][1]:
                        imgMedall2.Source = new BitmapImage(new Uri("Images/silver.jpg", UriKind.Relative));
                        break;
                    case int n when n == PontAranyok[1][2]:
                        imgMedall2.Source = new BitmapImage(new Uri("Images/bronze.jpg", UriKind.Relative));
                        break;
                    default:
                        imgMedall2.Source = new BitmapImage(new Uri("Images/empty.jpg", UriKind.Relative));
                        break;
                }

                switch (versenyzok[index].Feladat3)
                {
                    case int n when n == PontAranyok[2][0]:
                        imgMedall3.Source = new BitmapImage(new Uri("Images/gold.jpg", UriKind.Relative));
                        break;
                    case int n when n == PontAranyok[2][1]:
                        imgMedall3.Source = new BitmapImage(new Uri("Images/silver.jpg", UriKind.Relative));
                        break;
                    case int n when n == PontAranyok[2][2]:
                        imgMedall3.Source = new BitmapImage(new Uri("Images/bronze.jpg", UriKind.Relative));
                        break;
                    default:
                        imgMedall3.Source = new BitmapImage(new Uri("Images/empty.jpg", UriKind.Relative));
                        break;
                }
            }           
        }
    }
}
