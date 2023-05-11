using Core.Data.CRUD.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class FormBuilerExtentions
    {
        public static void AutoFill(this object obj)
        {
            if (!obj.GetType().GetTypeInfo().IsClass)
                return;
            var type = obj.GetType();
            foreach (var prop in type.GetProperties())
            {
                var customAtt = prop.GetCustomAttribute<AutoFillAttribute>();
                if (customAtt != null)
                {
                    if (customAtt.HasFixedValue)
                    {

                        var typedDefValue = Convert.ChangeType(customAtt.DefaultValue, prop.PropertyType);
                        if (null != prop && prop.CanWrite)
                        {
                            prop.SetValue(obj, typedDefValue, null);
                        }
                    }
                    else
                    {
                        switch (customAtt.fillBy)
                        {
                            //case AutoFillProperty.CurrentCulture:
                            //    var rqf = ContextResolver.Context.Features.Get<IRequestCultureFeature>();
                            //    // Culture contains the information of the requested culture
                            //    var culture = rqf.RequestCulture.Culture.ToString();
                            //    customAtt.DefaultValue = culture;
                            //    break;
                            case AutoFillProperty.CurrentUser:
                                var claim = ((ClaimsIdentity)HttpContextExtension.Context.User.Identity).FindFirst("name");
                                customAtt.DefaultValue = claim.Value;
                                break;
                            case AutoFillProperty.CurrentDate:
                                customAtt.DefaultValue = DateTime.Now;
                                break;
                        }
                        var typedDefValue = Convert.ChangeType(customAtt.DefaultValue, prop.PropertyType);
                        if (null != prop && prop.CanWrite)
                        {
                            prop.SetValue(obj, typedDefValue, null);
                        }
                    }
                  
                }
            }
        }
    }
}
