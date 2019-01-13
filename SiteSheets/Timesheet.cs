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
        public Dictionary<Employee, uint> hours;
        public List<string> CompletedJobs;
        public Dictionary<string, uint> MaterialsUsed;
    }
}
