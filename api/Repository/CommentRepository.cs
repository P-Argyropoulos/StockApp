using api.Data;
using api.Dtos.Comments;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository ( ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
           return await _context.Comments.ToListAsync(); 
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
             return await _context.Comments.FindAsync(id);

        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            _context.Comments.Add(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> UpdateAsync(int id, UpdateCommentRequestDto commentDto)
        {
            var existingComment = await _context.Comments.FindAsync(id);

            if (existingComment == null)
            {
                return null;
            }

            _context.Entry(existingComment).CurrentValues.SetValues(commentDto);
            await _context.SaveChangesAsync();
            return existingComment;

        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if (comment == null)
            {
                return null;
            }
            
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
    }
}