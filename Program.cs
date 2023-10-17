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
       public  string ExistingPhone { get; set; }
        public string NewPhone { get; set; }
        public string ExistingPassword { get; set; }
        public string NewPassword { get; set; }
        public string BookID { get; set; }
        public string BookQRcode { get; set; }
        public string ReservedBookID { get; set; }
        public string AveragePrice { get; set; }
        public string AveragePricePlusExtra { get; set; }
        public string PaymentReference { get; set; }
        public string Amount { get; set; }
        public string Browsertype { get; set; }
        public string FilledSwishPaymentReference { get; set; }
        public string ReservedBookQRcode { get; set; }  
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
            Console.WriteLine("State the Book QR code of a book the is always reserved");
            parameters.ReservedBookQRcode= Console.ReadLine();  
            Console.WriteLine("Choose browsertype: Type edge,mozilla or chrome ");
            parameters.Browsertype = Console.ReadLine();
            Console.WriteLine("State the parameter ''Average price''to be filled into to the hidden in swishtests");
            parameters.AveragePrice = Console.ReadLine();
            Console.WriteLine("State the parameter ''AveragePricePlusExtra''to be filled into to the hidden in swishtests");
            parameters.AveragePricePlusExtra = Console.ReadLine();
            Console.WriteLine("State the parameter ''Payment reference''to be filled into to the hidden in swishtests");
            parameters.PaymentReference = Console.ReadLine();
            Console.WriteLine("State the parameter ''Filled swish payment reference''to be filled into to the hidden in swishtests");
            parameters.FilledSwishPaymentReference = Console.ReadLine();

            string jsonParameters = JsonSerializer.Serialize(parameters);
            //Environment.SetEnvironmentVariable("jsonParameters",jsonParameters );
            //string jsonParameters_ = Environment.GetEnvironmentVariable("jsonParameters");
           // Console.WriteLine(jsonParameters_);
           // string path = Path.Combine(,  "JsonParameters1.txt");
            File.WriteAllText(Path.GetTempPath()+"JsonParameters1.txt", jsonParameters);
            
            Console.WriteLine(File.ReadAllText(Path.GetTempPath()+"JsonParameters1.txt"));
            List<string> data = new List<string>();
            int a = Environment.ExitCode;
            int value = 99;
            Console.WriteLine(a.ToString());
            return (a);
        }
        
    }
}
            

            

        

    
