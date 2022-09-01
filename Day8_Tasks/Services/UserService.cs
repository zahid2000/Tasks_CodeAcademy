using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Day8_Tasks.Delegates;
using Day8_Tasks.ILogger;
using Day8_Tasks.Models;

namespace Day8_Tasks.Services
{
    public class UserService
    {
        ConsoleLogger logger = new ConsoleLogger();
        public static User SetUserInfo(User user)
        {

            string username = $"{user.Name.ToLower()}.{user.Surname.ToLower()}";
            string email = $"{user.Name.ToLower()}.{user.Surname.ToLower()}@gmail.com";
            user.SetUserName(username);
            user.SetEmail(email);
            return user;
        }
        public  bool checkSurname(string surname)
        {
            LoggerManager loggerDelegate = new LoggerManager(logger.Log);

            if (string.IsNullOrEmpty(surname) || string.IsNullOrWhiteSpace(surname))
            {
                loggerDelegate.Invoke("Istifadeci soyadi bos ola bilmez");

            }
            if (surname.Length < 5)
            {
                loggerDelegate.Invoke("Istifadeci soyadi minimum 5 simvol olmalidir");
                return false;
            }
            return true;
        }
        public  bool checkUsername(string username)
        {
            LoggerManager loggerDelegate = new LoggerManager(logger.Log);

            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                loggerDelegate.Invoke("Istifadeci adi bos ola bilmez");

            }
            if (username.Length < 3)
            {
                loggerDelegate.Invoke("Istifadeci adi minimum 3 simvol olmalidir");
                return false;
            }
            return true;
        }
        public  bool checkPassword(string password)
        {
        LoggerManager loggerDelegate = new LoggerManager(logger.Log);

        if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                loggerDelegate.Invoke("Password bos ola bilmez ola bilmez!");
                return false;
            }
            if (password.Length < 8)
            {
                loggerDelegate.Invoke("Password 8 simvoldan az ola bilmez ola bilmez!");

            }
            if (!Char.IsUpper(password[0]))
            {
                loggerDelegate.Invoke("Password ilk simvolu kicik olar bilmez!");

            }

            Regex regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-zA-Z]).*$");
            Match match = regex.Match(password);
            if (!match.Success)
            {
                loggerDelegate.Invoke("Passwordda en azi bir reqem olmalidir!");
                return match.Success;
            }
            return match.Success;

        }

    }
}
