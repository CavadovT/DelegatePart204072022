using System;
using System.Collections.Generic;
using System.Text;
using UtulsLibrary.Enums;

namespace DelegatePart204072022.Models
{
    internal class User : IEntity
    {

        #region COMMITS AND CONDITIONS

        /*
               User class (IEntity-ni implement edəcək)
      - Username
      - Email
      - Role - Role enumı tipindən bir role property-i olacaq.
      - ShowInfo()

      ps: Username, email, role olmadan user obyekti yaratmaq olmaz

    */
        #endregion

        #region FIELDS
        private static int _id;
        private string _username;
        private string _email;
        private Role _role;

        #endregion

        #region PROPERTIES
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public Role Role
        {
            get
            {
                return _role;
            }
            set
            {

                _role = value;
            }
        }

        public int Id { get; }

        #endregion

        #region CONSTRUCTORS
        public User(string userName, string email, Role role)
        {
            _id++;
            Id = _id;
            Username = userName;
            Email = email;
            Role = role;

        }
        #endregion

        #region METHODS

        public void ShowInnfo()
        {
            Console.Write($"\nUser Id:{Id}\nUser name: {Username}\nEmail: {Email}\nRole: {Role}");

        }
        //public override string ToString()
        //{

        //}

        #endregion
    }
}
