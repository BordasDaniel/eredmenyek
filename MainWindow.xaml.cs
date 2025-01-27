﻿using System.Text;
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
            EremInit();
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

        private static int PontszamHely(int helyezes, int feladat)
        {
            int eredmeny = -1;
            switch(feladat)
            {
                case 1:
                    int max = versenyzok[0].Feladat1;
                    foreach(Versenyzo v in versenyzok)
                    {
                        if (v.Feladat1 > max)
                        {
                            max = v.Feladat1;
                        }
                    }
                    eredmeny = max;
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
            return eredmeny;
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
                tbxSorszam.Text = versenyzok[index].Sorszaszam.ToString();
                tbxNev.Text = versenyzok[index].Nev;
                tbx1feladat.Text = versenyzok[index].Feladat1.ToString();
                tbx2feladat.Text = versenyzok[index].Feladat2.ToString();
                tbx3feladat.Text = versenyzok[index].Feladat3.ToString();
                int elsoPontArany = PontszamHely(1, 1);
                if (elsoPontArany == versenyzok[index].Feladat1)
                {
                    imgMedall1.Source = new BitmapImage(new Uri("Images/gold.jpg", UriKind.Relative));
                }
            }
                


            //if (lbxVersenyzok.SelectedItem != null)
            //{
            //    tbxSorszam.Text = (lbxVersenyzok.SelectedItem as Versenyzo).Sorszaszam.ToString();
            //    tbxNev.Text = (lbxVersenyzok.SelectedItem as Versenyzo).Nev;
            //    tbx1feladat.Text = (lbxVersenyzok.SelectedItem as Versenyzo).Feladat1.ToString();
            //    tbx2feladat.Text = (lbxVersenyzok.SelectedItem as Versenyzo).Feladat2.ToString();
            //    tbx3feladat.Text = (lbxVersenyzok.SelectedItem as Versenyzo).Feladat3.ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Nincs kiválasztott versenyző!");
            //}
        }

        public void EremInit()
        {
            imgMedall1.Source = new BitmapImage(new Uri("Images/empty.jpg", UriKind.Relative));
            imgMedall2.Source = new BitmapImage(new Uri("Images/empty.jpg", UriKind.Relative));
            imgMedall3.Source = new BitmapImage(new Uri("Images/empty.jpg", UriKind.Relative));
        }
    }
}
