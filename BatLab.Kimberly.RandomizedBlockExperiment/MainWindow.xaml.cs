using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Syncfusion.XlsIO;

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

            selectedPattern = patterns[rand.Next(prevBlockInterval, currentBlockInterval)];

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

        private void OutputToSheet()
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Instantiate the Excel application object
                IApplication application = excelEngine.Excel;

                //Assigns default application version
                application.DefaultVersion = ExcelVersion.Excel2013;

                //A new workbook is created equivalent to creating a new workbook in Excel
                //Create a workbook with 1 worksheet
                IWorkbook workbook = application.Workbooks.Create(1);

                //Access first worksheet from the workbook
                IWorksheet worksheet = workbook.Worksheets[0];

                //Setup column headers
                worksheet.Range["A1"].Text = "Block Number";
                worksheet.Range["B1"].Text = "Reaction Time";
                worksheet.Range["C1"].Text = "Question 1";
                worksheet.Range["D1"].Text = "Accuracy Rating";
                worksheet.Range["E1"].Text = "Intuitiveness Rating";

                var row = 2;
                for(int x = 0; x < responses.Length; x++)
                {
                    worksheet.Range[$"A{row}"].Text = responses[x].BlockInfo;
                    worksheet.Range[$"B{row}"].Number = responses[x].ReactionTime;
                    worksheet.Range[$"C{row}"].Text = responses[x].Question1;
                    worksheet.Range[$"D{row}"].Number = responses[x].AccuracyRating;
                    worksheet.Range[$"E{row}"].Number = responses[x].IntuitivenessRating;
                    row++;
                }
                workbook.SaveAs($"C:/Users/batla/source/repos/BatLab.Kimberly.RandomizedBlockExperiment/BatLab.Kimberly.RandomizedBlockExperiment/Data/{TxtParticipantNumber.Text}.xlsx");
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
                ReactionTime = timeSpan.TotalMilliseconds,
                Question1 = new TextRange(Q1Answer.Document.ContentStart, Q1Answer.Document.ContentEnd).Text,
                AccuracyRating = int.Parse(TxtAccuracyRating.Text),
                IntuitivenessRating = int.Parse(TxtIntuitivenessRating.Text)
            };
            index++;
            stopWatch.Stop();
            stopWatch.Reset();

            if(index == 120)
            {
                //TODO close window and output data here
                Array.Sort(patterns, new Comparison<Pattern>((x, y) => x.Sort.CompareTo(y.Sort)));

                foreach(var p in patterns)
                {
                    Debug.WriteLine(p.BlockNumber);
                }

                OutputToSheet();
                Close();
                return;

            }

            selectedPattern.Counter--;
            if(index % 30 == 0)
            {
                prevBlockInterval = currentBlockInterval;
                currentBlockInterval += 10;
            }

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

        private async void StartTimer_Click(object sender, RoutedEventArgs e)
        {
            StartTimerBtn.Visibility = Visibility.Hidden;
            NextBtn.Visibility = Visibility.Hidden;
           
            var cleanedPattern = selectedPattern.TactorSequence.Replace("20(14)", "14");
            cleanedPattern = cleanedPattern.Replace("19(11)", "11");

            cleanedPattern = cleanedPattern.Replace("18(10)", "10");
            cleanedPattern = cleanedPattern.Replace("17(8)", "8");

            var tactorsStringArray = cleanedPattern.Split(new string[] { "->", "," }, StringSplitOptions.RemoveEmptyEntries);
            var tactorsArray = Array.ConvertAll(tactorsStringArray, int.Parse);
            var doubleSequence = int.Parse(selectedPattern.BlockNumber.Substring(0, 1)) % 2 == 0;
            var isSimultaneous = selectedPattern.IsSimultaneous.HasValue;
            var isHeadway = int.Parse(selectedPattern.BlockNumber.ToCharArray()[2].ToString()) == 9 || selectedPattern.BlockNumber.Substring(2, 2) == "10";
            var isForwardCollision = int.Parse(selectedPattern.BlockNumber.ToCharArray()[2].ToString()) == 9;
   
            await tactors.pulseTactors(tactorsArray, doubleSequence, isSimultaneous, isHeadway, isForwardCollision).ConfigureAwait(false);
            enterDisabled = false;
            stopWatch.Start();

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
