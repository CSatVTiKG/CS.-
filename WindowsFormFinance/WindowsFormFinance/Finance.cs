using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormFinance
{
    /// <summary>
    /// Перечисление, которое задает категорию доходов
    /// </summary>
    public enum IncomeType
    {
        [Description("Зарплата")]  //- необходимы для удобного чтения пользователем названий категорий на форме
        Salary,
        [Description("Премия")]
        Prize,
        [Description("Стипендия")]
        Payment };

    /// <summary>
    /// Перечисление, которое задает категорию расходов
    /// </summary>
    public enum ExpenseType {
        [Description("Еда")]
        Food,
        [Description("Общежитие")]
        Home,
        [Description("Здоровье")]
        Health,
        [Description("Одежда/аксессуары")]
        Cloth,
        [Description("Транспорт")]
        Transport,
        [Description("Связь")]
        Phone,
        [Description("Отдых/развлечения")]
        Entrance };

    /// <summary>
    /// Абстрактный класс, общий для объектов Операция (как доход, так и расход)
    /// </summary>
    public abstract class Operation
    {
        [JsonInclude] // необходимы для указания полей, которые сохраняются в json файле
        public string Name { get; set; }        // Название операции
        [JsonInclude]
        public float Sum { get; set; }          // Сумма
        [JsonInclude]
        public DateTime Date { get; set; }      // Дата осуществления операции
       
    }

    // Класс для объектов Доход, наследуемый от класса Operation
    public class Income: Operation
    {
        [JsonInclude]
        public IncomeType Type { get; set; }    // Категория дохода
    }

    // Класс для объектов Расход, наследуемый от класса Operation
    public class Expense : Operation
    {
        [JsonInclude]
        public ExpenseType Type { get; set; }      // Категория расхода
    }

    // Статический класс для обмена данными между главной формой
    // и формой добавления новой валютной операции
    public static class Buffer
    {
        public static string Name { get; set; }            // Название операции
        public static float Sum { get; set; }              // Сумма
        public static DateTime Date { get; set; }          // Дата совершения
        public static IncomeType Income { get; set; }      // Категория дохода
        public static ExpenseType Expense { get; set; }    // Категория расхода
        public static bool Type { get; set; }              // Тип: true - доход, false - расход
    }

    // Класс Финансы, который содержит список валютных операций
    // и упрощает обращение к ним
    public class Finance
    {
        [JsonInclude]
        public float Balance { get; set; }          // Баланс: разница между доходом и расходом
        [JsonInclude]
        public float CommonIncome { get; set; }     // Общий доход
        [JsonInclude]
        public float CommonExpense { get; set; }    // Общий расход
        public List<Operation> data;                // Список валютных операций

        // Конструктор без параметров
        public Finance()
        {
            Balance = 0;
            CommonIncome = 0;
            CommonExpense = 0;
            data = new List<Operation>();
        }

        // Функция добавления дохода в список валютных операций
        public void AddOperation(Income income)
        {
            // К текущему балансу добавляет сумму дохода
            Balance += income.Sum;
            // К общей сумме дохода добавляет сумму дохода
            CommonIncome += income.Sum;
            // Добавляет доход к списку валютных операций
            data.Add(income);
        }
        // Перегруженная функция добавления расхода в список валютных операций
        public void AddOperation(Expense expense)
        {
            // От текущего баланса отнимает сумму расхода
            Balance -= expense.Sum;
            // К общей сумме расхода добавляет сумму расхода
            CommonExpense += expense.Sum;
            // Добавляет расход к списку валютных операций
            data.Add(expense);
        }

        // Функция фильтрации по заданному месяцу: возвращает список операций за заданный месяц
        public Finance FilterMonth(int month)
        {
            Finance filter = new Finance();
            foreach (var item in data)
            {
                if (item.Date.Month == month)
                {
                    if (item is Income)
                        filter.AddOperation((Income)item);
                    else
                        filter.AddOperation((Expense)item);
                }
            }
            return filter;
        }

        // Функция фильтрации по категории дохода
        public Finance FilterIncome(CheckedListBox.CheckedIndexCollection index)
        {
            Finance filter = new Finance();
            foreach (var item in data)
            {
                if (item is Income)
                {
                    Income temp = (Income)item;
                    if (index.Contains(Convert.ToInt32(temp.Type)))
                        filter.AddOperation(temp);
                }
                else
                    filter.AddOperation((Expense)item);
            }
            return filter;
        }

        // Функция фильтрации по категории расхода
        public Finance FilterExpense(CheckedListBox.CheckedIndexCollection index)
        {
            Finance filter = new Finance();
            foreach (var item in data)
            {
                if (item is Expense)
                {
                    Expense temp = (Expense)item;
                    if (index.Contains(Convert.ToInt32(temp.Type)))
                        filter.AddOperation(temp);
                }
                else
                    filter.AddOperation((Income)item);
            }
            return filter;
        }

        // Функция, которая записывает список валютных операций в строку, в формате json
        public string OperationsToJson()
        {
            string operations = "";
            var options = new JsonSerializerOptions { WriteIndented = true, };
            options.Converters.Add(new JsonStringEnumConverter());
            foreach (var item in data)
            {
                operations += ";";
                if (item is Income) operations += JsonSerializer.Serialize((Income)item, options);
                else if (item is Expense) operations += JsonSerializer.Serialize((Expense)item, options);
            }
            return operations;
        }
    }
}
