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


namespace WPFDBExample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        TESTEntities db = new TESTEntities();

        public MainWindow() {

            InitializeComponent();
            
            comboBox.ItemsSource = db.Departments.ToList();
            comboBox.DisplayMemberPath = "Department1";
            comboBox.SelectedValuePath = "ID";
        }
               
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            int deptSelected = (Int32)comboBox.SelectedValue;
            comboBox1.ItemsSource = db.Associates.Where(x => x.DepartmentID == deptSelected).ToList();
            comboBox1.DisplayMemberPath = "FullName";
            comboBox1.SelectedValuePath = "ID";
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e) {
                        
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            CRUDWindow cw = new CRUDWindow();
            cw.Show();
            this.Close();
        }
    }
}
