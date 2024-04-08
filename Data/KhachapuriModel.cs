namespace ITStepRazorApp.Data
{
    public class KhachapuriModel
    {
        public string ImageTitle {  get; set; }
        public string KhachapuriName { get; set; }
        public bool Large {  get; set; }
        public bool Medium {  get; set; }
        public bool Small { get; set; }
        public float BasePrice { get; set; } = 12;
        public float FinalPrice { get; set; }
    }
}
