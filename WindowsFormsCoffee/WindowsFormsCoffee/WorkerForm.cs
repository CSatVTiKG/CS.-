using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WindowsFormsCoffee
{
    public partial class WorkerForm : Form
    {
        List<Zakaz> newZakaz;
        List<DishZakaz> currentDish;

        public WorkerForm()
        {
            InitializeComponent();
            newZakaz = new List<Zakaz>();
            currentDish = new List<DishZakaz>();
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
            loadZakazFromJson("new_zakaz.json");
            AddZakazToListView();
        }

        // Сохраняем заказы в формате json
        private void saveZakazToJson()
        {
            List<Zakaz> old = new List<Zakaz>();
            old.AddRange(newZakaz.FindAll(s => s.Status == "выполнен"));
            List<Zakaz> temp = newZakaz;
            newZakaz = new List<Zakaz>();
            loadZakazFromJson("old_zakaz.json");
            newZakaz.AddRange(old);
            var options = new JsonSerializerOptions { WriteIndented = true, };
            options.Converters.Add(new JsonStringEnumConverter());
            string fileName = Directory.GetCurrentDirectory() + "//old_zakaz.json";           
            string jsonString = JsonSerializer.Serialize(newZakaz, options);         
            File.WriteAllText(fileName, jsonString);
            newZakaz = temp;
            foreach (var item in old)
            {
                newZakaz.Remove(item);
            }
            AddZakazToListView();
            fileName = Directory.GetCurrentDirectory() + "//new_zakaz.json";
            jsonString = JsonSerializer.Serialize(newZakaz, options);
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
                    newZakaz.Add(zakaz);
                }
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Zakaz selected = newZakaz.Find(t => t.Time.ToString() == listView1.SelectedItems[0].SubItems[1].Text);
                selected.Status = "выполнен";
            }
            listView2.Items.Clear();
            textPhone.Clear();
            textPlace.Clear();
            textSum.Clear();
            textTime.Clear();
            saveZakazToJson();
        }

        private void AddDishToListView()
        {
            listView2.Items.Clear();
            foreach (var dish in currentDish)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dish.Name;
                item.SubItems.Add(dish.Count.ToString());
                item.SubItems.Add(dish.Sum.ToString() + " р.");
                listView2.Items.Add(item);
            }
        }

        private void AddZakazToListView()
        {
            listView1.Items.Clear();
            foreach (var zakaz in newZakaz)
            {
                ListViewItem item = new ListViewItem();
                item.Text = zakaz.Phone;
                item.SubItems.Add(zakaz.Time.ToString());
                item.SubItems.Add(zakaz.Sum.ToString() + " р.");
                item.SubItems.Add(zakaz.Place);
                listView1.Items.Add(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Zakaz selected = newZakaz.Find(t => t.Time.ToString() == listView1.SelectedItems[0].SubItems[1].Text);
                textPhone.Text = selected.Phone;
                textTime.Text = selected.Time.ToString();
                textPlace.Text = selected.Place;
                textSum.Text = selected.Sum.ToString();
                currentDish = selected.Dishes;
                AddDishToListView();
            }
        }
    }
}
