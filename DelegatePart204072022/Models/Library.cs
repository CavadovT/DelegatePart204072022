using System;
using System.Collections.Generic;
using System.Text;
using UtulsLibrary.Exceptions;

namespace DelegatePart204072022.Models
{
    internal class Library : IEntity
    {
        #region Commits and Conditions
        /*
                 Library class (IEntity-ni implement edəcək)
        - BookLimit
        - Books - Book obyektlərini özündə saxlayan bir list olacaq və private olacaq

        - AddBook() - parametr olaraq bir Book obyekti qəbul edəcək
        ilk olaraq yoxlayacaq ki listdə həmin book-un name-i ilə eyni name-də olan
        -başqa book obyekti varsa əlavə etməyəcək 
        həmçinin bu yoxlanışda baxmaq lazımdıki isDeleted dəyəri false olanlara baxsın true olanları yoxlamasın 
        əgər həmin name-də book varsa AlreadyExistsException geriyə qaytarılsın 
        əks halda Book obyektini books listinə əlavə etsin əgər limit aşılarsa CapacityLimitException baş versin.

        - GetBookById() - parametr olaraq nullable int tipindən bir id qəbul edəcək 
        həmin id-li və isDeleted statusu false olan Book obyketini tapıb geriyə qaytaracaq
        əgər id null gələrsə NullReferenceException qaytaracaq əgər heç bir kitab tapmasa null  qaytaracaq.

        - GetAllBooks() - Books listindəki elementləri başqa bir listə əlavə edib həmin listi geriyə qaytaracaq.

        - DeleteBookById() - parametr olaraq nullable int tipindən bir id qəbul edəcək
        həmin idli və isDeleted statusu false olan book obyektini tapıb isDeleted statusunu true edəcək 
        əgər id null olarsa NullReferenceException qaytaracaq əgər ele bir book tapmasa NotFoundException qaytaracaq.
        - EditBookName() - parametr olaraq int tipindən nullable bir id qəbul edəcək
        həmin id-li book-u tapıb name-ni dəyişəcək əgər id null olarsa NullReferenceException qaytaracaq 
        əgər elə bir book tapmasa NotFoundException qaytaracaq.

        - FilterByPageCount() - parametr olaraq minPageCount və maxPageCount qəbul edəcək 
        bu aralıqda olan və isDeleted statusu false olan book obyektlərini tapıb geriyə qaytaracaq.

       
                 
         */
        #endregion

        #region FIELDS
        private int _bookLimit;
        private static int _id;
        private List<Book> _books;

        #endregion


        #region PROPERTIES
        public int BookLimit
        {
            get
            {
                return _bookLimit;
            }

            set
            {
                _bookLimit = value;

            }
        }
        public int Id { get; }

        public List<Book> Books
        {
            get
            {
                return _books;
            }
            set
            {
                _books = value;
            }
        }

        #endregion
      
      
        #region CONSTRUCTORS
        public Library()
        {
            _id++;
            Id = _id;

        }
        #endregion


        #region METHODS

        public void AddBook(Book book)
        {

            foreach (Book item in Books)
            {
                if (book.IsDelet == false && item.Name == book.Name)
                {
                    throw new AlreadyExistsException("this book is already available!");

                }

            }
            if (Books.Count >= BookLimit)
            {
                throw new CapacityLimitException("Elave kitab artira bilmezsiz capasity dolub");

            }
            Books.Add(book);
            Console.WriteLine("Book Added to Library");


        }
        public void GetBookById(int? id)
        {

            if (id is null)
            {
                throw new NullReferenceException("Id Is null!!");
            }
            foreach (Book item in Books)
            {
                if (id == item.Id && item.IsDelet == false)
                {
                    item.ShowInfo();

                    return;
                }
            }

        }
        public void GetAllBooks()
        {
            foreach (var item in Books)
            {
                item.ShowInfo();
                Console.WriteLine("++++++++++++++++");
            }
        }
        public void DeletBookByID(int? id)
        {
            bool IsExist = false;
            if (id is null)
            {
                throw new NullReferenceException();
            }
            foreach (Book item in Books)
            {
                if (item.Id == id && item.IsDelet == false)
                {
                    item.IsDelet = true;
                    Console.WriteLine("This book has deleted");
                    IsExist = true;
                    return;

                }
            }
            if (IsExist == false)
            {
                throw new NoteFoundException($"With {id} book's Note Found");
            }

        }
        public void EditBookName(int? id)
        {
            bool isExit = false;

            if (id is null)
            {
                throw new NullReferenceException();
            }
            foreach (Book item in Books)
            {
                if (item.Id == id)
                {
                    Console.Write("Please enter the book New Name ");
                    string newname = (Console.ReadLine());
                    item.Name = newname;
                    isExit = true;
                    return;
                }
                isExit = false;
            }

            if (isExit == false)
            {
               throw new NoteFoundException($"With {id} book Note Found");
            }

        }
        public void FilterByPageCount(int minPageCount, int maxPageCount)
        {

            foreach (Book item in Books)
            {
                if (item.PageCount > minPageCount && item.PageCount < maxPageCount && item.IsDelet == false)
                {
                    item.ShowInfo();
                   
                }

            }

        }

        #endregion


    }
}
