

namespace ComicLibrary.Models
{

/* Library Class */
public class Library
{
    private string name;
    private List<LibraryItem>libraryItems;
    private List<Member> members;

    //constructor
    public Library(string name)
    {
        this.name = name;
        libraryItems = new List<LibraryItem>();
        members = new List<Member>();
    }

    // Property for Library class
    public string Name
    {
        get{ return name; }
        set{ name = value; }
    }

    //Method to add LibraryItems
    public void AddLibraryItems(LibraryItem item)
    {
        libraryItems.Add(item);
    }

    // Method to remove LibraryItems
    public void RemoveLibraryItems(LibraryItem item)
    {
        libraryItems.Remove(item);
    }

    // Method to display all LibraryItems
    public void DisplayLibraryItems()
    {
        Console.WriteLine($"Library Name: {name}");
        Console.WriteLine($"Library item: ");

        foreach (var item in libraryItems)
        {
            item.GetInfo();
        }
    }

    // Method to add Member
    public void AddMember(Member member)
    {
        members.Add(member);
    }

    // Method to remove Member
    public void RemoveMember(Member member)
    {
        members.Remove(member);
    }

    // Method to display Members
    public void DisplayMembers()
    {
        Console.WriteLine($"Library Members: ");
        foreach (var member in members)
        {
            member.DisplayInfo();
        }
    }
}

/* LibraryItem Abstract Class */
public abstract class LibraryItem
{
    public string Title { get; set; }
    public string Author { get; set; }

    // Constructor
    public LibraryItem(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public abstract void GetInfo();

    public abstract bool isAvailable(); 
}

/* Book Class */
public class Book : LibraryItem
{
    public string ISBN { get; set; }
    private bool available;

    // constructor
    public Book(string title, string author, string isbn) : base(title, author)
    {
        ISBN = isbn;
        available = true;
    }

    public override void GetInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, ISBN: {ISBN}");
    }

    // Method to check availability of LibraryItem
    public override bool isAvailable()
    {
        return available;
    }

    // Method to mark unavailable LibraryItem
    public void markUnavailable()
    {
        available = false;
    }

    // Method to mark availability of LibraryItem
    public void markAvailable()
    {
        available = true;
    }

}

/* Person base class */
 public class Person 
    {
        public string? name;
        private string? email;
        
        // Constructor person
        public Person(string name, string email)
        {
            this.name = name;
            this.email = email;
        }

        // Property for base class person 
        public string Name
        {
            get { return name?? ""; }
            set { email = value; }
        }
        public string Email
        {
            get { return email?? ""; }
            set { email = value; }
        }

        // Method to display person info
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}, Email: {email} " );
        }

    }

/* Member class */
public class Member: Person
{
   private Library library;
   private string memberid;

   // Constructor for Member
   public Member(string name, string email, Library library, string memberid): base(name,email)
   {
        this.library = library;
        this.memberid = memberid;
   }
   
   // Property for Member class
   public Library Library
   {
        get { return library; }
        set { library = value; }
   }

   public string Memberid
   {    
        // Only get memberid. I dont want the id to be edited 
        get{ return memberid; }
   }
        // Method to display member
    public override void DisplayInfo()
    {
        Console.WriteLine($"Membership: {memberid} | Library: {library.Name} | Name: {name} ");
    }

    public bool canBorrowItem()
    {
         return true;
    }

}

/* Borrowing transaction class */
public class BorrowTransaction
    {
        private Member member;
        private Book book;
        private bool returned;

        // Constructor 
        public BorrowTransaction(Member member, Book book)
        {
            this.member = member;
            this.book = book;
            this.returned = false;
        }

        // check if can borrow an item 
        public bool BorrowItem()
        {
            if(member.canBorrowItem() && book.isAvailable())
            {
                book.markUnavailable();
                return true;
            }
            else
            {
                return false;
            }
        }

        // check if has returned
        public bool ReturnItem()
        {
            if(!returned)
            {
                book.markAvailable();
                returned = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
