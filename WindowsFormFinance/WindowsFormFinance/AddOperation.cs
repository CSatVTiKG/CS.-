using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormFinance
{
    public partial class AddOperation : Form
    {
        public AddOperation()
        {
            InitializeComponent();
        }
        class Str
        {
            string str;
        }
        // Отображение компонентов при загрузке формы
        private void AddOperation_Load(object sender, EventArgs e)
        {
            LoadEnumDescription(comboBox1, typeof(IncomeType));
            LoadEnumDescription(comboBox2, typeof(ExpenseType));
        }

        // Отображение нужного comboBox для выбора категории дохода
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            comboBox2.Visible = false;
        }

        // Отображение нужного comboBox для выбора категории расхода
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
            comboBox1.Visible = false;
        }

        // Кнопка добавления новой операции - сохранение данных введенных с формы
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    Buffer.Type = true;
                    Buffer.Income = (IncomeType)comboBox1.SelectedValue;
                }
                else if (radioButton2.Checked)
                {
                    Buffer.Type = false;
                    Buffer.Expense = (ExpenseType)comboBox2.SelectedValue;
                }

                Buffer.Name = textBox1.Text;
                Buffer.Sum = float.Parse(textBox2.Text);
                //Buffer.Date = dateTimePicker1.Value.Date;
                Buffer.Date = dateTimePicker1.Value.Date;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Вы не ввели сумму!");
                }
                else if(textBox2.Text is Str)
                    { }
                    MessageBox.Show("Неверный тип данных!");
            }  
        }
        // Функция, для удобного чтения категорий в comboBox
        public static void LoadEnumDescription(ComboBox cbox, Type type)
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
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
                this.Close();
        }
    }
}
