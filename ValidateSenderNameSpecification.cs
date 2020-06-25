﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SpecificationPattern
{
    public class ValidateSenderNameSpecification : Specification<OrderRequest>
    {
        public override bool IsSatisfiedBy(OrderRequest data, ref List<string> errors)
        {
            if (String.IsNullOrEmpty(data.SenderName))
                return false;
            else
                return true;
        }
    }
}
