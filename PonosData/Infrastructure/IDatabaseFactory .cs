
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonosData.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        PonosContext DataContext { get; }
    }

}
