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

namespace JocRobot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public int NumFiles
        {
            get
            {
                return Convert.ToInt32(tbFiles.Text);
            }
        }
        public int NumColumnes
        {
            get
            {
                return Convert.ToInt32(tbColumnes.Text);
            }
        }

        private void btnCreaTauler_Click(object sender, RoutedEventArgs e)
        {
            wndTauler finestra = new wndTauler();
            finestra.Owner = this;
            finestra.ShowDialog();
        }
    }
}
