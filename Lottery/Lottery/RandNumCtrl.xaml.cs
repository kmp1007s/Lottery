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

namespace Lottery
{
    public partial class RandNumCtrl : UserControl
    {
        int[] numbers = new int[7];
        Random r = new Random();
        public MainWindow mainWindow { get; set; }

        public RandNumCtrl()
        {
            InitializeComponent();
        }

        private void RandBtn_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("숫자를 추첨합니다.");

            GenerateNumber();
            RenderNumber();
        }

        private void SimulBtn_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("시뮬레이션 화면으로 이동합니다.");
            mainWindow.randCtrl.Visibility = Visibility.Collapsed;
            mainWindow.simulCtrl.Visibility = Visibility.Visible;
        }

        private void GenerateNumber()
        {
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = r.Next(1, 46);
        }

        private void RenderNumber()
        {
            for (int i = 0; i < numberContainer.Children.Count; i++)
                (numberContainer.Children[i] as TextBlock).Text = numbers[i].ToString();
        }
    }
}
