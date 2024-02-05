using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class PlantsCollection : CollectionBase
    {
        private List<Plant> plantsList;

        public List<Plant> getPlantsList()
        {
            return plantsList;
        }

        public PlantsCollection() 
        {
            plantsList = databaseOperator.getPlants();
        }
    }
}
