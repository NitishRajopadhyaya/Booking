using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Futsal.models
{
    [Table("Venue")]
    public class VenueModel : BaseModel
    {
        [Key]
        public int VenueId { get; set; }
        [Required]
        required public string VenueName { get; set; } = null!;
        public string VenueNameNepali { get; set; } = string.Empty;
        public double VenueLength { get; set; }
        public double VenueWidth { get; set; }
        required public int VenueTypeId { get; set; }
        required public string VenueDescription { get; set; }
        //public DateTime OpeningTime { get; set; }
        //public DateTime ClosingTime { get; set; }
        public bool IsVenueActive { get; set; }

    }
    public class VenueType
    {
        public int VenueTypeId { get; set; }
        required public string VenueTypeName { get; set; }
    }


    public class VenueListViewModel
    {
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public string VenueDescription { get; set; }
        public string VenueLocation { get; set; }

    }
}
