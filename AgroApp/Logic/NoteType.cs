using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class NoteType
    {
        int id;
        string type;

        public int Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }

        public NoteType(int id, string type)
        {
            Id = id;
            Type = type;            
        }
    }
}
