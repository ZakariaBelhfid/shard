using System.Collections;
using System;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace V2_Web.V2_Classes
{
    public class User
    {
        private readonly string id;
        private readonly string pseudo;
        private readonly DateTime dateOfCreation;

        private List<Unit> units;

        public User()
        {
            units = new List<Unit>();
        }

        public User(string id)
        {
            this.id = id;
            units = new List<Unit>();
        }

        public User(string id, string pseudo, DateTime dateOfCreation)
        {
            this.id = id;
            this.pseudo = pseudo;
            this.dateOfCreation = dateOfCreation;
            units = new List<Unit>();
        }

        public string getId => this.id;
        public string getPseudo => this.pseudo;
        public string getDateOfCreation => dateOfCreation.ToString();

        public List<Unit> getAllUnits() { return units; }
    }
}
