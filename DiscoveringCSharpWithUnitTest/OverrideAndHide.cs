using System.Text;

namespace CSharp6Test
{
    //Override vs Hide
    public class BaseClass
    {
        public StringBuilder Recorder { get; set; }

        public void WriteNum()
        {
            Recorder.Append(100);
        }

        public virtual void WriteStr()
        {
            Recorder.Append("parent");
        }
    }

    public class DerivedClass : BaseClass
    {
        public new void WriteNum()
        {
            Recorder.Append(99999);
        }

        public override void WriteStr()
        {
            Recorder.Append("overrided");
        }
    }
}