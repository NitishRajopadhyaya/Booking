using Models.Futsal.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Menu
{
    [Table("Menu")]
    public class MenuModel:BaseModel
    {
        [Key]
        public int MenuId { get; set; }
        [Required]
        public string MenuName { get; set; }
        public string Url { get; set; }
        [Required]
        public string AreaName { get; set; }
        [Required]
        public string ControllerName { get; set; }
        [Required]
        public string ActionName   { get; set; }
        public string QueryString { get; set; }
        public string Icon { get; set; }
        public int DispalyOrder { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
