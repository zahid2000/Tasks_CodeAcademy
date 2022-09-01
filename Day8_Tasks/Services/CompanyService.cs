using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day8_Tasks.Delegates;
using Day8_Tasks.ILogger;
using Day8_Tasks.Models;

namespace Day8_Tasks.Services
{
    public class CompanyService
    {
        private Company _company;
        ConsoleLogger logger = new ConsoleLogger();
        public CompanyService(Company company)
        {
            _company = company;
        }
        public void Register(User user)
        {
            if (RegisterCheck(user))
            {
                LoggerManager loggerDelegate = new LoggerManager(logger.Log);
                _company.AddUser(user);
                loggerDelegate.Invoke($"Tebrikler.IStifadeci melumatlari daxil edildi.\n UserName -> {user.GetUsername()} , Email -> {user.GetEmail()} , Password -> {user.GetPassword()} ");
            }
        }
        public bool Login(string username, string password)
        {
            LoggerManager loggerDelegate = new LoggerManager(logger.Log);

            var result = _company.GetUsers().Find(u => u.GetUsername() == username && u.GetPassword() == password);
            if (result == null)
            {
                loggerDelegate.Invoke("User is not found");
                return false;
            }
            loggerDelegate.Invoke("Congratulations.Logged in your account");
            return true;


        }
        public bool RegisterCheck(User user)
        {
            LoggerManager loggerDelegate = new LoggerManager(logger.Log);

            user = UserService.SetUserInfo(user);
            bool result = _company.GetUsers().Find(u => u.Name == user.Name && u.Surname == user.Surname && u.GetUsername() == user.GetUsername()) != null;
            if (result)
            {
                loggerDelegate.Invoke("Bu istifadeci artiq var");
                return false;
            }
            else return true;
        }
        public User GetById(int id) => _company.GetUsers().Find(u => u.Id == id);
        public void UpdateName(string name, int id)
        {
            User user = GetById(id);
            user.Name = name;
            LoggerManager loggerDelegate = new LoggerManager(logger.Log);
            loggerDelegate.Invoke($"Name has been updated -> {name}");
        }
        public void UpdateSurname(string surname, int id)
        {
            User user = GetById(id);
            user.Surname = surname;
            LoggerManager loggerDelegate = new LoggerManager(logger.Log);
            loggerDelegate.Invoke($"Surname has been updated -> {surname}");
        }
        public void UpdateUsername(string username, int id)
        {
            User user = GetById(id);
            user.SetUserName(username);
            LoggerManager loggerDelegate = new LoggerManager(logger.Log);
            loggerDelegate.Invoke($"UsertName has been updated -> {username}");
        }
        public void UpdateEmail(string email, int id)
        {
            User user = GetById(id);
            user.SetEmail(email);
            LoggerManager loggerDelegate = new LoggerManager(logger.Log);
            loggerDelegate.Invoke($"Email has been updated -> {email}");
        }
        public void DeleteUserById(int id)
        {
            User user= _company.GetUsers().FirstOrDefault(x => x.Id == id);
            _company.DeleteUser(user);
            LoggerManager loggerDelegate = new LoggerManager(logger.Log);
            loggerDelegate.Invoke($"User has been deleted ");
        }

        public bool CheckuserExistsById(int id)
        {
            return  _company.GetUsers().Any(x => x.Id == id);
        }
    }
}
