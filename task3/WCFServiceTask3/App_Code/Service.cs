using Newtonsoft.Json;

// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Реструктуризация" можно использовать для одновременного изменения имени класса "Service" в коде, SVC-файле и файле конфигурации.
public partial class Service : IService
{
    private readonly AppDatabaseContextEntities contextEntities = new AppDatabaseContextEntities();

    //Cl = Client
    public string ClFind(int id)
    {
        Client findID = contextEntities.Clients.Find(id);
        return JsonConvert.SerializeObject(findID, Formatting.Indented, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
        });
    }

    public void ClCreate(Client client)
    {
        contextEntities.Clients.Add(new Client()
        {
            name = client.name,
            Requests = client.Requests
        });
        contextEntities.SaveChanges();
    }

    public bool ClUpdate(Client client)
    {
        Client cl = contextEntities.Clients.Find(client.id);
        if (cl != null)
        {
            cl.name = client.name;
            cl.Requests = client.Requests;
            return true;
        }
        return false;
    }

    public bool ClDelete(int id)
    {
        Client findID = contextEntities.Clients.Find(id);
        if (findID != null)
        {
            contextEntities.Clients.Remove(findID);
            contextEntities.SaveChanges();
            return true;
        }
        return false;
    }

    //Req = Request
    public string ReqFind(int id)
    {
        Request findID = contextEntities.Requests.Find(id);
        return JsonConvert.SerializeObject(findID, Formatting.Indented, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
        });
    }

    public void ReqCreate(Request request)
    {
        contextEntities.Requests.Add(new Request()
        {
            client_id = request.client_id,
            Services = request.Services
        });
        contextEntities.SaveChanges();
    }

    public bool ReqUpdate(Request request)
    {
        Request req = contextEntities.Requests.Find(request.id);
        if (req != null)
        {
            req.client_id = request.client_id;
            req.Services = request.Services;
            return true;
        }
        return false;
    }

    public bool ReqDelete(int id)
    {
        Request findID = contextEntities.Requests.Find(id);
        if (findID != null)
        {
            contextEntities.Requests.Remove(findID);
            contextEntities.SaveChanges();
            return true;
        }
        return false;
    }

    //Ser = Service
    public string SerFind(int id)
    {
        Service findID = contextEntities.Services.Find(id);
        return JsonConvert.SerializeObject(findID, Formatting.Indented, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
        });
    }

    public void SerCreate(Service service)
    {
        contextEntities.Services.Add(new Service()
        {
            name = service.name,
            Requests = service.Requests
        });
        contextEntities.SaveChanges();
    }

    public bool SerUpdate(Service service)
    {
        Service ser = contextEntities.Services.Find(service.id);

        if (ser != null)
        {
            ser.name = service.name;
            ser.Requests = service.Requests;
            return true;
        }
        return false;
    }

    public bool SerDelete(int id)
    {
        Service findID = contextEntities.Services.Find(id);
        if (findID != null)
        {
            contextEntities.Services.Remove(findID);
            contextEntities.SaveChanges();
            return true;
        }
        return false;
    }
}
