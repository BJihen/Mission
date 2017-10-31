
using PonosData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonosData.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private PonosContext dataContext;
        public PonosContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new PonosContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}
