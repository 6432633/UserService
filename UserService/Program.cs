namespace UserService{
    public class Program{
        public static void Main(string[] args){
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webbuilder =>{ webbuilder.UseStartup<Startup>();
            });
    }
}