using System;
namespace BookInterface
{
    interface IMedia
    {
        //Properties
        public int Sku { get; set; } //imaginary inventory number
        public string Title { get; set; } //title of product

        //Methods
        public string BookFormat();
        public string Print();
    }
    class Program
    {
        class Book : IMedia
        {
            //from interface 
            public int Sku { get; set; } 
            public string Title { get; set; } 
            //additional properties
            public double Isbn {  get; set; }
            public string Author { get; set; }
            public string Format { get; set; }

            public Book()  //default
            {
                Sku = 0;
                Title = string.Empty;
                Isbn = 0;
                Author = string.Empty;
                Format = string.Empty;
            }
            public Book(int sku, string title, double isbn, string author, string format) //parameterized
            {
                Sku = sku;
                Title = title;
                Isbn = isbn;
                Author = author;
                Format = format;
            }
            public virtual string BookFormat() // format different based on print/digital(audio/ebook)
            {
                Console.WriteLine("Is this a soft or hard cover book? (choose soft or hard)");
                Format = Console.ReadLine();

                if (Format == "soft")
                    Format = "This is a soft cover book.";
                else
                    Format = "This is a hardcover book.";
                return Format;
            }
            public virtual string Print()
            {
                return "\nPrint Book Information: \nSKU: " + Sku + "\nISBN: " + Isbn + "\nTitle: " + Title + " by " + Author + "\nFormat: " + Format;
            }
        }
        class Digital : Book //derived class
        {
            //additional fields/properties
            public string FileType { get; set; }

            //constructor
            public Digital() : base()
            {
                FileType = string.Empty;
            }
            //parameterized constructor
            public Digital(int sku, string title, double isbn, string author, string format, string fileType) : base(sku, title, isbn, author, format)
            {
                FileType = fileType;
            }
            public override string BookFormat() //format method for digital book
            {
                Console.WriteLine("What filetype is this? mp3, FLAC, epub, mobi");
                FileType = Console.ReadLine();

                    if (FileType == "mp3" || FileType == "FLAC")
                    {
                        FileType = "This is a digital audiobook";
                    }
                    else
                    {
                        FileType = "This is an ebook";
                    }
                
                return FileType;
            }

            public override string Print()
            {
                return "\nDigital Book information:\n SKU: " + Sku + "\nISBN: " + Isbn + "\nTitle: " + Title +  " by " + Author + "\nFormat: " + Format + "\nFile Type: " + FileType;

            }
        } //end book class

        static void Main(string[] args)
        {
            //book object
            Book book = new Book(1234, "Stardust", 9780062200396, "Neil Gaiman", "print");
            Console.WriteLine("Printing Book class object...\n");
            Console.WriteLine(book.Print());
            Console.WriteLine();

            //digital book object
            Digital digital = new Digital(4567, "Yumi and the Nightmare Painter", 9781938570445, "Brandon Sanderson", "digital", "mp3");
            Console.WriteLine("Printing derived digital book class...\n");
            Console.WriteLine(digital.Print());

            //user prompt
            
            string tempAns;
            Console.WriteLine("User-prompted class...\n");
            Console.WriteLine("What type of media are you entering? print or digital?");
            tempAns = Console.ReadLine();
            if (tempAns == "print")
            {
                Book book2 = new Book();
                Console.WriteLine("Please enter a SKU # (whole numbers only): ");
                book2.Sku = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the ISBN (whole numbers only): ");
                book2.Isbn = double.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the book title: ");
                book2.Title = Console.ReadLine();
                Console.WriteLine("Please enter the author: ");
                book2.Author = Console.ReadLine();
                book2.Format = book2.BookFormat();
                Console.WriteLine();
                Console.WriteLine(book2.Print());
            }
            else
            {
                Digital digital2 = new Digital();
                Console.WriteLine("Please enter a SKU # (whole numbers only): ");
                digital2.Sku = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the ISBN (whole numbers only): ");
                digital2.Isbn = double.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the book title: ");
                digital2.Title = Console.ReadLine();
                Console.WriteLine("Please enter the author: ");
                digital2.Author = Console.ReadLine();
                digital2.Format = tempAns;
                digital2.FileType = digital2.BookFormat();
                Console.WriteLine();
                Console.WriteLine(digital2.Print());
            }
            

        }//end Main
    } //end program class
} //end namespace
