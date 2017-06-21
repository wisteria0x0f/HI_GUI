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

namespace WpfApplication1
{
    /// <summary>
    /// Participant.xaml の相互作用ロジック
    /// </summary>
    public partial class Participant : Page
    {
        public Participant()
        {
            InitializeComponent();
        }

        private void buttonFinish_Click(object sender, RoutedEventArgs e)
        {
            AddInputDates(calendar.SelectedDates.ToArray());
            this.NavigationService.Navigate(new Result());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var candidatesList = Common.candidates.ToList();
            candidatesList.Sort();
            if(candidatesList.Count == 0)
            {
                this.NavigationService.Navigate(new Result());
                return;
            }
            calendar.DisplayDateStart = candidatesList.First();
            calendar.DisplayDateEnd = candidatesList.Last();
            var s = Common.candidates.Min();
            var end = Common.candidates.Max();
            for (var i = s; i <= end; i += new TimeSpan(1, 0, 0, 0, 0))
            {
                if (candidatesList.Contains(i)) continue;
                calendar.BlackoutDates.Add(new CalendarDateRange(i));
            }

            Common.window.Title = "Step2. 参加できる日を入力してください。";

        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            AddInputDates(calendar.SelectedDates.ToArray());
            this.NavigationService.Navigate(new Participant());
        }


        private void AddInputDates(DateTime[] col)
        {
            Common.inputData.Add(col);
        }

        protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseUp(e);

            if((Mouse.Captured is Calendar) || (Mouse.Captured is System.Windows.Controls.Primitives.CalendarItem))
            {
                Mouse.Capture(null);
            }
        }

    }
}
