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

namespace BatLab.Kimberly.RandomizedBlockExperiment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Tactors tactors;
        public MainWindow()
        {
            InitializeComponent();
            tactors = new Tactors();
        }

        #region Sample Buttons Click Events
        private void Left_Turn_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Right_Turn_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void U_Turn_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Speed_Up_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Slow_Down_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Left_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Right_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Pan_Back_to_Front_L_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Pan_back_to_Front_R_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Speeding_Btn_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}
