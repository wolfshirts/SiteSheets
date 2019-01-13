using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SiteSheets
{
    class AppPersistance
    {
        public List<Contractor> contractors = new List<Contractor>();
        public List<Client> clients = new List<Client>();
        public List<Employee> employees = new List<Employee>();

        public void AddContractor(Contractor contractor)
        {
            contractors.Add(contractor);
            contractors.Sort();
        }

        public void AddClient(Client client)
        {
            clients.Add(client);
            clients.Sort();
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
            employees.Sort();
        }

    }
}
