using Core.Data;
using Core.DI;
using Core.Enum;
using Core.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class CoreExtension
    {
        public static IServiceCollection RegisterCoreServices(this IServiceCollection services)
        {
            
            services.AddSingleton(services);
            services.AddSingleton<IJsonResponse, JsonResponse>();
            _ = new Bootstrapper(services);
            return services;
        }


        //public static IServiceCollection RegisterCoreServices(this IServiceCollection services, IServiceProvider serviceProvider)
        //{
        //    services.AddOptions();
        //    services.AddSingleton(services);
        //    //services.TryAddSingleton<INimbleSettings, NimbleAppsSettings>();
        //    //services.TryAddSingleton<IIntegrationHelpers, IntegrationHelpers>();
        //    //services.TryAddSingleton<ICommonHelper, CommonHelper>();
        //    //services.TryAddSingleton<ILoggerSetting, DefaultDbLoggerSetting>();
        //    //services.TryAddSingleton<ILogProvider, DefaultLogProvider>();
        //    //services.TryAddSingleton<IMenuManager, MenuManager>();
        //    //services.TryAddSingleton<ILogger, DbLogger>();
        //    //services.TryAddSingleton<IFileService, LocalFileService>();

        //    //services.TryAddSingleton<INumberToWord, NumberToWord>();
        //    //services.TryAddSingleton<INepaliDateHelper, NepaliDateHelper>();
        //    //services.TryAddSingleton<ICultureLocalizer, CultureLocalizer>();
        //    //services.TryAddSingleton<IMultiLanguageServices, MultiLanguageServices>();
        //    //services.AddTransient<IDbConnBase, DbConnBase>();
        //    //services.AddTransient<IDBHelper, DBHelper>();
        //    //services.TryAddSingleton<IExcelHelper, ExcelHelper>();
        //    //services.TryAddSingleton<IJwtService, JwtService>();
        //    //services.TryAddSingleton<IKeywordResolver, KeywordResolver>();
        //    //services.TryAddSingleton<ISMSHelper, SMSHelper>();
        //    //services.AddTransient<IMailHelper, MailHelper>();
        //    //services.TryAddSingleton<IApiLoginHelper, ApiLoginHelper>();
        //    //services.AddTransient<LogErrorAttribute>();
        //    //services.AddTransient<IAuthenticatedUserService, AuthenticatedUserService>();
        //    new ServiceRegistrarHelper(services, serviceProvider);
        //    return services;
        //}
    }
}
