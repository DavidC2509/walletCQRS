using Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Rule
{
    [Serializable]
    public class BusinessRuleValidationException : ServiceException
    {
        public IBusinessRule BrokenRule { get; set; }

        public override int HttpStatusCode { get; }
        public override string ErrorMessage { get; }

        public override Dictionary<string, List<string>> Errors { get; }

        public BusinessRuleValidationException(IBusinessRule brokenRule)
        {
            BrokenRule = brokenRule;
            HttpStatusCode = 400;
            ErrorMessage = "Bussines Validation";
            Errors = new Dictionary<string, List<string>>
            {
                { "Validate", new List<string> { brokenRule.Message } }
            };
        }
    }
}
