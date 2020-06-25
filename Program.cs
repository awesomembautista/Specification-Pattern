using System;
using System.Collections.Generic;
using System.Text;


namespace SpecificationPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderRequest orderRequest1 = new OrderRequest { SenderEmail = "Test@ys.com", SenderContactNumber = "+639135297490", SenderName = "Mark Jerome Bautista", RecipientName = "Nicole Something", RecipientContactNumber = "+639135297411", RecipientEmail = "rtest@ys.com" };
            OrderRequest orderRequest2 = new OrderRequest { SenderEmail = "", SenderContactNumber = "09166351495", SenderName = "", RecipientName = "", RecipientContactNumber = "09166351411", RecipientEmail = "" };
            OrderRequest[] orderRequests = new OrderRequest[] { orderRequest1, orderRequest2 };
            var errors = new List<string>();
            foreach (var orderRequest in orderRequests) {
                var validOrderSpecification =  new ValidOrderRequestSpecification(orderRequest);
                var recipientContact = new ValidateRecipientContactNumberSpecification();
                var isValid = recipientContact.And(validOrderSpecification).IsSatisfiedBy(orderRequest, ref errors);
                Console.WriteLine(isValid);
            }
        }
    }
}
