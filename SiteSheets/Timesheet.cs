using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SiteSheets
{
    class Timesheet
    {
        public string date = DateTime.Now.ToString("MMM d yyyy");
        public Contractor contractor;
        public Client client;
        public Dictionary<Employee, uint> hours = new Dictionary<Employee, uint>();
        public List<string> CompletedJobs;
        public string FormattedText;
        //future addition
        //public Dictionary<string, uint> MaterialsUsed;

        public Timesheet(Contractor con, Client cli, List<string> jobs)
        {
            contractor = con;
            client = cli;
            CompletedJobs = jobs;
        }

        public string GenerateText()
        {
            var sep = "------------------------------\n";
            var contractorData = $"{contractor.FullName}\n{contractor.PhoneNumber}\n{contractor.Email}\n{contractor.StreetAddress}\n{contractor.City}\n\n";
            var clientData = $"{client.FullName}\n{client.PhoneNumber}\n{client.Email}\n{client.StreetAddress}\n{client.City}\n\n";
            string employeeData = "";
            string jobs = null;
            var header = $"Timesheet Report for: {date}\n\n";
            var fixme = header + "Contractor:\n" + contractorData + "Client:\n" + clientData + sep + "\n\n";

            foreach (KeyValuePair<Employee, uint> pair in hours)
            {
                decimal pay = pair.Key.Wage * pair.Value;
                employeeData += $"Worker: {pair.Key} Hours: {pair.Value} Total Pay: {pay}\n" + sep;
            }
            foreach (var item in CompletedJobs)
            {
                jobs += "* " + item + "\n";
            }
            fixme += employeeData + jobs;
            return fixme;
        }

        public List<string> ConvertStringToEnterSeparatedList(string incoming)
        {
            var newList = incoming.Split(Environment.NewLine.ToCharArray()).ToList<string>();
            return newList;
        }
    }
}
