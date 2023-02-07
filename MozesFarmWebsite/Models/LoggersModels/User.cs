namespace MozesFarmWebsite.Models.LoggersModels
{
    public class User
    {
        [ScaffoldColumn(false)]
        public int? Id { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("User Name")]
        [Key]
        public string? UserName { get; set; }

        [Required]
        [StringLength(4)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
