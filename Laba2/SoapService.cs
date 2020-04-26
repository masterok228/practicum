using System;
using System.Xml.Linq;

namespace Laba2
{
    public class SoapService : ISoapServ
    {
        public Model TestModel(Model model) => model;

        public string Test(string a)
        {
            Console.WriteLine("Test");
            return a;
        }

        public void XmlMethod(XElement xml) => Console.WriteLine(xml.ToString());
    }
}
