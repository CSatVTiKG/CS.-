using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace WindowsFormFinance
{
 /// <summary>
 /// 
 /// </summary>
 public partial class MainForm : Form
    {
        /// <summary>
        /// Переменная - объект Мои финансы
        /// </summary>
        Finance myFinance;

        public MainForm()
        {
            InitializeComponent();
            myFinance = new Finance();
        }

        /// <summary>
        /// Отображение компонентов при загрузке формы
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadEnumDescription(checkedListBox1, typeof(IncomeType));
            LoadEnumDescription(checkedListBox2, typeof(ExpenseType));
            //comboBox1.Enabled = true;
            radioButton4.Checked = true; 
            radioButton5.Checked = true;
        }

        // Добавление дохода в Мои финансы и отображение на форму в компонент listView1
        public void AddToList(Income income, Finance finance)
        {
            finance.AddOperation(income);
            ListViewItem item = new ListViewItem();
            item.Text = income.Name;
            // Необходимые преобразования, чтобы список категорий дохода был удобно читаем (а не на английском)
            string s = (Attribute.GetCustomAttribute(income.Type.GetType().GetField(income.Type.ToString()),
                                                     typeof(DescriptionAttribute)) as DescriptionAttribute).Description;
            item.SubItems.Add(s);
            item.SubItems.Add(income.Date.ToShortDateString());//--------------------
            item.SubItems.Add(income.Sum.ToString() + " р.");
            listView1.Items.Add(item);
        }

        // Добавление расхода в Мои финансы и отображение на форму в компонент listView1
        public void AddToList(Expense expense, Finance finance)
        {
            finance.AddOperation(expense);
            ListViewItem item = new ListViewItem();
            item.Text = expense.Name;
            string s = (Attribute.GetCustomAttribute(expense.Type.GetType().GetField(expense.Type.ToString()),
                                                     typeof(DescriptionAttribute)) as DescriptionAttribute).Description;
            item.SubItems.Add(s);
            //item.SubItems.Add(expense.Date.ToString());
            item.SubItems.Add(expense.Date.ToShortDateString());//------------------
            item.SubItems.Add((-expense.Sum).ToString() + " р.");
            listView1.Items.Add(item);
        }

        // Кнопка вызова формы добавления новой операции и сохранения результатов
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddOperation addForm = new AddOperation();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // Если вернули объект Доход - сохраняем его как Доход
                if (Buffer.Type == true)
                {
                    Income income = new Income();
                    income.Type = Buffer.Income;
                    income.Name = Buffer.Name;
                    income.Sum = Buffer.Sum;
                    income.Date = Buffer.Date;
                    AddToList(income, myFinance);
                }
                // Иначе вернули объект Расход - сохраняем его как Расход
                else
                {
                    Expense expense = new Expense();
                    expense.Type = Buffer.Expense;
                    expense.Name = Buffer.Name;
                    expense.Sum = Buffer.Sum;
                    expense.Date = Buffer.Date;
                    AddToList(expense, myFinance);
                }
                // Выводим в textBox1 суммарную информацию по финансам
                textBox1.Text = "Доход: " + myFinance.CommonIncome + " р.\r\n";
                textBox1.Text += "Расход: " + myFinance.CommonExpense + " р.\r\n";
                textBox1.Text += "Текущий баланс: " + myFinance.Balance + " р.";
            }
        }

        // Функция обработки кнопки Фильтровать - вывод списка операций по фильтру
        private void btnFilter_Click(object sender, EventArgs e)
        {
            Finance temp = new Finance();
            if (radioButton1.Checked == true)
                temp = myFinance;
            if (radioButton2.Checked == true)
                temp = myFinance.FilterMonth(DateTime.Now.Month);
            else if (radioButton3.Checked == true)
                temp = myFinance.FilterMonth(comboBox1.SelectedIndex + 1);
            if (radioButton4.Checked == false)
            {
                temp = temp.FilterIncome(checkedListBox1.CheckedIndices);
            }
            if (radioButton5.Checked == false)
            {
                temp = temp.FilterExpense(checkedListBox2.CheckedIndices);
            }

            Finance filter = new Finance();
            listView1.Items.Clear();
            foreach (var item in temp.data)
            {
                if (item is Income)
                    AddToList((Income)item, filter);
                else
                    AddToList((Expense)item, filter);
            }
            textBox1.Text = "Доход: " + temp.CommonIncome + " р.\r\n";
            textBox1.Text += "Расход: " + temp.CommonExpense + " р.\r\n";
            textBox1.Text += "Текущий баланс: " + temp.Balance + " р.";
        }

        
        /// <summary>
        /// Кнопка Сохранить в файл - сохраняем в формате json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            var options = new JsonSerializerOptions { WriteIndented = true, };
            options.Converters.Add(new JsonStringEnumConverter());
            string fileName = Directory.GetCurrentDirectory() + "//data.json";
            string jsonString = JsonSerializer.Serialize(myFinance, options);
            jsonString += myFinance.OperationsToJson();
            File.WriteAllText(fileName, jsonString);
            MessageBox.Show("Данные успешно сохранены в файл!");
        }

        // Кнопка Загрузить с файла
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            var options = new JsonSerializerOptions { WriteIndented = true, };
            options.Converters.Add(new JsonStringEnumConverter());
            string fileName = Directory.GetCurrentDirectory() + "//data.json";
            string jsonString = File.ReadAllText(fileName);
            string[] list = jsonString.Split(';');

            myFinance = new Finance();
            listView1.Items.Clear();
            foreach (var item in list.Skip(1).ToArray())
            {
                if (Enum.GetNames(typeof(ExpenseType)).Any(s => item.Contains(s)))
                {
                    Expense add = JsonSerializer.Deserialize<Expense>(item, options);
                    AddToList(add, myFinance);
                }
                else
                {
                    Income add = JsonSerializer.Deserialize<Income>(item, options);
                    AddToList(add, myFinance);
                }               
            }
            textBox1.Text = "Доход: " + myFinance.CommonIncome + " р.\r\n";
            textBox1.Text += "Расход: " + myFinance.CommonExpense + " р.\r\n";
            textBox1.Text += "Текущий баланс: " + myFinance.Balance + " р.";
        }

        // Функция удаления выбранной валютной операции
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int selected = listView1.SelectedIndices[0];
            var item = listView1.SelectedItems[0];
            var find = myFinance.data.ElementAt(selected);
            if (item.SubItems[3].Text[0] != '-')
            {
                myFinance.Balance -= find.Sum;
                myFinance.CommonIncome -= find.Sum;
            }
            else
            {
                myFinance.Balance += find.Sum;
                myFinance.CommonExpense -= find.Sum;
            }
            listView1.Items.RemoveAt(selected);
            myFinance.data.RemoveAt(selected);
            textBox1.Text = "Доход: " + myFinance.CommonIncome + " р.\r\n";
            textBox1.Text += "Расход: " + myFinance.CommonExpense + " р.\r\n";
            textBox1.Text += "Текущий баланс: " + myFinance.Balance + " р.";
        }

        // Функции, которые снимают и добавляют доступность компонентов
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButton4.Checked = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButton5.Checked = false;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
                checkedListBox2.SetItemChecked(i, false);
        }

        // Функция, для удобного чтения категорий в checkedListBox
        public static void LoadEnumDescription(CheckedListBox cbox, Type type)
        {
            cbox.DataSource = Enum.GetValues(type)
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                    typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            cbox.DisplayMember = "Description";
            cbox.ValueMember = "value";
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = listView1.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
