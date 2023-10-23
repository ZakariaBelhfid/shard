using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2_Tests.Classes
{
    internal class Utilisateur
    {
        private string id;
        private string pseudo;
        private readonly DateTime dateOfCreation;
        private List<Unit> units;
        private Random random = new Random();

        private static Utilisateur user;

        private Utilisateur()
        {
            units = new List<Unit>();
            Enumerable.Range(0, 11).ToList().ForEach(element =>
            {
                string randomId = Guid.NewGuid().ToString();
                string scout = "scout";
                units.Add(new Unit(randomId, scout));

            });
            dateOfCreation = DateTime.Now;
        }

        private Utilisateur(string id)
        {
            this.id = id;
            units = new List<Unit>();
            Enumerable.Range(0, 11).ToList().ForEach(element =>
            {
                string randomId = Guid.NewGuid().ToString();
                string scout = "scout";
                units.Add(new Unit(randomId, scout));

            });
            dateOfCreation = DateTime.Now;
        }

        private Utilisateur(string id, string pseudo)
        {
            this.id = id;
            this.pseudo = pseudo;
            units = new List<Unit>();
            Enumerable.Range(0, 11).ToList().ForEach(element =>
            {
                string randomId = Guid.NewGuid().ToString();
                string scout = "scout";
                units.Add(new Unit(randomId, scout));

            });
            dateOfCreation = DateTime.Now;
        }

        //Méthode d'instance unique pour le singleton
        public static Utilisateur Instance()
        {
            if (user == null)
            {
                return new Utilisateur();
            }
            return user;
        }

        public static Utilisateur Instance(string id)
        {
            if (user == null)
            {
                return new Utilisateur(id);
            }
            return user;
        }

        public static Utilisateur Instance(string id, string pseudo)
        {
            if (user == null)
            {
                return new Utilisateur(id, pseudo);
            }
            return user;
        }


        public string GetId => this.id;
        public string GetPseudo => this.pseudo;
        public string GetDate => dateOfCreation.ToString();

        public List<Unit> getAllUnits() { return units; }
    }
}
