namespace WebProject.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Display(Name = "My Type: ")]
        [Required(ErrorMessage = "Please enter a type")]
        public string? Type { get; set; }

        [Display(Name = "My Name: ")]
        [Required(ErrorMessage = "Please enter a name")]
        public string? Name { get; set; }

        [Display(Name = "My Age: ")]
        [Range(0, 100)]
        public int? Age { get; set; }

        [Display(Name = "Picture Name: ")]
        [ScaffoldColumn(false)]
        public string? PictureName { get; set; }
        
        [Display(Name = "Picture Info: ")]
        [NotMapped]
        public IFormFile? PictureInfo { get; set; }

        [Display(Name = "About me: ")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Display(Name = "Category: ")]
        public int CategoryId { get; set; }

        [Display(Name = "Category: ")]
        public virtual Category? Category { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
