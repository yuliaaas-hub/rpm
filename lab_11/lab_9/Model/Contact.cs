using lab_9.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab_9.Model
{
    public class Contact : ObservableObject 
    {
        private string _name = string.Empty;
        private string _phone = string.Empty;
        public Contact(string name, string phone)
        {
            Name = name;   // ← используем свойства
            Phone = phone;
            if (!Validate(name, phone))
                throw new ArgumentException("Некорректные данные контакта");
        }
        public string Name
        {
            get => _name;
            set
            {
                Set(ref _name, value);

            }
        }
        public string Phone
        {
            get => _phone;
            set
            {
                Set(ref _phone, value);


            }
        }
        // TODO: добавьте метод Validate(), который
        // проверяет, что Name не пуст и Phone
        // соответствует формату +7XXXXXXXXXX (или без кода страны)
        // Метод должен возвращать bool

        
        public static bool Validate(string name, string phoneNum)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phoneNum) || !Regex.IsMatch(phoneNum, @"^(\+7\d{10}|\d{10})$"))
            {
                return false;
            }

            return true;
        }
       
    }
}
