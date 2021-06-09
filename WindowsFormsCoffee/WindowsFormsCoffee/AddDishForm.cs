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

namespace WindowsFormsCoffee
{
    public partial class AddDishForm : Form
    {
        List<Dish> menu;

        public AddDishForm()
        {
            InitializeComponent();
            menu = new List<Dish>();
        }     

        private void AddDishForm_Load(object sender, EventArgs e)
        {
            loadMenuFromJson();
            textBox2.Text = menu[0].Amount.ToString() + " " + menu[0].Unit;
            textBox3.Text = menu[0].Price + " р.";
            textBox4.Text = menu[0].Price.ToString() + " р.";
            foreach (var dish in menu)
                listBox1.Items.Add(dish.Name);                
        }

        // Загружаем заказы в формате json
        private void loadMenuFromJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true, };
            options.Converters.Add(new JsonStringEnumConverter());
            string fileName = Directory.GetCurrentDirectory() + "//menu.json";
            string jsonString = File.ReadAllText(fileName);
            menu = JsonSerializer.Deserialize<List<Dish>>(jsonString, options);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string dishName = listBox1.SelectedItem.ToString();
                Dish dish = menu.Find(n => n.Name == dishName);
                textBox2.Text = dish.Amount.ToString() + " " + dish.Unit;
                textBox3.Text = dish.Price + " р.";
                if (textBox1.Text == "")
                    textBox4.Text = dish.Price.ToString() + " р.";
                else
                    textBox4.Text = (dish.Price * int.Parse(textBox1.Text)).ToString() + " р.";
            }               
        }

        class Str
        {
            string str;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Dish dish;
            if (listBox1.SelectedItem != null)
            {
                string dishName = listBox1.SelectedItem.ToString();
                dish = menu.Find(n => n.Name == dishName);
            }
            else
                dish = menu[0];
            try
            {
                textBox4.Clear();
                if (textBox1.Text == "")
                    textBox4.Text = dish.Price.ToString() + " р.";
                textBox4.Text = (dish.Price * int.Parse(textBox1.Text)).ToString() + " р.";
            }
            catch
            {
                if (textBox4.Text is Str)
                { }
                MessageBox.Show("Введите число!");
            }
        }

        private void btnAddDish_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null && textBox1.Text != "")
            {
                string dishName = listBox1.SelectedItem.ToString();
                Dish dish = menu.Find(n => n.Name == dishName);
                Buffer.DishId = dish.DishId;
                Buffer.Count = int.Parse(textBox1.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Заполните все поля!");
        }
    }
}
