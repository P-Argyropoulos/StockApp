using System.ComponentModel.DataAnnotations;


namespace api.Dtos.Comments
{
    public class CreateCommentRequestDto
    {
        [Required]
        [MinLength (5 , ErrorMessage = "Title  must be 5 charactes!")]
        [MaxLength (250, ErrorMessage = " Symbol must be less than 250 Characters!")]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        [MinLength (5 , ErrorMessage = "Content must be 5 charactes!")]
        [MaxLength (250, ErrorMessage = " Content must be less than 250 Characters!")]
        public string Content { get; set; } = string.Empty;
    }
}