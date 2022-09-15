using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBankApp
{
    public static class Helper
    {

        public static void Bank()
        {
            Console.WriteLine("Simple Bank Transfer System");
            string realUserId = "123456789";
            Console.WriteLine("Enter your starting balance:");
            decimal startingBalance = decimal.Parse(Console.ReadLine());
            string validAccountNumber = "987654321";
            Console.WriteLine("Enter your user ID: ");
            string userId = Console.ReadLine();
            Console.WriteLine("Enter the number of transfers you would like to make: ");
            int numberOfTransfer = int.Parse(Console.ReadLine());
            
            while(numberOfTransfer <= 0)
            {
                
                Console.WriteLine("Invalid Input!");
                return;
               
            }

            if(userId != realUserId)
            {
                Console.WriteLine("Unknown user ID");
                Environment.Exit(0);
                    
            }

            bool flag = true;

            do
            {
                
            // The user ID is valid
            // read amount to transfer
            Console.WriteLine("How much do you want to transfer: ");
            decimal amountToTransfer = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the account number: ");
            string recipientAccountNumber = Console.ReadLine();

            // Amount to transfer must not be negative
            if(amountToTransfer <= 0)
            {
                Console.WriteLine($"Invalid amount: ${amountToTransfer}");
                Environment.Exit(1);

            }
                
            // The charges amount to a total of 1 percent of the amount to be transferreds
            decimal charges = (decimal)0.01 * amountToTransfer;
            decimal totalAmountToBeDeducted = amountToTransfer + charges;

            Console.WriteLine($"Applicable charges: ${charges}");
            Console.WriteLine($"Total debit amount: ${totalAmountToBeDeducted}");

            // The balance must contain at least the amount to transfer plus charges
            if(startingBalance < amountToTransfer)
            {
                Console.WriteLine("Insufficient funds");
                Environment.Exit(2);
            }
                    

            // The account number must be valid:
            if(recipientAccountNumber != validAccountNumber)
            {
                Console.WriteLine($"Invalid account number: {recipientAccountNumber}");
                Environment.Exit(3);

            }
                    
            Console.WriteLine("Transfer successful");
                startingBalance -= totalAmountToBeDeducted;
                Console.WriteLine($"Current balance: ${startingBalance}");
                numberOfTransfer = numberOfTransfer - 1;

                if(numberOfTransfer == 0)
                {
                    flag = false;
                }

            } while(flag);


                

            
        }
    
    }
}