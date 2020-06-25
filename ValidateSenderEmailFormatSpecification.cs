using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SpecificationPattern
{
    public class ValidateSenderEmailFormatSpecification : Specification<OrderRequest>
    {
        public override bool IsSatisfiedBy(OrderRequest data, ref List<string> errors)
        {
            string emailAddress = data.SenderEmail;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emailAddress);
            if (match.Success)
                return true;
            else
                return false;
        }
    }
}
