using api.Dtos.Stocks;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchased = stockModel.Purchased,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }

        public static Stock ToStockFromCreateDto (this CreateStockRequestDto stockDto )
        {
            return new Stock 
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchased = stockDto.Purchased,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap,
            };
        }
    }
}