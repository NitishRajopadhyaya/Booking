using Core.Data.CRUD.Attribute;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Futsal.models.Schedule
{
    [Table("Schedule")]
    public class ScheduleModel
    {
        [Key]
        public int ScheduleId { get; set; }
        public string DateSchedule { get; set; }
        [IgnoreAll]
        public IEnumerable<string> ScheduleTime { get; set; }
        public string Time { get; set; }
        public decimal Price { get; set; }
        public int venueId { get; set; }
        public int UserAdminId { get; set; }
        public string Remarks { get; set; }
    }
    public class EventModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateSchedule { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int VenueId { get; set; }
    }
}
