using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace WindowsFormsCoffee
{
    public partial class ClientForm : Form
    {
        List<Zakaz> newZakaz;
        List<Zakaz> oldZakaz;
        Zakaz current;
        List<Dish> menu;
        List<DishZakaz> myDish;
        private int count;

        public ClientForm(string phone)
        {
            InitializeComponent();
            textPhone.Text = phone;
            newZakaz = new List<Zakaz>();
            oldZakaz = new List<Zakaz>();
            current = new Zakaz();
            menu = new List<Dish>();
            myDish = new List<DishZakaz>();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            loadMenuFromJson();
            loadZakazFromJson("new_zakaz.json");
            loadZakazFromJson("old_zakaz.json");
            AddZakazToListView();
        }

        // Сохраняем заказы в формате json
        private void saveZakazToJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true, };
            options.Converters.Add(new JsonStringEnumConverter());
            string fileName = Directory.GetCurrentDirectory() + "//new_zakaz.json";
            string jsonString = JsonSerializer.Serialize(newZakaz, options);
            File.WriteAllText(fileName, jsonString);
        }

        // Загружаем заказы в формате json
        private void loadZakazFromJson(string filename)
        {
            var options = new JsonSerializerOptions { WriteIndented = true, };
            options.Converters.Add(new JsonStringEnumConverter());
            string fileName = Directory.GetCurrentDirectory() + "//" + filename;
            string jsonString = File.ReadAllText(fileName);
            using (JsonDocument document = JsonDocument.Parse(jsonString))
            {
                JsonElement root = document.RootElement;
                foreach (var item in root.EnumerateArray())
                {
                    Zakaz zakaz = new Zakaz();
                    zakaz.Phone = item.GetProperty("Phone").GetString();
                    zakaz.Time = item.GetProperty("Time").GetDateTime();
                    zakaz.Place = item.GetProperty("Place").GetString();
                    zakaz.Status = item.GetProperty("Status").GetString();
                    zakaz.Sum = (float)item.GetProperty("Sum").GetDouble();
                    JsonElement dishesElement = item.GetProperty("Dishes");
                    foreach (JsonElement sub in dishesElement.EnumerateArray())
                    {
                        DishZakaz dish = new DishZakaz();
                        dish.DishId = sub.GetProperty("DishId").GetInt32();
                        dish.Name = sub.GetProperty("Name").GetString();
                        dish.Unit = sub.GetProperty("Unit").GetString();
                        dish.Count = sub.GetProperty("Count").GetInt32();
                        dish.Price = (float)sub.GetProperty("Price").GetDouble();
                        dish.Sum = (float)sub.GetProperty("Sum").GetDouble();
                        zakaz.Dishes.Add(dish);
                    }
                    if (zakaz.Status == "выполнен")
                        oldZakaz.Add(zakaz);
                    else
                        newZakaz.Add(zakaz);
                }                
            }
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

        // Кнопка на добавление блюда
        private void btnAddDish_Click(object sender, EventArgs e)
        {
            AddDishForm form = new AddDishForm();
            if (form.ShowDialog() == DialogResult.OK)
            {              
                Dish dish = menu.Find(n => n.DishId == Buffer.DishId);
                DishZakaz newDish = new DishZakaz(dish);
                newDish.Count = Buffer.Count;
                newDish.Sum = newDish.Price * newDish.Count;
                myDish.Add(newDish);
                AddDishToListView();
                current.Sum += newDish.Sum;
                textSum.Text = current.Sum.ToString() + " р.";
            }
        }

        // Добавление блюда в listView2
        private void AddDishToListView()
        {
            listView2.Items.Clear();
            foreach (var dish in myDish)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dish.Name;
                item.SubItems.Add(dish.Count.ToString());
                item.SubItems.Add(dish.Sum.ToString() + " р.");
                listView2.Items.Add(item);
            }
        }

        // Кнопка на сохранение заказа
        private void btnSaveZakaz_Click(object sender, EventArgs e)
        {
            current.Phone = textPhone.Text;
            current.Time = DateTime.Now;
            textTime.Text = current.Time.ToString();
            
            count = listView2.Items.Count;
            if (count == 0) { MessageBox.Show("Внесите в заказ какое-нибудь блюдо!"); }
            else if (comboPlace.SelectedItem != null)
                {
                    current.Place = comboPlace.SelectedItem.ToString();
                    current.Status = "в процессе";
                    current.Dishes = myDish;
                    newZakaz.Add(current);
                    AddZakazToListView();
                }
                else { MessageBox.Show("Не выбрано место!"); }

        }

        // Добавление заказа в listView1
        private void AddZakazToListView()
        {
            listView1.Items.Clear();
            foreach (var zakaz in newZakaz)
            {
                // Отображаем новые заказы текущего пользователя
                if (zakaz.Phone == textPhone.Text)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = zakaz.Time.ToString();
                    item.SubItems.Add(zakaz.Sum.ToString() + " р.");
                    item.SubItems.Add(zakaz.Place);
                    item.SubItems.Add(zakaz.Status);
                    listView1.Items.Add(item);
                }               
            }
            foreach (var zakaz in oldZakaz)
            {
                // Отображаем старые заказы текущего пользователя
                if (zakaz.Phone == textPhone.Text)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = zakaz.Time.ToString();
                    item.SubItems.Add(zakaz.Sum.ToString() + " р.");
                    item.SubItems.Add(zakaz.Place);
                    item.SubItems.Add(zakaz.Status);
                    listView1.Items.Add(item);
                }
            }
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveZakazToJson();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                Zakaz selected = newZakaz.Find(t => t.Time.ToString() == listView1.SelectedItems[0].Text);
                if (selected != null) 
                {
                    textTime.Text = selected.Time.ToString();
                    comboPlace.Text = selected.Place;
                    textSum.Text = selected.Sum.ToString();
                    myDish = selected.Dishes;
                    AddDishToListView();
                }
                else { MessageBox.Show("Вы не можете отменить выполненный заказ!"); }
            }

        }

        /// <summary>
        /// Обработка отмены заказа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {            
            listView1.BeginUpdate();
            if (listView1.SelectedItems.Count != 0)
            {
                Zakaz selected = newZakaz.Find(t => t.Time.ToString() == listView1.SelectedItems[0].Text);
                newZakaz.Remove(selected);
                for(int i = 0; i < selected.Dishes.Count; i++)
                {
                    float priceDel = selected.Dishes[i].Price;
                    int countDel = selected.Dishes[i].Count;

                    current.Sum -= priceDel * countDel;
                }
                
                AddDishToListView();
                saveZakazToJson();
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
            listView1.EndUpdate();

            listView2.BeginUpdate();
            count = listView2.Items.Count;
            if (count != 0)
            {
                DishZakaz selected = myDish.Find(t => t.Name.ToString() == listView2.Items[0].Text);
                string d = listView2.Items[0].Text;
                myDish.Remove(myDish.Find(t => t.Name.ToString() == listView2.Items[0].Text));
                listView2.Items.Remove(listView2.Items[0]);
            }
            listView2.EndUpdate();

            textSum.Clear();
            textTime.Clear();
        }

    }
}
