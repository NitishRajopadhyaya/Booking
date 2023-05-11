using Dapper;
using Models.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseCrudService
    {
        public DynamicParameters SetParamsForCrud(DynamicParameters parameters, string Mode)
        {
            parameters.Add("@Mode", Mode);
            ParameterDirection? direction = ParameterDirection.ReturnValue;
            parameters.Add("@Response", null, null, direction);
            direction = ParameterDirection.Output;
            int size = 1;
            parameters.Add("@ErrorFlag", null, null, direction, size, null, null);
            direction = ParameterDirection.Output;
            size = 4000;
            parameters.Add("@ErrorMsg", null, null, direction, size, null, null);
            parameters.Add("@CreatedBy", "Admin");
            return parameters;
        }
        public ProcReturnModel GetSpOutputResult(DynamicParameters parameters)
        {

            ProcReturnModel model = new ProcReturnModel();
            model.RowId = parameters.Get<int>("RowId");
            model.ErrorFlag = parameters.Get<string>("@ErrorFlag");
            model.ErrorMsg = parameters.Get<string>("@ErrorMsg");
            model.Response = parameters.Get<int>("@Response");
            return model;
        }

        public ProcReturnModel GetSpOutParamResult(DynamicParameters parameters, string idParamName = "")
        {
            return new ProcReturnModel
            {
                RowId = ((!string.IsNullOrEmpty(idParamName)) ? parameters.Get<object>(idParamName) : ((object)0)),
                ErrorFlag = parameters.Get<string>("@ErrorFlag"),
                ErrorMsg = parameters.Get<string>("@ErrorMsg"),
                Response = parameters.Get<int>("@Response")
            };
        }
    }
}
