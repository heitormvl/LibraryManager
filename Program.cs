namespace LibraryManagementSystem
{
    class Program
    {
        private static readonly Random random = new Random();
        private static readonly List<Book> books = new List<Book>();
        private static readonly List<User> users = new List<User>();
        private static bool exit = false;

        static void Main(string[] args)
        {
            while (!exit)
            {
                DisplayMenu();
                int option = GetIntegerInput("Enter your choice: ");
                PerformAction(option);
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine(
                "1. Borrow book\n" +
                "2. Return book\n" +
                "3. Add Book\n" +
                "4. Remove Book\n" +
                "5. Add User\n" +
                "6. Remove User\n" +
                "7. Search Book\n" +
                "8. Search User\n" +
                "9. Exit\n" +
                "Choose option (1-9): ");
        }

        private static void PerformAction(int option)
        {
            switch (option)
            {
                case 1:
                    BorrowBook();
                    break;
                case 2:
                    ReturnBook();
                    break;
                case 3:
                    AddBook();
                    break;
                case 4:
                    RemoveBook();
                    break;
                case 5:
                    AddUser();
                    break;
                case 6:
                    RemoveUser();
                    break;
                case 7:
                    SearchBook();
                    break;
                case 8:
                    SearchUser();
                    break;
                case 9:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }

        private static void AddUser()
        {
            string userName = GetStringInput("Enter user name: ");
            int id = random.Next(1, 1000);
            users.Add(new User(userName, id));
            Console.WriteLine($"User {userName} added successfully with ID {id}");
        }

        private static void RemoveUser()
        {
            int userId = GetIntegerInput("Enter user ID to remove: ");
            var user = users.Find(u => u.Id == userId);
            if (user != null)
            {
                users.Remove(user);
                Console.WriteLine($"User {user.Name} removed successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        private static void BorrowBook()
        {
            int userId = GetIntegerInput("Enter user ID: ");
            var user = users.Find(u => u.Id == userId);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            int bookId = GetIntegerInput("Enter book ID: ");
            var book = books.Find(b => b.Id == bookId && !b.IsBorrowed);
            if (book != null)
            {
                user.BorrowBook(book);
            }
            else
            {
                Console.WriteLine("Book is already borrowed or not found.");
            }
        }

        private static void ReturnBook()
        {
            int userId = GetIntegerInput("Enter user ID: ");
            var user = users.Find(u => u.Id == userId);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            int bookId = GetIntegerInput("Enter book ID: ");
            var book = books.Find(b => b.Id == bookId && b.IsBorrowed);
            if (book != null)
            {
                user.ReturnBook(book);
            }
            else
            {
                Console.WriteLine("Book not found or not borrowed.");
            }
        }

        private static void AddBook()
        {
            string title = GetStringInput("Enter book title: ");
            string author = GetStringInput("Enter book author: ");
            int id = random.Next(1, 1000);
            books.Add(new Book(title, author, id, false));
            Console.WriteLine($"Book {title} added successfully with ID {id}");
        }

        private static void RemoveBook()
        {
            int bookId = GetIntegerInput("Enter book ID to remove: ");
            var book = books.Find(b => b.Id == bookId);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("Book removed successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        private static void SearchBook()
        {
            int bookId = GetIntegerInput("Enter book ID to search: ");
            var foundBooks = books.Where(b => b.Id == bookId).ToList();
            if (foundBooks.Count > 0)
            {
                Console.WriteLine("Found books:");
                foreach (var book in foundBooks)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Borrowed: {book.IsBorrowed}");
                }
            }
            else
            {
                Console.WriteLine("No books found with that ID.");
            }
        }

        private static void SearchUser()
        {
            string name = GetStringInput("Enter user name to search: ");
            var foundUsers = users.Where(u => u.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            if (foundUsers.Count > 0)
            {
                Console.WriteLine("Found users:");
                foreach (var user in foundUsers)
                {
                    Console.WriteLine($"ID: {user.Id}, Name: {user.Name}");
                }
            }
            else
            {
                Console.WriteLine("No users found with that name.");
            }
        }

        private static int GetIntegerInput(string prompt)
        {
            int result;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Invalid input. Please enter a valid number: ");
            }
            return result;
        }

        private static string GetStringInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }

    class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Id { get; private set; }
        public bool IsBorrowed { get; set; }

        public Book(string title, string author, int id, bool isBorrowed)
        {
            Title = title;
            Author = author;
            Id = id;
            IsBorrowed = isBorrowed;
        }
    }

    class User
    {
        public string Name { get; private set; }
        public int Id { get; private set; }

        public User(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public void BorrowBook(Book book)
        {
            book.IsBorrowed = true;
            Console.WriteLine($"User {Name} borrowed book {book.Title}.");
        }

        public void ReturnBook(Book book)
        {
            book.IsBorrowed = false;
            Console.WriteLine($"User {Name} returned book {book.Title}.");
        }
    }
}
