using System.Net.Http;
using System.Threading.Tasks;

// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Реструктуризация" можно использовать для одновременного изменения имени класса "Service" в коде, SVC-файле и файле конфигурации.
public class Service : IService
{
    public async Task<string> GetData()
    {
        HttpClient http = new HttpClient();
        HttpResponseMessage httpResponse = await http.GetAsync("http://www.mocky.io/v2/5c7db5e13100005a00375fda");
        return await httpResponse.Content.ReadAsStringAsync();
    }
}
