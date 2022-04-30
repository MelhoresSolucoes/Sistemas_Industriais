using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.Services.Base
{
    /// <summary>
    /// Base Abstact Class of App Services
    /// </summary>
    public abstract class AppService : IAppServiceBase
    {
        /// <summary>
        /// Dictionary Of Errors
        /// </summary>
        public Dictionary<string, string> ApplicationErrors { get; set; }

        protected AppService()
        {
            this.ApplicationErrors = new Dictionary<string, string>();
        }

        /// <summary>
        /// Add Erros to Your Service Dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddErrorApplicationErrors(string key, string value)
        {
            if (this.ApplicationErrors == null)
                this.ApplicationErrors = new Dictionary<string, string>();

            if (!this.ApplicationErrors.ContainsKey(key))
                this.ApplicationErrors.Add(key, value);
        }

        /// <summary>
        /// Remove all errors of your Service
        /// </summary>
        public void ResetApplicationErrors()
        {
            this.ApplicationErrors = new Dictionary<string, string>();
        }
    }
}
