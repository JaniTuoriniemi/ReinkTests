// See https://aka.ms/new-console-template for more information
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Text.Json;
namespace SpecFlowProject1.StepDefinitions
{
    public class Parameters
    {
        // Display the number of command line arguments.
       public  string ExistingPhone;
        public string NewPhone;
        public string ExistingPassword;
        public string NewPassword;
        public string BookID;
        public string BookQRcode;
        public string ReservedBookID;
        public string AveragePrice;
        public string AveragePricePlusExtra;
        public string PaymentReference;
        public string Amount;
        public string Browsertype;
        public string FilledSwishPaymentReference;
    }
    internal class Data {    
        static int Main()
        { Parameters parameters = new Parameters();
           Console.WriteLine("State the phone number of an existing account");
           parameters.ExistingPhone = Console.ReadLine();
            Console.WriteLine("State the phone number of an account to be created. The number must be a valid 9 digits currently not connecteted to an Reink account.");
            parameters.NewPhone = Console.ReadLine();
            Console.WriteLine("State the password of an existing account");
            parameters.ExistingPassword = Console.ReadLine();
            Console.WriteLine("State the password of a account to be created");
            parameters.NewPassword = Console.ReadLine();
            Console.WriteLine("State BookID to be used in the tests");
            parameters.BookID = Console.ReadLine();
            Console.WriteLine("State the Book QR code to be used in the test");
            parameters.BookQRcode = Console.ReadLine();
            Console.WriteLine("State the Book ID of a book the is always reserved");
            parameters.ReservedBookID = Console.ReadLine();
            Console.WriteLine("State the parameter ''Average price''to be filled into to the hidden in swishtests");
            parameters.AveragePrice = Console.ReadLine();
            Console.WriteLine("State the parameter ''AveragePricePlusExtra''to be filled into to the hidden in swishtests");
            parameters.AveragePricePlusExtra = Console.ReadLine();
            Console.WriteLine("State the parameter ''Payment reference''to be filled into to the hidden in swishtests");
            parameters.PaymentReference = Console.ReadLine();
            Console.WriteLine("State the parameter ''Filled swish payment reference''to be filled into to the hidden in swishtests");
            parameters.FilledSwishPaymentReference = Console.ReadLine();

            string jsonParameters = JsonSerializer.Serialize(parameters);
            File.WriteAllText(fileName, jsonParameters);
            List<string> data = new List<string>();
            int a = Environment.ExitCode;
            int value = 99;
            return(value);
        }
        
    }
}
            

            

        

    
