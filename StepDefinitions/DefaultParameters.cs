using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflowtest.StepDefinitions
{
    public class DefaultParameters
    {
        
        public string Browsertype;
        public string FilledSwishPaymentReference;
        public string Existingpassword;
        public string Existingphone;
        public string NewPassword;
        public string NewPhone;
        public string ReservedBookID;
        public string Amount;
        public string BookID;
        // These are the parameters to be filled into the hidden test form
        public string AveragePrice;
        public string AveragePricePlusExtra;
        public string PaymentReference;
        public string BookQRcode;
        public string ReservedbookQRcode;
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
        { Browsertype = "mozilla";
          Existingpassword="Koopa11Kiipa";
          Existingphone="730622401";
          NewPassword="NewPassword111";
          NewPhone = "73"+RandomPhone();
          BookID = "6c6d0395-c667-4bf9-b5f5-0d13ca706b27";
          ReservedBookID = "033b655c-33cf-4175-b3f0-08db638c642c";
          Amount="1";
          BookQRcode = "eebe74a8-56ce-4e10-a8a2-6e4f6ef6c8cd";
          ReservedbookQRcode = "79B113F8-DA26-43F6-800C-F17C731F02AF";
          // These are the parameters to be filled into the hidden test form
          AveragePrice ="1";
          AveragePricePlusExtra="1";
          PaymentReference = "3AF9E317B9E54B5ABF481F85E8A96D45";//Probably should be the user GUID?;
          FilledSwishPaymentReference="";
          

        }
    }
}
