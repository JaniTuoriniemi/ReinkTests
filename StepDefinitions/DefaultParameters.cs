using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflowtest.StepDefinitions
{
    public class DefaultParameters
    {
        
        public string browsertype;
        public string filledSwishPaymentReference;
        public string existingpassword;
        public string existingphone;
        public string newPassword;
        public string newPhone;
        public string reservedBookID;
        public string amount;
        public string bookID;
        // These are the parameters to be filled into the hidden test form
        public string averagePrice;
        public string averagePricePlusExtra;
        public string paymentReference;
        public string bookQRcode;
        public string reservedbookQRcode;
        public string RandomPhone()
        {
            string phone = "";
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
             phone=phone+random.Next(1, 10).ToString();
            }
            return phone;
        }

        public DefaultParameters()
        { browsertype = "mozilla";
          existingpassword="Koopa11Kiipa";
          existingphone="730622401";
          newPassword="NewPassword111";
          newPhone = "73"+RandomPhone();
          bookID = "6c6d0395-c667-4bf9-b5f5-0d13ca706b27";
          reservedBookID = "033b655c-33cf-4175-b3f0-08db638c642c";
          amount="1";
          bookQRcode = "eebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd";
          reservedbookQRcode = "79B113F8-DA26-43F6-800C-F17C731F02AF";
          // These are the parameters to be filled into the hidden test form
          averagePrice ="1";
          averagePricePlusExtra="1";
          paymentReference = "3AF9E317B9E54B5ABF481F85E8A96D45";//Probably should be the user GUID?;
          filledSwishPaymentReference="";
          

        }
    }
}
