using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;

namespace SpecificationPattern
{
    class ValidOrderRequestSpecification : Specification<OrderRequest>
    {
        private readonly OrderRequest _orderRequest;
        private List<string> Errors = new List<string>();
        ValidateSenderEmailFormatSpecification senderEmail = new ValidateSenderEmailFormatSpecification();
        ValidateSenderNameSpecification senderName = new ValidateSenderNameSpecification();
        ValidateSenderContactNumberSpecification senderContact = new ValidateSenderContactNumberSpecification();
        ValidateRecipientEmailFormatSpecification recipientEmail = new ValidateRecipientEmailFormatSpecification();
        ValidateRecipientNameSpecification recipientName = new ValidateRecipientNameSpecification();
        ValidateRecipientContactNumberSpecification recipientContact = new ValidateRecipientContactNumberSpecification();
        public ValidOrderRequestSpecification(OrderRequest orderRequest)
        {
            _orderRequest = orderRequest;
        }
        public bool isAllValid()
        {
            return senderEmail.And(senderName).And(senderContact).And(recipientContact).And(recipientName).IsSatisfiedBy(_orderRequest, ref Errors);
        }
        public override bool IsSatisfiedBy(OrderRequest data, ref List<string> errors)
        {
            return isAllValid();
        }
    }
}
