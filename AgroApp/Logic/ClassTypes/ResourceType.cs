﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class ResourceType
    {
        private int id;
        private string type;

        public int Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }

        public override string ToString()
        {
            return type;
        }

        public ResourceType(int id, string type) 
        {
            this.id = id;
            this.type = type;
        }
    }
}
