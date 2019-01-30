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
        Timesheet workingSheet = new Timesheet(null, null, null); //this all gets fixed on the submit.
        
        public MainPage()
        {
            this.InitializeComponent();
            dateBlock.Text = DateTime.Now.ToString("MMM d yyyy");
            //Add some data
            persist = new AppPersistance();
            Contractor con = new Contractor("joe", "blow", "300-200-1111", "san jose", "1134 maudlin", "joe@joe.com");
            Employee emp = new Employee("who", "what", "300-111-2222", "mountain view", "1111 street", "who@some.com", 35);
            Client cli = new Client("jane", "howser", "200-111-2222", "santa clara", "122 bridal street", "bill@bill.com");
            Client cli2 = new Client("able", "adams", "444-121-2222", "scotts valley", "133 orange street", "joe@la.com");

            persist.AddContractor(con);
            persist.AddEmployee(emp);
            persist.AddClient(cli);
            persist.AddClient(cli2);
            persist.SaveData();
        }


        void comboBoxUpdate()
        {
            foreach (var item in persist.contractors)
            {
                contractorComboBox.Items.Add(item);
            }

            foreach (var item in persist.clients)
            {
                customerComboBox.Items.Add(item);
            }

            foreach (var item in persist.employees)
            {
                employeeComboBox.Items.Add(item);
            }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //This feels gross, but it works. When the app is launched it receives
            //e. E doesn't update our combobox. Since args e is a string on first launch
            //we update the combobox with the args for testing. Subsequent navigations
            //will pass AppPersistance type.
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
            //We need to pass parameters to the new page so that the app can properly persist.
            //It currently isn't using a database (it should in future releases).
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

        private void confirmHoursButton_Click(object sender, RoutedEventArgs e)
        {
            loggedHoursBlock.Text += $"Logged {employeeComboBox.SelectedItem} with {employeeHours.Text} hours.\n";
            var employee = (Employee)employeeComboBox.SelectedItem;
            var worked = UInt32.Parse(employeeHours.Text);
            if (workingSheet.hours.ContainsKey(employee)){
                workingSheet.hours[employee] += worked;
            }
            else {
                workingSheet.hours.Add(employee, worked);
            }
        }

        private void contractorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboItem = (Contractor)contractorComboBox.SelectedItem; //has to be converted.
            string email = comboItem.Email;
            var infoText = $"{comboItem.FullName}\n{comboItem.PhoneNumber}\n" + email + "\n" + $"{comboItem.StreetAddress}\n{comboItem.City}";
            informationBlock.Text = infoText;
        }

        private void customerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboItem = (Client)customerComboBox.SelectedItem; //has to be converted.
            string email = comboItem.Email;
            var infoText = $"{comboItem.FullName}\n{comboItem.PhoneNumber}\n" + email + "\n" + $"{comboItem.StreetAddress}\n{comboItem.City}";
            informationBlock.Text = infoText;
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            //For now we'll just create a text file to handle the hoursheets.
            Contractor contractor = (Contractor)contractorComboBox.SelectedItem;
            Client client = (Client)customerComboBox.SelectedItem;
            workingSheet.CompletedJobs = workingSheet.ConvertStringToEnterSeparatedList(workCompleted.Text);
            workingSheet.contractor = contractor;
            workingSheet.client = client;
            this.Frame.Navigate(typeof(ConfirmationPage), workingSheet);
        }
    }
}
