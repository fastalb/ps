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

namespace Expenselt
{
    /// <summary>
    /// Логика взаимодействия для ExpenseReport.xaml
    /// </summary>
    public partial class ExpenseReport : Window
    {
        public ExpenseReport()
        {
            InitializeComponent();
        }

        public ExpenseReport(object data) : this()
        {
            this.DataContext = data;
        }
    }
}
