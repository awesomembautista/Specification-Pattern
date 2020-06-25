using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SpecificationPattern
{
    public class ValidateSenderContactNumberSpecification : Specification<OrderRequest>
    {
        public override bool IsSatisfiedBy(OrderRequest data, ref List<string> errors)
        {
            string senderContact = data.SenderContactNumber;
            Regex regex = new Regex(@"^(\+639)\d{9}$");
            Match match = regex.Match(senderContact);
            if (match.Success)
                return true;
            else
                return false;
        }
    }
}
