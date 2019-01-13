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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SiteSheets
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PersonEntry : Page
    {
        AppPersistance app;
        PersonType personType;
        

        public PersonEntry()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var parameters = (NameEntryParams)e.Parameter;
            this.app = parameters.Appdata;
            this.personType = parameters.FormType;
            if(this.personType == PersonType.Employee)
            {
                wageBox.Visibility = Visibility.Visible;
            }
            
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            switch (personType)
            {
                //todo fix all person types.
                case PersonType.Employee:
                    var employee = new Employee(firstNameBox.Text, lastNameBox.Text, phoneBox.Text, cityBox.Text, streetAddressBox.Text,
                        emailBox.Text, UInt32.Parse(wageBox.Text)); //if it isn't parsable we crash. This is an alpha.
                    app.AddEmployee(employee);
                    break;
                case PersonType.Contractor:
                    var contractor = new Contractor(firstNameBox.Text, lastNameBox.Text, phoneBox.Text, cityBox.Text, streetAddressBox.Text);
                    app.AddContractor(contractor);
                    this.Frame.Navigate(typeof(MainPage), app);
                    break;
                case PersonType.Client:
                    var client = new Client(firstNameBox.Text, lastNameBox.Text, phoneBox.Text, cityBox.Text, streetAddressBox.Text);
                    app.AddClient(client);
                    this.Frame.Navigate(typeof(MainPage), app);
                    break;
                default:
                    break;
            }
        }
    }
}
