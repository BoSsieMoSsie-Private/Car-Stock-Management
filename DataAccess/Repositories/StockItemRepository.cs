using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public  class StockItemRepository : IStockItemRepository
    {

        #region Fields

        private readonly CMSContext _dbCMSContext;

        #endregion

        public StockItemRepository(CMSContext dbCMSContext)
        {
            _dbCMSContext = dbCMSContext ?? throw new ArgumentException(nameof(dbCMSContext));
        }
    }
}
