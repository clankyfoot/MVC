namespace DynamicPages.Models
{
    /// <summary>
    /// represents a row in the Page Table
    /// </summary>
    public class PageObject
    {
        public string id { get; set; }
        public string name { get; set; }
        public string order { get; set; }
    }
    /// <summary>
    /// Represents a row in the Page_View Table
    /// </summary>
    public class PageViewObject
    {
        public string name { get; set; }
    }
}