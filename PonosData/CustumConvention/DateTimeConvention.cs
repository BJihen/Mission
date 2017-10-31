using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonosData.CustumConvention
{
    class DateTimeConvention : Convention
    {
        public DateTimeConvention()
        {
            Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }
    }
}
