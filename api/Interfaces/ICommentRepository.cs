using api.Dtos.Comments;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        public Task<List<Comment>> GetAllAsync();

        public Task<Comment?> GetByIdAsync(int id);

        public Task<Comment> CreateAsync(Comment commentModel);

        public Task<Comment?> UpdateAsync(int id, UpdateCommentRequestDto commentDto);

        public Task<Comment?> DeleteAsync (int id);
    }
}