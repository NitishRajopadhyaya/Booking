using Core.Data.CRUD.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Futsal.models
{
    [Table("ManageTime")]
    public class ManageTimeModel : BaseModel
    {
        [Key]
        public int ManageTimeId { get; set; }
        public int VenueId { get; set; }
        public decimal Price { get; set; }
        public string appUserId { get; set; }
        public bool IsActive { get; set; }
        [IgnoreAll]
        public ManageDayTimeModel manageDayTime { get; set; }
        [IgnoreAll]
        public List<ManageSundayMultipleTime> manageSundayMultipleTimes { get; set; }
        [IgnoreAll]
        public List<ManageMondayMultipleTime> manageMondayMultipleTimes { get;set; }
        [IgnoreAll]
        public List<ManageTuesdayMultipleTime> manageTuesdayMultipleTimes { get; set; }
        [IgnoreAll]
        public List<ManageWednesdayMultipleTime> manageWednesdayMultipleTimes { get; set; }
        [IgnoreAll]
        public List<ManageThursdayMultipleTime> manageThursdayMultipleTimes { get; set; }
        [IgnoreAll]
        public List<ManageFridayMultipleTime> manageFridayMultipleTimes { get; set; }
        [IgnoreAll]
        public List<ManageSaturdayMultipleTime> manageSaturdayMultipleTimes { get; set; }

    }

    [Table("ManageDayTime")]
    public class ManageDayTimeModel
    {
        [Key]
        public int ManageDayTimeId { get; set; }
        public int ManageTimeId { get; set; }
        public bool IsActive { get; set; }

        public string SunStartDateTime { get; set; }
        public string SunEndDateTime { get; set; }
        public int SunRange { get; set; }
         
        public string MonStartDateTime { get; set; }
        public string MonEndDateTime { get; set; }
        public int MonRange { get; set; }

        public string TueStartDateTime { get; set; }
        public string TueEndDateTime { get; set; }
        public int TueRange { get; set; }

        public string WedStartDateTime { get; set; }
        public string WedEndDateTime { get; set; }
        public int WedRange { get; set; }

        public string ThurStartDateTime { get; set; }
        public string ThurEndDateTime { get; set; }
        public int ThurRange { get; set; }

        public string FriStartDateTime { get; set; }
        public string FriEndDateTime { get; set; }
        public int FriRange { get; set; }
        public string SatStartDateTime { get; set; }
        public string SatEndDateTime { get; set; }
        public int SatRange { get; set; }
    }
    public class ManageSundayMultipleTime
    {
        public string SunStartDateTime { get; set; }
        public string SunEndDateTime { get; set; }
    }
    public class ManageMondayMultipleTime
    {
        public string MonStartDateTime { get; set; }
        public string MonEndDateTime { get; set; }
    }
    public class ManageTuesdayMultipleTime
    {
        public string TueStartDateTime { get; set; }
        public string TueEndDateTime { get; set; }
    }
    public class ManageWednesdayMultipleTime
    {
        public string WedStartDateTime { get; set; }
        public string WedEndDateTime { get; set; }
    }
    public class ManageThursdayMultipleTime
    {
        public string ThurStartDateTime { get; set; }
        public string ThurEndDateTime { get; set; }
    }
    public class ManageFridayMultipleTime
    {
        public string FriStartDateTime { get; set; }
        public string FriEndDateTime { get; set; }
    }
    public class ManageSaturdayMultipleTime
    {
        public string SatStartDateTime { get; set; }
        public string SatEndDateTime { get; set; }
    }

}
