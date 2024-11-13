using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stockModel == null)
            {
                return null;
            }
            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockDto updateDto)
        {
            var editStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (editStock == null)
            {
                return null;
            }
            
            editStock.Symbol = updateDto.Symbol;
            editStock.CompanyName = updateDto.CompanyName;
            editStock.Purchase = updateDto.Purchase;
            editStock.LastDiv = updateDto.LastDiv;
            editStock.Industry = updateDto.Industry;
            editStock.MarketCap = updateDto.MarketCap;

            await _context.SaveChangesAsync();

            return editStock;
        }
    }
}