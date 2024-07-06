namespace ComicLibraryApp
{

    using System;
    using ComicLibrary.Models;

    public class Program
    {
        public static void Main(string[] args)
        {
            //Create Library object
            Library mylib = new Library("HiveMind Comics");
            
            //Create some books
            Book bk1 = new Book ("Spiderman 3", "Stan Lee", "000-1");
            Book bk2 = new Book ("Batman: Dark Knight", "Frank Miller","000-1");
            Book bk3 = new Book ("SandMan", "Neal Gailman","000-1");
            Book bk4 = new Book ("V for Vendetta", "Alan Moore","000-1");
            Book bk5 = new Book ("Hellboy", "Mike Mignola","000-1");
            Book bk6 = new Book ("Wonderwoman", "Mark Morrison","000-1");
            Book bk7 = new Book ("X-Men", "Adam Kubert","000-1");
            Book bk8 = new Book ("Constatine","Jamie Delano","000-1");

            //Add  books to the Library
            mylib.AddLibraryItems(bk1);
            mylib.AddLibraryItems(bk2);
            mylib.AddLibraryItems(bk3);
            mylib.AddLibraryItems(bk4);
            mylib.AddLibraryItems(bk5);
            mylib.AddLibraryItems(bk6);
            mylib.AddLibraryItems(bk7);
            mylib.AddLibraryItems(bk8);

            // Get the list of books in the library
            mylib.DisplayLibraryItems();

            Console.WriteLine("--------------------------------------------------------------");
            // Remove a book from the library
            mylib.RemoveLibraryItems(bk2);

            // Create member object
            Member mm1 = new Member("Jonh Doe","johndoe@gmil.com",mylib,"M01");
            Member mm2 = new Member("Jane Doe","janedoe@gmil.com",mylib,"M02");
            Member mm3 = new Member("DB Cooper","dbcoop@hey.com",mylib,"M03");

            // Add new members to Library
            mylib.AddMember(mm1);
            mylib.AddMember(mm2);
            mylib.AddMember(mm3);

            // Remove a member from the Library
            mylib.RemoveMember(mm3);

            Console.WriteLine("--------------------------------------------------------------");
            // Display Members
            mylib.DisplayMembers();

            // Borrowing Transactions
            BorrowTransaction bt1 = new BorrowTransaction(mm1,bk2);

                    // check availability of book
                
                    if( bt1.BorrowItem())
                    {
                        Console.WriteLine($"Borrowed {bk2.Title} succussfully by:  {mm1.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Failed to borrow");
                    }

                    // return the book

                    if (bt1.ReturnItem())
                    {
                         Console.WriteLine("Book returned successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Book has already been returned.");
                    }
                    
            Console.WriteLine("--------------------------------------------------------------");

            BorrowTransaction bt2 = new BorrowTransaction(mm1,bk6);
                // Availability of book 
                if( bt2.BorrowItem())
                    {
                        Console.WriteLine($"Borrowed {bk6.Title} succussfully by:  {mm2.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Failed to borrow");
                    }

                    // return the book

                    if (bt2.ReturnItem())
                    {
                         Console.WriteLine("Book returned successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Book has already been returned.");
                    }

        }
    }
}