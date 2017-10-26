using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace CSharp6
{
    [TestClass]
    public class EnumTest
    {
        [TestMethod]
        public void Enum_to_string()
        {
            Check.That(DecisionEnum.Ajournement.ToString()).IsEqualTo("Ajournement");
            Check.That(DecisionEnum.Ajournement + "").IsEqualTo("Ajournement");

            Check.That(DecisionEnum.Ajournement).IsEqualTo(DecisionEnum.Ajournement);
        }

        [TestMethod]
        public void Enum_to_int()
        {
            Check.That((int)DecisionEnum.Ajournement).IsEqualTo(3);
            Check.That((int)DecisionEnum.Acceptation).IsEqualTo(0);
        }

        [TestMethod]
        public void int_to_Enum()
        {
            Check.That((DecisionEnum)3).IsEqualTo(DecisionEnum.Ajournement);
            Check.That((DecisionEnum)0).IsEqualTo(DecisionEnum.Acceptation);

            //essai de récupérer l'enum d'un chiffre qui n'existe pas => et bien on a qq chose qd même
            Check.That((DecisionEnum)999999999).IsNotEqualTo(999999999);
            Check.That(((DecisionEnum)999999999).GetType()).IsEqualTo(typeof(DecisionEnum));
        }

        [TestMethod]
        public void Enum_IsDefined()
        {
            Check.That(Enum.IsDefined(typeof(DecisionEnum), 3)).IsTrue();
            Check.That(Enum.IsDefined(typeof(DecisionEnum), 999999999)).IsFalse();
        }

        [TestMethod]
        public void Enum_get_par_son_nom()
        {
            //recup d'une enum par son nom
            Check.That("Noir".ToEnum<ColorEnum>()).IsEqualTo(ColorEnum.Noir);
        }
    }

    public enum DecisionEnum : int
    {
        Acceptation = 0,
        Encours = 1,
        EnattenteImpacts = 2,
        Ajournement = 3,
    }

    public enum ColorEnum
    {
        Rouge,
        Vert,
        Gris,
        Orange,
        Noir,
    }

    public static class UneExtension
    {
        public static T ToEnum<T>(this string enumString)
        {
            return (T) Enum.Parse(typeof(T), enumString);
        }
    }
}