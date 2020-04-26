using System.ServiceModel;

namespace Laba2
{
    [ServiceContract]
    public interface ISoapServ
    {
        [OperationContract]
        Model TestModel(Model model);

        [OperationContract]
        string Test(string a);

        [OperationContract]
        void XmlMethod(System.Xml.Linq.XElement xml);
    }
}
