namespace WebProject.Models
{
    public class Comment
    {
        [ScaffoldColumn(false)]
        public int? Id { get; set; }

        [DisplayName("Your name:")]
        [Required]
        public string? WriterName { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Date { get; set; }

        [DisplayName("Write your thoughts:")]
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(200, MinimumLength = 2)]
        public string? CommentText { get; set; }

        [ScaffoldColumn(false)]
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        [ScaffoldColumn(false)]
        public int AnimalId { get; set; }

        public virtual Animal? Animal { get; set; }
    }
}
