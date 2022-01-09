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
using System.Windows.Shapes;

namespace JocRobot
{
    /// <summary>
    /// Lógica de interacción para wndTauler.xaml
    /// </summary>
    public partial class wndTauler : Window
    {
        int nFiles;
        int nColumnes;
        int nMoviments = 0;
        Image[,] tauler;
        int[,] taulerNum;
        int filaCopa, columnaCopa;
        public wndTauler()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow elMeuOwner = (MainWindow)Owner;
            nFiles = elMeuOwner.NumFiles;
            nColumnes = elMeuOwner.NumColumnes;
            CreaTauler();
            InsertaTauler(tauler);
        }

        private void InsertaTauler(Image[,] tauler)
        {
            grdGraella.Children.Clear();
            for (int fila = 0; fila < tauler.GetLength(0); fila++)
            {
                for (int columna = 0; columna < tauler.GetLength(1); columna++)
                {
                    if(tauler[fila, columna] != null)
                    {
                        DockPanel dck = new DockPanel();
                        dck.Children.Add(tauler[fila, columna]);
                        Grid.SetRow(dck, fila);
                        Grid.SetColumn(dck, columna);
                        grdGraella.Children.Add(dck);
                        
                    }
                }
            }
        }

        private void CreaTauler()
        { 
            grdGraella.ShowGridLines = true;
            for (int nFila = 0; nFila < nFiles; nFila++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(1, GridUnitType.Star);
                grdGraella.RowDefinitions.Add(rowDefinition);
            }
            for (int nColumna = 0; nColumna < nColumnes; nColumna++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                columnDefinition.Width = new GridLength(1, GridUnitType.Star);
                grdGraella.ColumnDefinitions.Add(columnDefinition);
            }
            tauler = new Image[nFiles, nColumnes];
            taulerNum = new int[nFiles, nColumnes];
            for(int i = 0; i < tauler.GetLength(0); i++)
            {
                for(int j = 0; j < tauler.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                    {
                        tauler[i, j] = new Image();
                        taulerNum[i, j] = 1;
                        tauler[i, j].Source = new BitmapImage(new Uri(@"imatges/robot1.jpg", UriKind.Relative));
                    }
                    else if (i == tauler.GetLength(0) - 1 && j == tauler.GetLength(1) - 1)
                    {
                        tauler[i, j] = new Image();
                        taulerNum[i, j] = 2;
                        tauler[i, j].Source = new BitmapImage(new Uri(@"imatges/robot2.png", UriKind.Relative));
                    }
                    else if (i == nFiles / 2 && j == nColumnes / 2)
                    {
                        filaCopa = i;
                        columnaCopa = j;
                        tauler[i, j] = new Image();
                        taulerNum[i, j] = 3;
                        tauler[i, j].Source = new BitmapImage(new Uri(@"imatges/copa.jpg", UriKind.Relative));
                    }
                    else
                    {
                        tauler[i, j] = null;
                        taulerNum[i, j] = 0;
                    }
                }
            }
        }
        private void ActualitzaMoviments(TextBlock tb, int nMoviments)
        {
            tb.Text = String.Format("Número de moviments -> {0}", nMoviments); ;
        }

