using System;
using System.Collections.Generic;
using Polenter.Serialization;
using Windows.Storage;
using System.IO;
using System.Diagnostics;


namespace SiteSheets
{
    class AppPersistance
    {
        public List<Contractor> contractors;
        public List<Client> clients = new List<Client>();
        public List<Employee> employees = new List<Employee>();
        string contractorFolder = "Contractors";
        string employeeFolder = "Employees";
        string clientFolder = "Clients";

        public AppPersistance()
        {
            //code to check if serialized data exists.
            //if so load it.
            
            
            //if not create new
            contractors = new List<Contractor>();
            clients = new List<Client>();
            employees = new List<Employee>();
        }

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
        
        public async void SaveData()
        {

            var serializer = new SharpSerializer(); //serialize as binary xml.
           
            //This is all a big work around for how types are expected to be written to
            //the local folder.

            var appFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(contractorFolder, CreationCollisionOption.OpenIfExists);
            foreach (var item in contractors)
            {
                Stream stream = new MemoryStream();
                serializer.Serialize(item, stream);
                StorageFile storage = await appFolder.CreateFileAsync(item.ToString() + ".xml", CreationCollisionOption.ReplaceExisting);
                StreamReader reader = new StreamReader(stream);
                string text = reader.ReadToEnd();
                stream.Dispose();
                await FileIO.WriteTextAsync(storage, text);
                reader.Dispose();
            }

            appFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(employeeFolder, CreationCollisionOption.OpenIfExists);
            foreach (var item in employees)
            {
                Stream stream = new MemoryStream();
                serializer.Serialize(item, stream);
                StorageFile storage = await appFolder.CreateFileAsync(item.ToString() + ".xml", CreationCollisionOption.ReplaceExisting);
                StreamReader reader = new StreamReader(stream);
                string text = reader.ReadToEnd();
                stream.Dispose();
                await FileIO.WriteTextAsync(storage, text);
                reader.Dispose();
            }

            appFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(clientFolder, CreationCollisionOption.OpenIfExists);
            foreach (var item in clients)
            {
                Stream stream = new MemoryStream();
                serializer.Serialize(item, stream);
                StorageFile storage = await appFolder.CreateFileAsync(item.ToString() + ".xml", CreationCollisionOption.ReplaceExisting);
                StreamReader reader = new StreamReader(stream);
                string text = reader.ReadToEnd();
                stream.Dispose();
                await FileIO.WriteTextAsync(storage, text);
                reader.Dispose();
            }
        }

        public async void LoadData()
        {
            var serializer = new SharpSerializer();

            //This is all a big work around for how types are expected to be written to
            //the local folder.

            var contractorFolder = await ApplicationData.Current.LocalFolder.GetFolderAsync(this.contractorFolder);
            var files = await contractorFolder.GetFilesAsync();
            foreach (var item in files)
            {

            }
            
            throw new NotImplementedException();
        }

    }
}
