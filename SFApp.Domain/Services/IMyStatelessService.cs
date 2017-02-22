using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace SFApp.Domain.Services
{
    public interface IMyStatelessService: IService
    {
        Task<List<string>> GetListOfCities();
    }
}
