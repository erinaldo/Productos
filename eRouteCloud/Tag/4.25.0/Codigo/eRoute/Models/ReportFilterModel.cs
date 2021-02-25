namespace eRoute.Models
{
    public class ReportFilterModel
    {
        public string Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Otro { get; set; }
        public string Extra { get; set; }
        public bool Checked { get; set; }
        public bool Disabled { get; set; }
    }
}