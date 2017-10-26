namespace MesPremiersUnitTestProject
{
    public class Person
    {
        public string Nom { get;}
        public string Prenom { get; }
        public string Adresse { get; }
        public string Ville { get; }
        public string CodePostal { get; }

        public Person(string nom, string prenom, string adresse="", string ville = "", string codePostal = "")
        {
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Ville = ville;
            CodePostal = codePostal;
        }

        public override string ToString()
        {
            return $"Nom={Nom} Prenom={Prenom} Adresse={Adresse} Code postal={CodePostal} Ville={Ville}";
        }
    }
}