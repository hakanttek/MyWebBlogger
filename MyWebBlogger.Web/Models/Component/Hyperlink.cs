namespace MyWebBlogger.Web.Models.Component
{
    public class Hyperlink
    {
        public Hyperlink(string label, string reference, bool disabled)
        {
            Label = label;
            Reference = reference;
            Disabled = disabled;
        }

        public string Label { get; set; }
        public string Reference { get; set; }
        public bool Disabled { get; set; }
        public string Class => Disabled ? "disabled" : "active";
        public List<Hyperlink> Children { get; set; } = new List<Hyperlink>();
        public bool HasChild => Children.Count > 0;   
    }
}
