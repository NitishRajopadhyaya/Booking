using Core.Data.CRUD.Attribute;

namespace Models.Futsal.models
{
    public class BaseModel
    {
        [IgnoreUpdate]
        //[AutoFill(AutoFillProperty.CurrentUser)]
        public string CreatedBy { get; set; }

        [IgnoreUpdate]
        [AutoFill(AutoFillProperty.CurrentDate)]
        public DateTime CreatedDate { get; set; }

        [IgnoreInsert]
        //[AutoFill(AutoFillProperty.CurrentUser)]
        public string ModifiedBy { get; set; }

        [IgnoreInsert]
        [AutoFill(AutoFillProperty.CurrentDate)]
        public DateTime ModifiedDate { get; set; }

        [IgnoreInsert]
        [IgnoreUpdate]
        //[AutoFill(AutoFillProperty.CurrentUser)]
        public string DeletedBy { get; set; }

        [IgnoreInsert]
        [IgnoreUpdate]
        [AutoFill(AutoFillProperty.CurrentDate)]
        public DateTime DeletedDate { get; set; }


    }
}
