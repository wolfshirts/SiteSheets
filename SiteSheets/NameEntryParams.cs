using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSheets
{
    enum PersonType
    {
        Employee,
        Contractor,
        Client
    }

    class NameEntryParams
    {
        public AppPersistance Appdata;
        public PersonType FormType;
    }
}
