using api.Dtos.Comments;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {

        public static CommentDto ToCommentDto( this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
                StockId = comment.StockId,
            };
        }

        public static Comment ToCommentFromCreateDto(this CreateCommentRequestDto commentDto, int stockId)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = stockId

            };
        }
        
    }
}