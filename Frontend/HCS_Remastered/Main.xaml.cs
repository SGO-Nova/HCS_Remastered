using HCS_Remastered.Models;
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

namespace HCS_Remastered
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        Employee employee = new Employee();
        public Main()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            employee.id = Convert.ToUInt32(textBox.Text);
            employee.name = textBox1.Text;
            employee.Login(textBox2.Text);

            this.textBlock.Text = employee.employeeType;
        }
    }
}
