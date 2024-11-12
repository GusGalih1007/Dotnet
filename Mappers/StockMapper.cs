using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMapper
    {
        public static StockDto ToStockDto(this Stock stockmodel)
        {
            return new StockDto
            {
                Id = stockmodel.Id,
                Symbol = stockmodel.Symbol,
                CompanyName = stockmodel.CompanyName,
                Purchase = stockmodel.Purchase,
                LastDiv = stockmodel.LastDiv,
                Industry = stockmodel.Industry,
                MarketCap = stockmodel.MarketCap
            };
        }
    }
}