namespace Notes.Domain
{
    public class Note
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; } = default!;

        public string Details { get; set; } = default!;

        public DateTime CreationDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Note()
        {
            
        }

        public Note(Guid id, Guid userId, string title, string details, DateTime creationDate, DateTime? modifiedDate)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Details = details;
            CreationDate = creationDate;
            ModifiedDate = modifiedDate;
        }
    }
}
