using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDSkeletonNet.Infrastructure.Common.Domain
{
    /// <summary>
    /// Business rules class for validation description.
    /// </summary>
    public class BusinessRule
    {
        private string _ruleDescription;

        public BusinessRule(string ruleDescription)
        {
            this._ruleDescription = ruleDescription;
        }

        public string RuleDescription
        {
            get
            {
                return _ruleDescription;
            }
        }
    }
}