        private void grdGraella_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                MouRobot1(e.Key);
                nMoviments++;
                ActualitzaMoviments(tbMoviments,nMoviments);
            }
            else if (e.Key == Key.Down)
            {
                MouRobot1(e.Key);
                nMoviments++;
                ActualitzaMoviments(tbMoviments, nMoviments);
            }
            else if (e.Key == Key.Left)
            {
                MouRobot1(e.Key);
                nMoviments++;
                ActualitzaMoviments(tbMoviments, nMoviments);
            }
            else if (e.Key == Key.Right)
            {
                MouRobot1(e.Key);
                nMoviments++;
                ActualitzaMoviments(tbMoviments, nMoviments);
            }
            else if (e.Key == Key.W)
            {
                MouRobot2(e.Key);
                nMoviments++;
                ActualitzaMoviments(tbMoviments, nMoviments);
            }
            else if (e.Key == Key.S)
            {
                MouRobot2(e.Key);
                nMoviments++;
                ActualitzaMoviments(tbMoviments, nMoviments);
            }
            else if (e.Key == Key.A)
            {
                MouRobot2(e.Key);
                nMoviments++;
                ActualitzaMoviments(tbMoviments, nMoviments);
            }
            else if (e.Key == Key.D)
            {
                MouRobot2(e.Key);
                nMoviments++;
                ActualitzaMoviments(tbMoviments, nMoviments);
            }
            MouImatges(tauler);
            InsertaTauler(tauler);
        }

        private void MouImatges(Image[,] tauler)
        {
            for (int fila = 0; fila < tauler.GetLength(0); fila++)
            {
                for (int columna = 0; columna < tauler.GetLength(1); columna++)
                {
                    tauler[fila, columna] = null;
                }
            }
            for (int i = 0; i <taulerNum.GetLength(0); i++)
            {
                for(int j = 0; j < taulerNum.GetLength(1); j++)
                {
                    if (taulerNum[i, j] == 1)
                    {
                        tauler[i, j] = new Image();
                        tauler[i, j].Source = new BitmapImage(new Uri(@"imatges/robot1.jpg", UriKind.Relative));
                    }
                    else if (taulerNum[i, j] == 2)
                    {
                        tauler[i, j] = new Image();
                        tauler[i, j].Source = new BitmapImage(new Uri(@"imatges/robot2.png", UriKind.Relative));
                    }
                    else if (taulerNum[i,j] == 3)
                    {
                        tauler[i, j] = new Image();
                        tauler[i, j].Source = new BitmapImage(new Uri(@"imatges/copa.jpg", UriKind.Relative));
                    }
                }
            }
        }

        private void MouRobot1(Key key)
        {
            int fila = 0, columna = 0;
            bool mogut = false;
            while(fila < taulerNum.GetLength(0) && !mogut)
            {
                while (columna < taulerNum.GetLength(1) && !mogut)
                {
                    if (taulerNum[fila, columna] == 1)
                    {
                        if (key == Key.Up)
                        {
                            if (fila - 1 < 0)
                                taulerNum[tauler.GetLength(0) - 1, columna] = 1;
                            else taulerNum[fila - 1, columna] = 1;
                            taulerNum[fila, columna] = 0;
                            mogut = true;
                        }
                        else if (key == Key.Down)
                        {
                            if (fila + 1 >= taulerNum.GetLength(0))
                                taulerNum[0, columna] = 1;
                            else taulerNum[fila + 1, columna] = 1;
                            taulerNum[fila, columna] = 0;
                            mogut = true;
                        }
                        else if (key == Key.Left)
                        {
                            if (columna - 1 < 0)
                                taulerNum[fila, taulerNum.GetLength(1) - 1] = 1;
                            else taulerNum[fila, columna - 1] = 1;
                            taulerNum[fila, columna] = 0;
                            mogut = true;
                        }
                        else if (key == Key.Right)
                        {
                            if (columna + 1 >= taulerNum.GetLength(0))
                                taulerNum[fila, 0] = 1;
                            else taulerNum[fila, columna + 1] = 1;
                            taulerNum[fila, columna] = 0;
                            mogut = true;
                        }
                        if (fila == filaCopa && columna == columnaCopa)
                        {
                            MessageBox.Show("Robot 1 HA GUANYAT!!!");
                            this.Close();
                        }
                    }
                    else columna++;
                }
                columna = 0;
                fila++;
            }
        }
        private void MouRobot2(Key key)
        {
            int fila = 0, columna = 0;
            bool mogut = false;
            while (fila < taulerNum.GetLength(0) && !mogut)
            {
                while (columna < taulerNum.GetLength(1) && !mogut)
                {
                    if (taulerNum[fila, columna] == 2)
                    {
                        if (key == Key.W)
                        {
                            if (fila - 1 < 0)
                                taulerNum[tauler.GetLength(0) - 1, columna] = 2;
                            else taulerNum[fila - 1, columna] = 2;
                            taulerNum[fila, columna] = 0;
                            mogut = true;
                        }
                        else if (key == Key.S)
                        {
                            if (fila + 1 >= taulerNum.GetLength(0))
                                taulerNum[0, columna] = 1;
                            else taulerNum[fila + 1, columna] = 2;
                            taulerNum[fila, columna] = 0;
                            mogut = true;
                        }
                        else if (key == Key.A)
                        {
                            if (columna - 1 < 0)
                                taulerNum[fila, taulerNum.GetLength(1) - 1] = 2;
                            else taulerNum[fila, columna - 1] = 2;
                            taulerNum[fila, columna] = 0;
                            mogut = true;
                        }
                        else if (key == Key.D)
                        {
                            if (columna + 1 >= taulerNum.GetLength(0))
                                taulerNum[fila, 0] = 2;
                            else taulerNum[fila, columna + 1] = 2;
                            taulerNum[fila, columna] = 0;
                            mogut = true;
                        }
                        if (fila == filaCopa && columna == columnaCopa)
                        {
                            MessageBox.Show("Robot 2 HA GUANYAT!!!");
                            this.Close();
                        }
                    }
                    else columna++;
                }
                columna = 0;
                fila++;
            }
        }
    }

        
    }

