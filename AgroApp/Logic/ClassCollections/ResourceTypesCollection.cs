using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class ResourceTypesCollection : CollectionBase
    {
        private List<ResourceType> resourceTypesList;

        public List<ResourceType> getResourceTypesList()
        {
            return resourceTypesList;
        }

        public ResourceTypesCollection()
        {
            resourceTypesList = databaseOperator.getResourceTypes();
        }
    }
}
