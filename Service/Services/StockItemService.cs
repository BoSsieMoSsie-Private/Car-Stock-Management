using Service.Contracts;
using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StockItemService : IStockItemService
    {
        #region Fields
        private readonly IStockItemRepository _stockItemRepository;

        #endregion

        public StockItemService ( IStockItemRepository stockItemRepository)
        {
            _stockItemRepository = stockItemRepository;
        }



    }



}
