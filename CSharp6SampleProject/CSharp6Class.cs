using System;
using System.Text;

namespace CSharp6
{
    public class CSharp6Class
    {
        private readonly StringBuilder _recorder = new StringBuilder();

        public CSharp6Class()
        {
        }

        public CSharp6Class(DateTime date, string name = "C#?", int version = 6)
        {
            Version = version;
            DateSortie = date;
            Name = name;
        }

        public string Name { get; set; }

        public string Recorder => _recorder.ToString();
        public int Version { get; set; }
        public DateTime DateSortie { get; set; }
        public string Param0 { get; set; }
        public string Param1 { get; set; }
        public string Param2 { get; set; }
        public string Param3 { get; set; }
        public string Param4 { get; set; }

        public static int ExpressionBodied(int x) => x*2;

        public void ExpressionBodied(string message) => _recorder.Append(message);

        public struct PointS
        {
            public int x, y;
        };

        public class PointC
        {
            public int x, y;
            public StringBuilder message;

            public virtual string hasMessage()
            {
                return message == null ? "TRUE" : "FALSE";
            }
        }

        public void MethodWithDefaultValues(
            string param1 = "param1 default value",
            string param2 = "param2 default value",
            string param3 = "param3 default value",
            string param4 = "param4 default value")
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
            Param4 = param4;
        }

        public void MethodWithOptionalParameter(string param0,
            string param1 = "param1 default value",
            string param2 = "param2 default value",
            string param3 = "param3 default value",
            string param4 = "param4 default value")
        {
            Param0 = param0;
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
            Param4 = param4;
        }

        public PointC MethodParameterByRef(ref PointC point)
        {
            point = null;
            return point;
        }

        public PointC MethodParameterByValue(PointC point)
        {
            point = null;
            return point;
        }

        public PointC MethodParameterOut(out PointC point)
        {
            point = null; //je suis obligé de faire une modification sur l'objet out 
            return point;
        }

        public class PointD : PointC
        {
            public override string hasMessage()
            {
                return message == null ? "VRAI" : "FAUX";
            }
        }
    }
}