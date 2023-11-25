namespace StackOverflow.Repository.Model
{
    public class Post
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Body { get; set; }
    }
}