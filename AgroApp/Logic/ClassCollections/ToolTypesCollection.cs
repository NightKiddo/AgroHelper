using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class ToolTypesCollection : CollectionBase
    {
        private List<ToolType> toolTypesList;

        public List<ToolType> getToolTypesList()
        {
            return toolTypesList;
        }

        public ToolTypesCollection()
        {
            toolTypesList = databaseOperator.getToolTypes();
        }
    }
}
