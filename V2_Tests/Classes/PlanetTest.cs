using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2_Tests.Classes
{
    internal class PlanetTest
    {
        private string name;
        private int size;

        public PlanetTest(string name, int size)
        {
            this.name = name;
            this.size = size;
        }
        public PlanetTest(string name)
        {
            this.name = name;
        }

        public void setName(string name) => this.name = name;
        public void setSize(int size) => this.size = size;  

        public string getName() => this.name;
        public int getSize() => this.size;

        public override string ToString()
        {
            return "[Name = " + name + ", size = " + size + "]";
        }
    }
}
