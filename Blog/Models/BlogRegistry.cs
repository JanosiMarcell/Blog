namespace Blog.Models
{
    public class BlogRegistry
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime {  get; set; }
        public DateTime LastUpdatedTime { get; set; }


        public Blogger ? Blogger { get; set; }
        public Guid BloggerId { get; set; }
    }
}
