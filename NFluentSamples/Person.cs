namespace NFluent
{
    public enum Nationality
    {
        Unknown,
        French,
        Korean,
        Indian
    }

    internal class Person
    {
        public Person()
        {
        }

        public string Name { get; set; }

        public int Age { get; set; }
        public Nationality Nationality { get; set; }
    }
}