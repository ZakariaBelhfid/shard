using System.Runtime.InteropServices.JavaScript;
using Microsoft.VisualBasic;

namespace V3_Web.Classes;

public class Utilisateur
{
    private string id;
    private string pseudo = "Jonnhy";
    private readonly string? date;
    private static Utilisateur _user;
    private List<Unit> units;
    private Building building;

    private Utilisateur(string id)
    {
        this.id = id;
        this.date = DateTime.Now.ToString();
        this.units = new List<Unit>();
        this.building = new Building();
        Enumerable.Range(0, 11).ToList().ForEach(element =>
        {
            units.Add(new Unit());
        });
    }

    public static Utilisateur Instance(string id)
    {
        if (_user == null)
        {
            _user = new Utilisateur(id);
        }
        return _user;
    }

    public void setBuilding(Building bd) => building = bd;

    public string GetId => id;
    public string GetPseudo => pseudo;
    public string GetDate => date;
    public List<Unit> GetUnits => units;

    public Building GetBuilding => building;
}