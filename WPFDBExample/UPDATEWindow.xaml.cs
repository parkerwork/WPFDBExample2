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

namespace WPFDBExample {
    /// <summary>
    /// Interaction logic for UPDATEWindow.xaml
    /// </summary>
    public partial class UPDATEWindow : Window {

        TESTEntities db = new TESTEntities();

        public UPDATEWindow() {
            InitializeComponent();
            
            var myList = db.Associates.ToList();
            dataGrid.ItemsSource = myList;

            var myOtherList = db.Departments.ToList();
            Departments.ItemsSource = myOtherList;
            Departments.DisplayMemberPath = "Department1";
            Departments.SelectedValuePath = "ID";

            Binding b = new Binding("DepartmentID");
            Departments.SelectedValueBinding = b;

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            db.SaveChanges();
        }

        private void dataGrid_AddingNewItem(object sender, InitializingNewItemEventArgs e) {

            var ass = (Associate)e.NewItem;
            ass.DepartmentID = 1;

            db.Associates.Add(ass);
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

       
    }
}
