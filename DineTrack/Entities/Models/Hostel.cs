using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DineTrack.Entities.Models
{
    public class Hostel
    {
        public int HostelId { get; set; }
        public string HostelName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }

        //Navigation
        //Hostel:
        //Has many Users
        //Has many Mess

        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Mess> Messes { get; set; } = new List<Mess>();
    }
}
