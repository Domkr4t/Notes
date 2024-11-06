namespace Notes.Identity.Data
{
    public class DbInitializer
    {
        public static void Intitalize(AuthDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
