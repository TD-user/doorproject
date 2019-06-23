using DBDataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDataProvider
{
    public class BlockProvider
    {
        private readonly DataContext dataContext;
        public BlockProvider()
        {
            dataContext = new DataContext();
        }
    }
}
