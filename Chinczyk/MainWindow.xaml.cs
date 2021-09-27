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


namespace Chinczyk
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum STATUSGRY { RuchCzerwonego, RuchNiebieskiego, RuchZielonego, RuchZoltego };
        private static int wynikRzutuKostką = 3;
        static List<Border> bPlansza = new List<Border>();
        List<Pionek> czerwonegoPionki = new List<Pionek>();
        List<Pionek> niebieskiegoPionki = new List<Pionek>();
        List<Pionek> zielonegoPionki = new List<Pionek>();
        List<Pionek> zoltegoPionki = new List<Pionek>();
        static int ii = 0;

        public MainWindow()
        {
            InitializeComponent();
            TwórzPlanszę();
            //Twórz czerwone pionki
            for (int i = 0; i < 4; i++)
            {
                Pionek pp = new Pionek(Colors.Red);
                czerwonegoPionki.Add(pp);
                gPlansza.Children.Add(pp.elipsa);
                Grid.SetColumn(pp.elipsa, i + 2);
                Grid.SetRow(pp.elipsa, 2);

            }

            //Twórz inne pionki x3
            for (int i = 0; i < 4; i++)
            {
                Pionek pp = new Pionek(Colors.Blue);
                niebieskiegoPionki.Add(pp);
                gPlansza.Children.Add(pp.elipsa);
                Grid.SetColumn(pp.elipsa, i + 11);
                Grid.SetRow(pp.elipsa, 2);

            }

            for (int i = 0; i < 4; i++)
            {
                Pionek pp = new Pionek(Colors.Green);
                zielonegoPionki.Add(pp);
                gPlansza.Children.Add(pp.elipsa);
                Grid.SetColumn(pp.elipsa, i + 11);
                Grid.SetRow(pp.elipsa, 14);

            }


            for (int i = 0; i < 4; i++)
            {
                Pionek pp = new Pionek(Colors.Yellow);
                zoltegoPionki.Add(pp);
                gPlansza.Children.Add(pp.elipsa);
                Grid.SetColumn(pp.elipsa, i + 2);
                Grid.SetRow(pp.elipsa, 14);

            }

            kostka kosteczka = new kostka();
            Grid.SetColumn(kosteczka.elipsa, 8);
            Grid.SetRow(kosteczka.elipsa, 8);
            gPlansza.Children.Add(kosteczka.elipsa);

            RzutText();
        }
        public void RzutText()
        {
            tbLog.Text = "Rzucono: " + wynikRzutuKostką;
        }

        private void reset(object sender, RoutedEventArgs e)
        {


            List<Border> bPlansza = new List<Border>();
            List<Pionek> czerwonegoPionki = new List<Pionek>();
            List<Pionek> niebieskiegoPionki = new List<Pionek>();
            List<Pionek> zielonegoPionki = new List<Pionek>();
            List<Pionek> zoltegoPionki = new List<Pionek>();

            InitializeComponent();
            //TwórzPlanszę();
            ii = 0;

            //Twórz czerwone pionki
            for (int i = 0; i < 4; i++)
            {
                Pionek pp = new Pionek(Colors.Red);
                czerwonegoPionki.Add(pp);
                gPlansza.Children.Add(pp.elipsa);
                Grid.SetColumn(pp.elipsa, i + 2);
                Grid.SetRow(pp.elipsa, 2);

            }

            //Twórz inne pionki x3
            for (int i = 0; i < 4; i++)
            {
                Pionek pp = new Pionek(Colors.Blue);
                niebieskiegoPionki.Add(pp);
                gPlansza.Children.Add(pp.elipsa);
                Grid.SetColumn(pp.elipsa, i + 11);
                Grid.SetRow(pp.elipsa, 2);

            }

            for (int i = 0; i < 4; i++)
            {
                Pionek pp = new Pionek(Colors.Green);
                zielonegoPionki.Add(pp);
                gPlansza.Children.Add(pp.elipsa);
                Grid.SetColumn(pp.elipsa, i + 11);
                Grid.SetRow(pp.elipsa, 14);

            }


            for (int i = 0; i < 4; i++)
            {
                Pionek pp = new Pionek(Colors.Yellow);
                zoltegoPionki.Add(pp);
                gPlansza.Children.Add(pp.elipsa);
                Grid.SetColumn(pp.elipsa, i + 2);
                Grid.SetRow(pp.elipsa, 14);

            }

            kostka kosteczka = new kostka();
            Grid.SetColumn(kosteczka.elipsa, 8);
            Grid.SetRow(kosteczka.elipsa, 8);
            gPlansza.Children.Add(kosteczka.elipsa);

            RzutText();
        }
        private void klik(object sender, RoutedEventArgs e)
        {
            RzutText();
            Random rnd = new Random();
            wynikRzutuKostką = rnd.Next(1, 7);
            KOSTKA.Content = wynikRzutuKostką;

            ii = ii + 1;
            int z = ii % 4;
            var varr = (STATUSGRY) z;

            label.Text = varr.ToString();
            if (z == 0)
            {
                label.Background = Brushes.Red;
            }
            if (z == 1)
            {
                label.Background = Brushes.Blue;
            }
            if (z == 2)
            {
                label.Background = Brushes.Green;
            }
            if (z == 3)
            {
                label.Background = Brushes.Yellow;
            }

        }

        private static void przestawPionek(Pionek pionek, int nrPola)
        {
            Grid.SetColumn(pionek.elipsa, Grid.GetColumn(bPlansza[nrPola]));
            Grid.SetRow(pionek.elipsa, Grid.GetRow(bPlansza[nrPola]));

        }

        private void TwórzPlanszę()
        {
            
            for (int i = 0; i < 17; i++)
            {
                gPlansza.RowDefinitions.Add(new RowDefinition());
                gPlansza.ColumnDefinitions.Add(new ColumnDefinition());
            }
            //gPlansza.ShowGridLines = true;
            Border bb = new Border();       // dummy
            for (int i = 1; i <= 7; i++) 
                bb = TwórzPole(i, 7);
            bb.CornerRadius = new CornerRadius(3,3,10,3);

            for (int i = 6; i >= 1; i--)
                TwórzPole(7,i);            
            TwórzPole(8, 1);
            for (int i = 1; i <= 7; i++)
                bb = TwórzPole(9, i);
            bb.CornerRadius = new CornerRadius(3, 3, 3, 10);
            for (int i = 10; i <= 15; i++)
                TwórzPole(i, 7);

            //--------------------

            TwórzPole(15, 8);
            for (int i = 15; i >= 9; i--)
                bb = TwórzPole(i, 9);
            bb.CornerRadius = new CornerRadius(10, 3, 3, 3);

            for (int i = 10; i <= 14; i++)
                TwórzPole(9, i);

            for (int i = 9; i >= 7; i--)
                TwórzPole(i, 15);

            for (int i = 14; i >= 9; i--)
                bb = TwórzPole(7, i);
            bb.CornerRadius = new CornerRadius(3, 10, 3, 3);

            for (int i = 6; i >= 1; i--)
                TwórzPole(i, 9);
            TwórzPole(1, 8);
            


        }
       
        private Border TwórzPole(int xx, int yy)
        {
            Border bb = new Border();
            bPlansza.Add(bb);

            bb.Tag = new Point(xx, yy);             ///////////////////////

            Grid.SetColumn(bb, xx);
            Grid.SetRow(bb, yy);

            bb.CornerRadius = new CornerRadius(3);
            bb.BorderBrush = new SolidColorBrush(Colors.Black);
            bb.BorderThickness = new Thickness(1.2);
            bb.Margin = new Thickness(0.2);
            gPlansza.Children.Add(bb);
            return bb;
        }
        class Pionek
        {
            Color gracz;
            public Ellipse elipsa = new Ellipse();
            int polozenieNaPlanszy = -1;
            public Pionek(Color color)
            {
                gracz = color;
                elipsa.Fill = new SolidColorBrush(color);
                elipsa.Stroke = new SolidColorBrush(Colors.Black);
                elipsa.StrokeThickness = 1;
                elipsa.Margin = new Thickness(1.5);

                elipsa.Tag = this;
                elipsa.MouseDown += Elipsa_MouseDown;
            }

            private void Elipsa_MouseDown(object sender, MouseButtonEventArgs e)
            {
                Colors temp;
                bool flag = false;
                // sprawdzenie czy kliknięto właściwy kolor pionka dla aktualnego gracza...
                Ellipse kliknięta = sender as Ellipse;
                Pionek pion = kliknięta.Tag as Pionek;

                int z = ii % 4;
                var varr = (STATUSGRY)z;

                if (z == 0 && pion.gracz == Colors.Red)
                {
                    pion.polozenieNaPlanszy += MainWindow.wynikRzutuKostką;
                    przestawPionek(pion, polozenieNaPlanszy);
                }
                if (z == 1 && pion.gracz == Colors.Blue)
                {
                    pion.polozenieNaPlanszy += MainWindow.wynikRzutuKostką;
                    przestawPionek(pion, polozenieNaPlanszy);
                }
                if (z == 2 && pion.gracz == Colors.Green)
                {
                    pion.polozenieNaPlanszy += MainWindow.wynikRzutuKostką;
                    przestawPionek(pion, polozenieNaPlanszy);
                }
                if (z == 3 && pion.gracz == Colors.Yellow)
                {
                    pion.polozenieNaPlanszy += MainWindow.wynikRzutuKostką;
                    przestawPionek(pion, polozenieNaPlanszy);
                }


            }
            //private void
        }

        class kostka
        {
            public Rectangle elipsa = new Rectangle();

            public kostka()
            {
                elipsa.Fill = new SolidColorBrush(Colors.White);
                elipsa.Stroke = new SolidColorBrush(Colors.Black);
                elipsa.StrokeThickness = 1;
                elipsa.Margin = new Thickness(1.5);

                elipsa.Tag = this;
                elipsa.MouseDown += Elipsa_MouseDown;
            }

            private void Rzuc()
            {
                Random rnd = new Random();
                wynikRzutuKostką = rnd.Next(1, 7);
                
            }

            private void Elipsa_MouseDown(object sender, MouseButtonEventArgs e)
            {
                Rzuc();
                Instance.RzutText();
          
            }


        }
        public static MainWindow Instance
        {
            get { return instance; }
        }

        public static MainWindow instance = new MainWindow();
    }
    
}
