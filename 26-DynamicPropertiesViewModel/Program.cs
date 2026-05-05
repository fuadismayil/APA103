namespace _26_DynamicPropertiesViewModel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Controller v? View-lardan istifad? ed?c?yimizi bildiririk
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseRouting();

            // Xüsusi route:
            // Browser-d? /korporativ-satislar yazanda HomeController -> CorporateSales action-a getsin
            app.MapControllerRoute(
                name: "corporate",
                pattern: "korporativ-satislar",
                defaults: new { controller = "Home", action = "CorporateSales" }
            );

            // Default route:
            // /Home/Index
            // /Home/Details
            // /Controller/Action/Id
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
