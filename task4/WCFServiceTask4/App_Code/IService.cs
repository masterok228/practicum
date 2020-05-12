using System.ServiceModel;
using System.Threading.Tasks;

// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Реструктуризация" можно использовать для одновременного изменения имени интерфейса "IService" в коде и файле конфигурации.
[ServiceContract]
public interface IService
{
	[OperationContract]
	Task<string> GetData();
}
