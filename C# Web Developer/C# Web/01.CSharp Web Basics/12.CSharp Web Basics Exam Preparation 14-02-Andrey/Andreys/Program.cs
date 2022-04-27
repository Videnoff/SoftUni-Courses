using System.Threading.Tasks;
using SIS.MvcFramework;

namespace Andreys
{
    public class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
