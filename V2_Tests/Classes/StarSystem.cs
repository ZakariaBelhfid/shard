using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2_Tests.Classes
{
    internal class StarSystem
    {
        private List<SystemTest> systemTests = new List<SystemTest>();

        public StarSystem() {
            systemTests = new List<SystemTest>();   
        }


        public List<SystemTest> GetSystemTests() => systemTests;
        public void AddSystem(SystemTest test) => systemTests.Add(test);
        public void RemoveSystem(SystemTest test) => systemTests.Remove(test);
    }
}
