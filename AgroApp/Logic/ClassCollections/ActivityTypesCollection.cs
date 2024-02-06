using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class ActivityTypesCollection : CollectionBase
    {
        private List<ActivityType> activityTypesList;

        public List<ActivityType> getactivityTypesList()
        {
            return activityTypesList;
        }

        public ActivityTypesCollection()
        {
            activityTypesList = databaseOperator.getActivityTypes();
        }
    }
}
