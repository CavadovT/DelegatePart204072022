using DelegatePart204072022.Models;
using System;
using System.Collections.Generic;
using UtulsLibrary.Enums;

namespace DelegatePart204072022
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Commits and Conditions
            /*
                      Program class
            Bir user obyekti yaradılsın və console-dan bütün məlumatları daxil olunsun 
            əgər olmayan bir role daxil edilsə yenidən role dəyəri istənsin.
            
            Bir Library obyekti yaradılsın.
            
            Menu
            1. Add book
            2. Get book by id
            3. Get all books
            4. Delete book by id
            5. Edit book name
            6. Filter by page count
            0. Quit
        əgər user-in role-u admin deyilsə yeni bir book əlavə edə bilməsin, silə bilməsin və editləyə bilməsin 
            bir xəta mesajı çıxarsın və
            yenidən menu ekrana çıxsın.
             */
            #endregion

            string str;
            string mail;
            string name;


            try
            {
                do
                {
                    Console.Clear();
                    Console.Write("enter your name:: ");
                    name = Console.ReadLine();
                    Console.Write("Enter your mail:: ");
                    mail = Console.ReadLine();
                    Console.Write("enter your Role:: ");
                    str = Console.ReadLine();

                } while (str.ToLower() != "admin" && str.ToLower() != "member".ToLower());
                Role role = (Role)Enum.Parse(typeof(Role), str.ToLower());
                User user1 = new User(name, mail, role);
                user1.ShowInnfo();
                Console.WriteLine($"\nSuccess!!! {str.ToLower()}\n");


                
               
                List<Book> books = new List<Book>();
                Library library = new Library()
                {
                    Books = books,
                    BookLimit = 10

                };
                do
                {
                    Console.WriteLine();
                    Console.Write($"1-Add Book\n2-Get Book by Id\n3-Get all Books\n4-Delete Book by id\n5-Edit book name\n6-Filter by id\n0-Quit is program\n");
                    int n = int.Parse(Console.ReadLine());
                    switch (n)
                    {

                        case (int)MenyuBar.AddBook:
                            {

                                if (str.ToLower() == "member")
                                {
                                    Console.WriteLine("You are not an admin. You can't add books!");
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.Write("Enter Book Name: ");
                                    string Name = Console.ReadLine();
                                    Console.Write("Enter Book AuthorName: ");
                                    string AuthorName = Console.ReadLine();
                                    Console.Write("Enter Book Page Count: ");
                                    int PageCount = int.Parse(Console.ReadLine());
                                    Book book = new Book(Name, AuthorName, PageCount);
                                    library.AddBook(book);
                                }
                                break;
                            }
                        case (int)MenyuBar.GetBookById:
                            {
                                Console.Write("Please enter the Book ID: ");
                                int id = int.Parse(Console.ReadLine());
                                library.GetBookById(id);
                                break;
                            }
                        case (int)MenyuBar.GetAllBooks:
                            {
                                library.GetAllBooks();
                                break;
                            }
                        case (int)MenyuBar.DeleteBookById:
                            {
                                Console.Write("Please enter the Book ID: ");
                                int id = int.Parse(Console.ReadLine());
                                library.DeletBookByID(id);

                                break;
                            }
                        case (int)MenyuBar.EditBookName:
                            {
                                Console.Write("Please enter the book's ID: ");
                                int BName = int.Parse(Console.ReadLine());
                                library.EditBookName(BName);
                                break;
                            }
                        case (int)MenyuBar.FilterByPageCount:
                            {
                                Console.Write("Please enter the MinPageCount: ");
                                int minPageCount=int.Parse(Console.ReadLine());
                                Console.Write("Please enter the MaxPageCount: ");
                                int maxPageCount=int.Parse(Console.ReadLine());
                                library.FilterByPageCount(minPageCount, maxPageCount);
                                break;
                            }
                        case (int)MenyuBar.Quit:
                            {
                                return;
                            }

                    }


                } while (true);


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



        }
    }
}
