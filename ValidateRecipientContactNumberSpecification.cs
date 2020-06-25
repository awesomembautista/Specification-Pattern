using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SpecificationPattern
{
    class ValidateRecipientContactNumberSpecification : Specification<OrderRequest>
    {
        public override bool IsSatisfiedBy(OrderRequest data, ref List<string> errors)
        {
            string senderContact = data.RecipientContactNumber;
            Regex regex = new Regex(@"^(\+639)\d{9}$");
            Match match = regex.Match(senderContact);
            if (match.Success)
                return true;
            else
                return false;
        }
    }
}
