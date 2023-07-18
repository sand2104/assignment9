using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment9
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
        }
    }

    public class UserRegistrationSystem
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("User Registration");

                    // Prompt the user to enter their name
                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine();

                    // Prompt the user to enter their password
                    Console.Write("Enter your password: ");
                    string password = Console.ReadLine();

                    // Validate the user input
                    ValidateRegistrationData(name, password);

                    // If input is valid, display success message and registration details
                    Console.WriteLine("\nUser registration success!");
                    Console.WriteLine("Name: " + name);
                    Console.WriteLine("Password: " + password);
                }
                catch (ValidationException ex)
                {
                    // Catch and display the validation exception message
                    Console.WriteLine("\nValidation error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // Catch and display other exceptions
                    Console.WriteLine("\n An error occurred: " + ex.Message);
                }
            }

            static void ValidateRegistrationData(string name, string password)
            {
                // Check for missing or empty values
                if (string.IsNullOrWhiteSpace(name))
                    throw new ValidationException("Name is required.");

                if (string.IsNullOrWhiteSpace(password))
                    throw new ValidationException("Password is required.");

                // Validate name length
                if (name.Length < 6)
                    throw new ValidationException("Name must have at least 6 characters.");
                if (!IsAlphabetical(name))
                {
                    throw new ValidationException("Name must contain only alphabetical characters.");
                }
            }

            private static bool IsAlphabetical(string input)
            {
                foreach (char c in input)
                {
                    if (!char.IsLetter(c))
                    {
                        return false;
                    }
                }
                return true;
            }
            private static void ValidatePassword(string password)
            {
                if (string.IsNullOrEmpty(password) || password.Length < 8)
                {
                    throw new ValidationException("Password must have at least 8 characters.");
                }
            }
        }
    }
}