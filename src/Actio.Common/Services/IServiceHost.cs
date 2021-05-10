using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.Services
{
    public interface IServiceHost
    {
        Task Run();
    }
}
