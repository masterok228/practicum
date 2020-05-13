using System.ServiceModel;

// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Реструктуризация" можно использовать для одновременного изменения имени интерфейса "IService" в коде и файле конфигурации.
[ServiceContract]
public interface IService
{
    //Cl = Client
    [OperationContract]
    string ClFind(int id);

    [OperationContract]
    void ClCreate(Client client);

    [OperationContract]
    bool ClUpdate(Client client);

    [OperationContract]
    bool ClDelete(int id);

    //Req = Request
    [OperationContract]
    string ReqFind(int id);

    [OperationContract]
    void ReqCreate(Request request);

    [OperationContract]
    bool ReqUpdate(Request request);

    [OperationContract]
    bool ReqDelete(int id);

    //Ser = Service
    [OperationContract]
    string SerFind(int id);

    [OperationContract]
    void SerCreate(Service service);

    [OperationContract]
    bool SerUpdate(Service service);

    [OperationContract]
    bool SerDelete(int id);
}
