using api.Dtos.Comments;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route ("api/comment")]
    [ApiController]
    
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;

        public CommentController (ICommentRepository commentRepo, IStockRepository stockRepo)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comments = await  _commentRepo.GetAllAsync();
            var commentDto = comments.Select(c =>c.ToCommentDto());

            return Ok(commentDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = await _commentRepo.GetByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> CreateAsync([FromRoute] int stockId, CreateCommentRequestDto commentDto)
        {
            if(!await _stockRepo.StockExist(stockId)) 
            {
                return BadRequest ("Stock does not exist!");
            }

            var commentModel = commentDto.ToCommentFromCreateDto(stockId);
            await _commentRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new {id = commentModel.Id }, commentModel.ToCommentDto());

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateCommentRequestDto  updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var comment = await _commentRepo.UpdateAsync(id, updateDto);

            if (comment == null)
            {
                return NotFound("Comment not found");
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var commentModel = await _commentRepo.DeleteAsync(id);

            if (commentModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}