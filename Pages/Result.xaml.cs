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
using System.Data;

namespace WpfApplication1
{
    /// <summary>
    /// Result.xaml の相互作用ロジック
    /// </summary>
    public partial class Result : Page
    {
        private Dictionary<DateTime, int> results = new Dictionary<DateTime, int>();
        public Result()
        {
            InitializeComponent();
        }

        private void buttonFinish_Click(object sender, RoutedEventArgs e)
        {
            Common.WindowsClose();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            for (var i = Common.candidates.First(); i <= Common.candidates.Last(); i += new TimeSpan(1, 0, 0, 0, 0))
            {
                results.Add(i, 0);
            }

            foreach (var d in Common.inputData)
            {
                if (d.Count() == 0) continue;
                for (var i = d.First(); i <= d.Last(); i += new TimeSpan(1, 0, 0, 0, 0))
                {
                    if(!results.Any(x => x.Key == i)) continue;
                    results[i]++;
                }
            }

            var m_dt = new DataTable("DataGridTest");

            m_dt.Columns.Add(new DataColumn("date", typeof(string)));
            m_dt.Columns.Add(new DataColumn("population", typeof(int)));

            // サンプルデータ追加
            DataRow newRowItem;
            foreach (var r in results)
            {
                newRowItem = m_dt.NewRow();
                newRowItem["date"] = r.Key.ToShortDateString();
                newRowItem["population"] = r.Value;
                m_dt.Rows.Add(newRowItem);
            }

            // グリッドにバインド
            dataGrid.DataContext = m_dt;

        }
    }
}
