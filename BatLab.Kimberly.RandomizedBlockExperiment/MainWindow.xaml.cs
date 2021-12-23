using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace BatLab.Kimberly.RandomizedBlockExperiment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Tactors tactors;
        private Response[] responses;
        private Random rand = new Random();
        private Pattern[] patterns;
        private Pattern selectedPattern;
        private Stopwatch stopWatch;
        private int prevBlockInterval = 0;
        private int currentBlockInterval = 10;

        private int index = 0;
        private bool enterDisabled;
        public MainWindow()
        {
            InitializeComponent();
            tactors = new Tactors();
            responses = new Response[120];
            patterns = Populator.SetupPatterns();
            enterDisabled = false;
            stopWatch = new Stopwatch();

            selectedPattern = patterns[rand.Next(currentBlockInterval)];
            BlockNumber.Content = $"Block Number: {selectedPattern.BlockNumber}" +
                $"\nWarning: {selectedPattern.Warning}" +
                $"\nLocation: {selectedPattern.SeatLocation}" +
                $"\nSequence: {selectedPattern.TactorSequence}" +
                $"\n{index}/120 Trials Completed";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter && !enterDisabled)
            {
                NextBtn.Visibility = Visibility.Visible;
                StartTimerBtn.Visibility = Visibility.Hidden;

                stopWatch.Stop();

            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Canvas_Sample_Buttons.Visibility = Visibility.Hidden;
            Canvas_Experiment_Window.Visibility = Visibility.Visible;
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            StartTimerBtn.Visibility = Visibility.Visible;
            NextBtn.Visibility = Visibility.Hidden;
            enterDisabled = true;

            //Save response
            TimeSpan timeSpan = stopWatch.Elapsed;
            responses[index] = new Response
            {
                BlockInfo = selectedPattern.BlockNumber,
                ReactionTime = timeSpan.TotalMilliseconds, //todo,
                Question1 = new TextRange(Q1Answer.Document.ContentStart, Q1Answer.Document.ContentEnd).Text,
                AccuracyRating = int.Parse(TxtAccuracyRating.Text),
                IntuitivenessRating = int.Parse(TxtIntuitivenessRating.Text)
            };
            index++;
            stopWatch.Reset();

            if(index == 120)
            {
                //TODO close window and output data here
                Array.Sort(patterns, new Comparison<Pattern>((x, y) => x.BlockNumber.CompareTo(y.BlockNumber)));

                foreach(var p in patterns)
                {
                    Debug.WriteLine(p.BlockNumber);
                }
                Close();
                return;

            }

            selectedPattern.Counter--;
            if(index % 30 == 0)
            {
                prevBlockInterval = currentBlockInterval;
                currentBlockInterval += 10;
            }

            System.Diagnostics.Debug.WriteLine(prevBlockInterval + " " + currentBlockInterval);
            while ((selectedPattern = patterns[rand.Next(prevBlockInterval, currentBlockInterval)]).Counter == 0) ;

            //Update labels
            Q1Answer.Document.Blocks.Clear();
            TxtAccuracyRating.Text = "";
             TxtIntuitivenessRating.Text = "";
            BlockNumber.Content = $"Block Number: {selectedPattern.BlockNumber}" +
            $"\nWarning: {selectedPattern.Warning}" +
            $"\nLocation: {selectedPattern.SeatLocation}" +
            $"\nSequence: {selectedPattern.TactorSequence}" +
            $"\n{index}/120 Trials Completed";
        }

        private void StartTimer_Click(object sender, RoutedEventArgs e)
        {
            StartTimerBtn.Visibility = Visibility.Hidden;
            NextBtn.Visibility = Visibility.Hidden;
            enterDisabled = false;

            //TODO Start stopwatch and vibrate tactors
            
            var tactorsStringArray = selectedPattern.TactorSequence.Split(new string[] { "->", "," }, System.StringSplitOptions.RemoveEmptyEntries);
            var tactorsArray = Array.ConvertAll(tactorsStringArray, int.Parse);
            var doubleSequence = int.Parse(selectedPattern.BlockNumber.Substring(0, 1)) % 2 == 0;
            var isSimultaneous = selectedPattern.IsSimultaneous.HasValue;
            var isHeadway = int.Parse(selectedPattern.BlockNumber.Substring(0, 1)) >= 9;
            var isForwardCollision = int.Parse(selectedPattern.BlockNumber.Substring(0, 1)) == 9;

            stopWatch.Start();
            //tactors.pulseTactors(tactorsArray, doubleSequence, isSimultaneous, isHeadway, isForwardCollision);

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

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtAccuracyRating_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtIntuitivenessRating_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
