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
    public partial class SimulCtrl : UserControl
    {
        int[] userNumbers = new int[7];
        int[] resultNums = new int[7];
        Random r = new Random();
        public MainWindow mainWindow { get; set; }

        int winningCount;
    
        int firstTxt = 0;
        int secondTxt = 0;
        int thirdTxt = 0;
        int fourthTxt = 0;
        int fifthTxt = 0;
        int lastTxt = 0;

        public SimulCtrl()
        {
            InitializeComponent();
        }

        private void Prev_Ctrl(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("메인 화면으로 이동합니다.");
            mainWindow.randCtrl.Visibility = Visibility.Visible;
            mainWindow.simulCtrl.Visibility = Visibility.Collapsed;
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (!IsPressedEnter(e) || IsInputIsNull(((TextBox)sender).Text)) return;

            InitPrize();

            for(int i = 0; i < Int64.Parse(simulCnt.Text); i++)
            {
                InitWinningCount();

                GenerateResultNums();
                GenerateUserNums();

                winningCount = CompareNums();

                CheckPrize(winningCount);

                //if (count == 6) RenderPrize(firstPrizeTxt);
                //else if (count == 5 && userNumbers[6] == resultNums[6])
                //    RenderPrize(secondPrizeTxt);
                //else if (count == 4) RenderPrize(thirdPrizeTxt);
                //else if (count == 3) RenderPrize(fourthPrizeTxt);
                //else if (count == 2) RenderPrize(fifthPrizeTxt);
                //else RenderPrize(noPrizeTxt);
            }
            ((TextBox)sender).Text = "";

            RenderAllPrizes();
        }

        //private String StrValuePlus(String str)
        //{
        //    if (str == null) return null;
        //    return (Int64.Parse(str) + 1).ToString();
        //}

        //private void RenderPrize(TextBlock textBlock)
        //{
        //    textBlock.Text = StrValuePlus(textBlock.Text);
        //}
        
        private void RenderPrize(TextBlock txtBlock, String str)
        {
            txtBlock.Text = str;
        }

        private void GenerateResultNums()
        {
            for (int j = 0; j < resultNums.Length; j++)
                resultNums[j] = r.Next(1, 46);
        }

        private void GenerateUserNums()
        {
            for (int j = 0; j < userNumbers.Length; j++)
                userNumbers[j] = r.Next(1, 46);
        }

        private int CompareNums()
        {
            for (int j = 0; j < userNumbers.Length - 1; j++)
                if (resultNums[j] == userNumbers[j]) winningCount++;
            
            return winningCount;
        }

        private void InitPrize()
        {
            InitIntPrize();
            InitXAMLPrize();
        }

        private void InitIntPrize()
        {
            firstTxt = 0;
            secondTxt = 0;
            thirdTxt = 0;
            fourthTxt = 0;
            fifthTxt = 0;
            lastTxt = 0;
        }
        private void InitXAMLPrize()
        {
            firstPrizeTxt.Text = "0";
            secondPrizeTxt.Text = "0";
            thirdPrizeTxt.Text = "0";
            fourthPrizeTxt.Text = "0";
            fifthPrizeTxt.Text = "0";
            noPrizeTxt.Text = "0";
        }

        private void CheckPrize(int winningCount)
        {
            if (winningCount == 6) firstTxt++;
            else if (winningCount == 5 && userNumbers[6] == resultNums[6])
                secondTxt++;
            else if (winningCount == 4) thirdTxt++;
            else if (winningCount == 3) fourthTxt++;
            else if (winningCount == 2) fifthTxt++;
            else lastTxt++;
        }

        private void InitWinningCount()
        {
            winningCount = 0;
        }

        private void RenderAllPrizes()
        {
            RenderPrize(firstPrizeTxt, firstTxt.ToString());
            RenderPrize(secondPrizeTxt, secondTxt.ToString());
            RenderPrize(thirdPrizeTxt, thirdTxt.ToString());
            RenderPrize(fourthPrizeTxt, fourthTxt.ToString());
            RenderPrize(fifthPrizeTxt, fifthTxt.ToString());
            RenderPrize(noPrizeTxt, lastTxt.ToString());
        }

        private bool IsPressedEnter(KeyEventArgs e)
        {
            if (e.Key == Key.Return) return true;
            return false;
        }

        private bool IsInputIsNull(String txt)
        {
            if (txt.Equals("")) return true;
            return false;
        }
    }
}
