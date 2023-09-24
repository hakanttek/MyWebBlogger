using MyWebBlogger.Web.Models.Component;

namespace MyWebBlogger.Web.Models.Home
{
    public class HomeModel
    {
        public List<Hyperlink> NavBar { get; set; } = new() { };

        public static HomeModel DEFAULT = new() { 
            NavBar = new() { 
                new Hyperlink("Home", "/home", false),
                new Hyperlink("Projects", "/project", false),
                new Hyperlink("Blog", "/blog", true),
                new Hyperlink("About", "/about", false),
                new Hyperlink("Contact", "/contact", true)
            }
        };
    }
}