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
    /// Interaction logic for CRUDWindow.xaml
    /// </summary>
    public partial class CRUDWindow : Window {
        TESTEntities db = new TESTEntities();

        public CRUDWindow() {

            InitializeComponent();

            comboBox1.ItemsSource = db.Departments.ToList();
            comboBox1.DisplayMemberPath = "Department1";
            comboBox1.SelectedValuePath = "ID";

            comboBox2.ItemsSource = db.Departments.ToList();
            comboBox2.DisplayMemberPath = "Department1";
            comboBox2.SelectedValuePath = "ID";

            comboBox4.ItemsSource = db.Departments.ToList();
            comboBox4.DisplayMemberPath = "Department1";
            comboBox4.SelectedValuePath = "ID";             

        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e) {

            if (comboBox1.SelectedValue != null && textBox1.Text != "" && textBox2.Text != "") {
                var FN = textBox1.Text;
                var LN = textBox2.Text;
                var assoc = new Associate();
                var DeptID = comboBox1.SelectedValue;

                assoc.FirstName = FN;
                assoc.LastName = LN;
                assoc.DepartmentID = (Int32)DeptID;
                
                db.Associates.Add(assoc);
                db.SaveChanges();

                MessageBox.Show("Record Created");
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.SelectedValue = null;
            }

            

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e) {
            if (comboBox4.SelectedValue != null && textBox7.Text != "" && textBox8.Text != "") {
                var FN = textBox7.Text;
                var LN = textBox8.Text;
                var assoc = new Associate();
                var DeptID = comboBox4.SelectedValue;
                var ass = db.Associates.Where(x => x.DepartmentID == (Int32)DeptID).Where(y => y.FirstName == FN).Where(z => z.LastName == LN).FirstOrDefault();

                if (ass != null) {
                    db.Associates.Remove(ass);
                    db.SaveChanges();

                    MessageBox.Show("Record Deleted");
                    textBox7.Text = "";
                    textBox8.Text = "";
                    comboBox4.SelectedValue = null;
                }
                else {
                    MessageBox.Show("No matches found.  Please check the spelling and please check the department.");
                }


            }
            else {
                MessageBox.Show("Please fill out all fields");
            }
        }

        private void buttonRead_Click(object sender, RoutedEventArgs e) {


            if (comboBox2.SelectedValue != null) {

                var listAssoc = db.Associates.ToList().Where(x=>x.DepartmentID == (Int32)comboBox2.SelectedValue);

                var output = "";
                int counter = 1;
                foreach (var item in listAssoc) {
                    output += counter + "). " + item.FullName + "\n";
                    counter ++;
                }

              
                MessageBox.Show(output);
            }             
            


        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e) {
            UPDATEWindow uw = new UPDATEWindow();
            uw.Show();
            this.Close();
        }
    }
}
