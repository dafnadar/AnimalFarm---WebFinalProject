namespace WebProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Animal>? Animals { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
