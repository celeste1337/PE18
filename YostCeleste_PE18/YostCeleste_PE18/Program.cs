using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YostCeleste_PE18
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Starts by reading data from a text file into a list
            ///Allows a user to add to the list
            ///Allows a user to delete items from the list
            ///Allows a user to see the contents of the list
            ///And at the end of the program, writes the contents of that list back to the same text file.
            ///

            StreamReader bookFile = new StreamReader("booklist.txt");
            //try/catch didn't really do anything different from this?
            
            List<string> books = new List<string>();
            //make a list
            string line = null;
            while ((line = bookFile.ReadLine()) != null)
            {
                books.Add(line);
                //add whats in the file to list already
            }
            bookFile.Close(); //close

            do //keep going until user exits
            {
                Console.WriteLine("Welcome to your library. Put what you've read in here!");
                Console.WriteLine("Do something: ADD/DELETE/VIEW/EXPORT");

                string userResponse = Console.ReadLine().ToLower();

                ///begin switch
                switch (userResponse)
                {
                    case "add":
                        //calls the add method which returns string to be added to the list
                        books.Add(Add());
                        continue;
                    case "delete":
                        Delete(books);
                        continue;
                    case "view":
                        foreach (string lineView in books) //foreach line in books (reads the file basically)
                        {
                            if (lineView == null) //if theres no data, somethings wrong
                            {
                                Console.WriteLine("Something went wrong.");
                            }
                            Console.WriteLine(lineView);
                        }
                        continue;
                    case "export":
                        Export(books);
                        continue;
                    default:
                        Console.WriteLine("Was that an option? Try again.");
                        continue;
                }



            } while (true);
        }

        public static string Add() //make object, return string
        {
            Book bookObj;

            Console.WriteLine("\tOK, let's add some fields. Give me a BOOK TITLE.");
            string bTitle = Console.ReadLine();
            Console.WriteLine("\tGive me an AUTHOR.");
            string bAuthor = Console.ReadLine();
            Console.WriteLine("\tGive me a RATING (YES or NO).");
            string bRating = Console.ReadLine();

            bookObj = new Book(bTitle, bAuthor, bRating);
            
            return bookObj.AddList(); 
        }

        public static void Delete(List<string> books) //delete previous or all based on user response
        {
            int length = books.Count;
            Console.WriteLine("\n\tDelete PREVIOUS or ALL?");
            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "previous":
                    books.RemoveAt(length-1);
                    break;
                case "all":
                    for (int i = 0; i < length; i++)
                    {
                        books.RemoveAt(i);
                    }
                    break;
                default:
                    Console.WriteLine("Choose one of the options!");
                    break;
            }
            Console.WriteLine("Deleted. \n");
        }


        public static void Export(List<string> books) //writes list to file
        {
            StreamWriter writeMe = new StreamWriter("booklist.txt");
            foreach (string lineExport in books)
            {
                writeMe.WriteLine(lineExport);
            }
            writeMe.Close();
            Console.WriteLine("Exported!");
        }
    }
}
