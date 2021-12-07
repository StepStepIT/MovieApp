namespace DLL.Models
{

    public class Hall
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<Chair> Chairs { get; set; }
        public List<Session> Sessions { get; set; }
    }
}
