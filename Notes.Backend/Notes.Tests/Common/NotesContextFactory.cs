using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Persistence;

namespace Notes.Tests.Common
{
    public class NotesContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid NoteIdForDelete = Guid.NewGuid();
        public static Guid NoteIdForUpdate = Guid.NewGuid();

        public static NotesDbContext Create()
        {
            var options = new DbContextOptionsBuilder<NotesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new NotesDbContext(options);
            context.Database.EnsureCreated();
            context.Notes.AddRange(
                new Note
                {
                    CreationDate = DateTime.Today,
                    Details = "Details1",
                    ModifiedDate = null,
                    Id = Guid.Parse("E99BE9D9-6D79-44AA-993B-B34F8F42B260"),
                    Title = "Title1",
                    UserId = UserAId
                },    
                new Note
                {
                    CreationDate = DateTime.Today,
                    Details = "Details2",
                    ModifiedDate = null,
                    Id = Guid.Parse("F8706B20-FAA6-4DF2-86B6-D2916E883D1F"),
                    Title = "Title2",
                    UserId = UserBId
                },  
                new Note
                {
                    CreationDate = DateTime.Today,
                    Details = "Details3",
                    ModifiedDate = null,
                    Id = NoteIdForDelete,
                    Title = "Title3",
                    UserId = UserAId
                },
                new Note
                {
                    CreationDate = DateTime.Today,
                    Details = "Details4",
                    ModifiedDate = null,
                    Id = NoteIdForUpdate,
                    Title = "Title4",
                    UserId = UserBId
                }  
            );

            context.SaveChanges();
            return context;
        }

        public static void Destroy(NotesDbContext context)
        {
            context.Database.EnsureCreated();
            context.Dispose();
        }
    }
}
