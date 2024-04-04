using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class Field
    {
        private int id;
        private string name;
        private string description;
        private string coordinates;        
        private Farm farm;
        private Plant plant;
        private double area;

        public Field(int id, string name, string description, string coordinates, Farm farm, Plant plant, double area)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Coordinates = coordinates;
            this.Farm = farm;
            this.Plant = plant;
            this.Area = area;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Coordinates { get => coordinates; set => coordinates = value; }
        public Farm Farm { get => farm; set => farm = value; }
        public Plant Plant { get => plant; set => plant = value; }
        public double Area { get => area; set => area = value; }

        //public override string ToString()
        //{
        //    return $"{id} {name} {description} {coordinates} {farm} {plant} {area + " ha"}";
        //}
    }
}
