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
        // Допишите конструктор, который вызовет метод Validate для проверки значений.
        // Если некорректные – выбросить исключение
        public Contact(string name, string phone)
        {
            Name = name;   // ← используем свойства
            Phone = phone;
            if (!Validate())
                throw new ArgumentException("Некорректные данные контакта");
        }
        public string Name
        {
            get => _name;
            set
            {
                Set(ref _name, value);
                // TODO: допишите установку _name и вызов

                // события изменения свойства

            }
        }
        public string Phone
        {
            get => _phone;
            set
            {
                Set(ref _phone, value);
                // TODO: допишите установку _phone и вызов

                // события изменения свойства

            }
        }
        // TODO: добавьте метод Validate(), который
        // проверяет, что Name не пуст и Phone
        // соответствует формату +7XXXXXXXXXX (или без кода страны)
        // Метод должен возвращать bool
        bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Phone) || !Regex.IsMatch(Phone, @"^(\+7\d{10}|\d{10})$"))
            {
                return false;
            }
            return true;
        }
    }
}
