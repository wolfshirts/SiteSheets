using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SiteSheets
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        AppPersistance persist;
        
        public MainPage()
        {
            this.InitializeComponent();
            dateBlock.Text = DateTime.Now.ToString("MMM d yyyy");
            //Add some data
            persist = new AppPersistance();
            Contractor con = new Contractor("joe", "blow", "300-200-1111", "san jose", "1134 maudlin");
            Employee emp = new Employee("who", "what", "300-111-2222", "mountain view", "1111 street", "who@some.com", 35);
            Client cli = new Client("jane", "howser", "200-111-2222", "santa clara", "122 bridal street");
            Client cli2 = new Client("able", "adams", "444-121-2222", "scotts valley", "133 orange street");

            persist.AddContractor(con);
            persist.AddEmployee(emp);
            persist.AddClient(cli);
            persist.AddClient(cli2);
        }


        void comboBoxUpdate()
        {
            foreach (var item in persist.contractors)
            {
                contractorComboBox.Items.Add(item.FullName);
            }

            foreach (var item in persist.clients)
            {
                customerComboBox.Items.Add(item.FullName);
            }

            foreach (var item in persist.employees)
            {
                employeeComboBox.Items.Add(item.FullName);
            }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //This is super hacky.
            base.OnNavigatedTo(e);
            if (e.Parameter.GetType() == typeof(System.String))
            {
                comboBoxUpdate();
            }
            else
            {
                var parameters = (AppPersistance)e.Parameter;
                persist = parameters;
                comboBoxUpdate();
            }
        }

        private void addNewContractorButton_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new NameEntryParams()
            {
                Appdata = persist,
                FormType = PersonType.Contractor
            };

            this.Frame.Navigate(typeof(PersonEntry), parameters);
        }

        private void addNewCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new NameEntryParams()
            {
                Appdata = persist,
                FormType = PersonType.Client
            };

            this.Frame.Navigate(typeof(PersonEntry), parameters);
        }

        private void addNewEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new NameEntryParams()
            {
                Appdata = persist,
                FormType = PersonType.Employee
            };

            this.Frame.Navigate(typeof(PersonEntry), parameters);
        }
    }
}
