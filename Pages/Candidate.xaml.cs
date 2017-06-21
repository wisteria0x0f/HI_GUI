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
    /// Candidate.xaml の相互作用ロジック
    /// </summary>
    public partial class Candidate : Page
    {
        public Candidate()
        {
            InitializeComponent();
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            Common.candidates = this.calendar.SelectedDates;
            Common.inputData = new List<DateTime[]>();
            this.NavigationService.Navigate(new Participant());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            calendar.DisplayDateStart = DateTime.Now;
            Common.window.Title = "Step1. 候補日を入力してください。";
        }
    }
}
