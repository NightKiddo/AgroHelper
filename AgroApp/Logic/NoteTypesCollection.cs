using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class NoteTypesCollection : CollectionBase
    {
        private List<NoteType> noteTypesList; 

        public List<NoteType> getNoteTypesList() { return noteTypesList; }

        public NoteTypesCollection()
        {
            noteTypesList = databaseOperator.getNoteTypes();
        }
    }
}
