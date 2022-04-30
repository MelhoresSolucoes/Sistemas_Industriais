using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.Services.Base
{
    public interface IAppServiceBase
    {
        Dictionary<string, string> ApplicationErrors { get; set; }

        void AddErrorApplicationErrors(string key, string value);
        void ResetApplicationErrors();
    }
}
