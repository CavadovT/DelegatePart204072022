using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatePart204072022.Models
{
    internal class Book : IEntity
    {
        #region Commits and Conditions
        /*    
      * Book class (IEntity-ni implement edəcək)
       - Name
       - AuthorName
       - PageCount
       - IsDeleted - book obyektinin silinib silinmədiyini göstərən bir statusdur true/false olur default olaraq false olur yəni silinməmiş
       - ShowInfo()

       ps: Name, authorName, pageCount olmadan book obyekti yaratmaq olmaz
        */
        #endregion

        #region FIELDS
        private static int _id;
        private string _name;
        private string _authorName;
        private int _pageCount;
        private bool _isdelete = false;


        #endregion

        #region PROPERTIES
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string AuthorName
        {
            get
            {
                return _authorName;
            }
            set
            {
                _authorName = value;
            }
        }
        public int PageCount
        {
            get
            {
                return _pageCount;
            }
            set
            {
                _pageCount = value;
            }

        }
        public bool IsDelet
        {
            get
            {
                return _isdelete;
            }
            set
            {
                _isdelete = value;
            }

        }

        public int Id { get; }








        #endregion

        #region CONSTRUCTORS
        public Book(string name, string authorname, int pagecount)
        {
            _id++;
            Id = _id;
            Name = name;
            AuthorName = authorname;
            PageCount = pagecount;

        }


        #endregion

        #region METHODS

        public void ShowInfo()
        {
            Console.Write($"\nBook's ID: {Id}\nBook's Name: {Name}\nAuthorName Book's: {AuthorName}\nPage Count Books: {PageCount}\n");
        }
        public override string ToString()
        {
            return $"\nBook's ID: {Id}\nBook's Name: {Name}\nAuthorName Book's: {AuthorName}\nPage Count Books: {PageCount}";
        }


        #endregion


    }
}
