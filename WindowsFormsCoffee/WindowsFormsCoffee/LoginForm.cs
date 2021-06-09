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
    public partial class LoginForm : Form
    {
        List<Person> persons;

        public LoginForm()
        {
            InitializeComponent();
            persons = new List<Person>();
            loadPersonFromJson();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (radioWorker.Checked)
            {
                string phone = maskedTextBox1.Text;
                string pass = textBox1.Text;
                Person worker = new Person(phone, pass, "worker");
                if (persons.Contains(worker))
                {
                    WorkerForm workerForm = new WorkerForm();
                    workerForm.ShowDialog();
                    maskedTextBox1.Text = "";
                    textBox1.Text = "";
                    label3.Text = "";
                }
                else
                    label3.Text = "Не правильно введен логин/пароль!";
            }
            else if (radioClient.Checked)
            {
                string phone = maskedTextBox1.Text;
                string pass = textBox1.Text;
                Person client = new Person(phone, pass, "client");
                if (persons.Contains(client))
                {
                    ClientForm clientForm = new ClientForm(client.Phone);
                    clientForm.Text = "Мои заказы " + client.Phone;
                    clientForm.ShowDialog();
                    maskedTextBox1.Text = "";
                    textBox1.Text = "";
                    label3.Text = "";
                }
                else
                    label3.Text = "Не правильно введен логин/пароль!";
            }
            else
                label3.Text = "Не определен пользователь!";
        }

        private void btnAutorize_Click(object sender, EventArgs e)
        {
            if (radioWorker.Checked)
            {
                string phone = maskedTextBox1.Text;
                string pass = textBox1.Text;
                Person worker = new Person(phone, pass, "worker");
                persons.Add(worker);
                WorkerForm workerForm = new WorkerForm();
                workerForm.ShowDialog();
                maskedTextBox1.Text = "";
                textBox1.Text = "";
                label3.Text = "";
            }
            else if (radioClient.Checked)
            {
                string phone = maskedTextBox1.Text;
                string pass = textBox1.Text;
                Person client = new Person(phone, pass, "client");
                persons.Add(client);
                ClientForm clientForm = new ClientForm(client.Phone);
                clientForm.Text = "Мои заказы " + client.Phone;
                clientForm.ShowDialog();
                maskedTextBox1.Text = "";
                textBox1.Text = "";
                label3.Text = "";
            }
            else
                label3.Text = "Не определен пользователь!";
            savePersonToJson();
        }

        // Сохраняем логин/пароли в формате json
        private void savePersonToJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true, };
            options.Converters.Add(new JsonStringEnumConverter());
            string fileName = Directory.GetCurrentDirectory() + "//person.json";
            string jsonString = JsonSerializer.Serialize(persons, options);
            File.WriteAllText(fileName, jsonString);
        }

        // Загружаем логин/пароли в формате json
        private void loadPersonFromJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true, };
            options.Converters.Add(new JsonStringEnumConverter());
            string fileName = Directory.GetCurrentDirectory() + "//person.json";
            string jsonString = File.ReadAllText(fileName);
            persons = JsonSerializer.Deserialize<List<Person>>(jsonString, options);           
        }
    }
}
