using System;
using System.Collections.Generic;

namespace WindowsFormsCoffee
{
    // Класс Пользователь (Работник кофейни или клиент)
    class Person: IEquatable<Person>
    {
        public string Phone { get; set; }       // Телефон
        public string Password { get; set; }    // Пароль
        public string Type { get; set; }        // Тип пользователя: worker/client

        // Конструктор с параметрами
        public Person(string phone, string password, string type)
        {
            Phone = phone;
            Password = password;
            Type = type;
        }

        // Функция сравнения двух объектов Person
        public bool Equals(Person other)
        {
            if (this.Phone == other.Phone && this.Password == other.Password
                && this.Type == other.Type)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    // Класс Блюдо
    class Dish
    {
        public int DishId { get; set; }     // Код блюда(или напитка)
        public string Name { get; set; }    // Название    
        public int Amount { get; set; }     // Объем
        public string Unit { get; set; }    // Единица измерения объема
        public float Price { get; set; }    // Цена за порцию
    }

    // Класс Заказанное блюдо
    class DishZakaz: Dish
    {
        public int Count { get; set; }      // Количество заказанных порций
        public float Sum { get; set; }      // Общая стоимость

        // Конструктор по умолчанию
        public DishZakaz() { }

        // Конструктор с параметрами
        public DishZakaz(Dish d)
        {
            this.DishId = d.DishId;
            this.Name = d.Name;
            this.Amount = d.Amount;
            this.Unit = d.Unit;
            this.Price = d.Price;
        }
    }

    // Статический класс для передачи данных заказанного блюда между формами
    public static class Buffer
    {
        public static int DishId { get; set; }
        public static int Count { get; set; }
    }

    // Класс Заказ
    class Zakaz
    {
        public string Phone { get; set; }           // Телефон клиента
        public DateTime Time { get; set; }          // Время отдачи заказа
        public string Place { get; set; }           // Место: на вынос или указанный столик
        public float Sum { get; set; }              // Общая стоимость заказа
        public string Status { get; set; }          // Статус заказа: новый или выполнен
        public List<DishZakaz> Dishes { get; set; } // Список заказанных блюд/напитков

        // Конструктор по умолчанию
        public Zakaz()
        {
            Dishes = new List<DishZakaz>();
        }
              
    }
}
