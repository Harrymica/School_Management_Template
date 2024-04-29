
using School_Management_Template.Data;
using Supabase;


namespace School_Management_Template.Repositories.StudentRespository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Client _supabaseClient;
        //private readonly Client _supabaseClient = new Supabase.Client("https://xbpfjissmlaulfmmdema.supabase.co",
        //    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InhicGZqaXNzbWxhdWxmbW1kZW1hIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTEwODY2MzMsImV4cCI6MjAyNjY2MjYzM30.DbA3lh6tT5D_W819GVqvKtC1WDIchyCgXdHIKaqxJsA");


        
        public StudentRepository(Supabase.Client client)
        {
            _supabaseClient = client;

            // supabaseUrl = "https://xbpfjissmlaulfmmdema.supabase.co";
            // supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InhicGZqaXNzbWxhdWxmbW1kZW1hIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTEwODY2MzMsImV4cCI6MjAyNjY2MjYzM30.DbA3lh6tT5D_W819GVqvKtC1WDIchyCgXdHIKaqxJsA";
            //_supabaseClient = new Client(supabaseUrl, supabaseKey);
            //var _supabaseClient = new Supabase.Client("https://xbpfjissmlaulfmmdema.supabase.co",
            //"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InhicGZqaXNzbWxhdWxmbW1kZW1hIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTEwODY2MzMsImV4cCI6MjAyNjY2MjYzM30.DbA3lh6tT5D_W819GVqvKtC1WDIchyCgXdHIKaqxJsA");

        }
        //public async Task InitializeAsync()
        //{
        //    await _supabaseClient.InitializeAsync();
        //}

        //public async Task<List<Students>> GetAllStudentsAsync()
        //{
        //    var response = await _supabaseClient
        //        .From<Students>()
        //        .Select("*")
        //        .Get();

        //    return response.Models as List<Students>;
        //}

        //public async Task<Students> GetStudentByIdAsync(int id)
        //{
        //    var response = await _supabaseClient
        //        .From<Students>()
        //        .Where(s => s.Id == id)
        //        .Limit(1)
        //        .Single();


        //    return response!;//.Models.FirstOrDefault();
        //}

        //public async Task AddStudentAsync(Students student)
        //{

        //    var bucket = await _supabaseClient.Storage.CreateBucket("profiles");


        //    var imagePath = Path.Combine("Assets", student.Image);

        //    await _supabaseClient.Storage
        //      .From("profiles")
        //      .Upload(imagePath, student.Image, new Supabase.Storage.FileOptions { CacheControl = "3600", Upsert = false });
        //    if (student != null)
        //    {

        //        var response = await _supabaseClient.From<Students>().Insert(student);

        //    }
        //}

        //public async Task UpdateStudentAsync(Students student)
        //{
        //    await _supabaseClient
        //        .From<Students>()
        //        .Where(s => s.Id == student.Id)
        //        .Update(student);
        //}

        //public async Task DeleteStudentAsync(int id)
        //{
        //    await _supabaseClient
        //        .From<Students>()
        //        .Where(s => s.Id == id)
        //        .Delete();
        //}
    }
}
