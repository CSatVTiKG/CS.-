using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.XPath;

namespace ThesaurusDictionary
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ToDeserialize();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ClearAll()
        {
            R_WordName.Text = "слово";
            R_WordPhonetics.Text = "обозначение звучания";
            R_WordType.SelectedIndex = 0;
            R_WordSoul.SelectedIndex = 0;
            R_WordGen.SelectedIndex = 0;
            R_WordMeaning.Text = "Толкование слова";
            R_WordSynonym.Text = "синоним";
            R_WordAntonym.Text = "антоним";
            R_WordHyperonym.Text = "гипероним";
            R_WordHyponym.Text = "гипоним";
            R_WordExample.Text = "Пример использования";
        }

        private void R_WordName_TextChanged(object sender, EventArgs e) { }
        private void R_WordPhonetics_TextChanged(object sender, EventArgs e) { }
        private void R_WordType_SelectedIndexChanged(object sender, EventArgs e) { }
        private void R_WordSoul_SelectedIndexChanged(object sender, EventArgs e) { }
        private void R_WordGen_SelectedIndexChanged(object sender, EventArgs e) { }
        private void R_WordMeaning_TextChanged(object sender, EventArgs e) { }
        private void R_WordSynonym_TextChanged(object sender, EventArgs e) { }
        private void R_WordAntonym_TextChanged(object sender, EventArgs e) { }
        private void R_WordHyperonym_TextChanged(object sender, EventArgs e) { }
        private void R_WordHyponym_TextChanged(object sender, EventArgs e) { }
        private void R_WordExample_TextChanged(object sender, EventArgs e) { }

        private void R_ButtonAdd_Click(object sender, EventArgs e)
        {
            Word word = new Word(R_WordName.Text, R_WordPhonetics.Text, R_WordType.SelectedIndex, R_WordSoul.SelectedIndex, R_WordGen.SelectedIndex, R_WordMeaning.Text, R_WordSynonym.Text, R_WordAntonym.Text, R_WordHyperonym.Text, R_WordHyponym.Text, R_WordExample.Text);

            ListViewItem LVI = new ListViewItem(word.WordName);
            LVI.Tag = word;

            L_List.Items.Add(LVI);

            ToSerialize();

            ClearAll();

        }

        private void L_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(L_List.SelectedItems.Count == 1)
            {
                Word word = (Word)L_List.SelectedItems[0].Tag;

                if (word != null)
                {
                    R_WordName.Text = word.WordName;
                    R_WordPhonetics.Text = word.WordPhonetics;
                    R_WordType.SelectedIndex = word.WordType;
                    R_WordSoul.SelectedIndex = word.WordSoul;
                    R_WordGen.SelectedIndex = word.WordGen;
                    R_WordMeaning.Text = word.WordMeaning;
                    R_WordSynonym.Text = word.WordSynonym;
                    R_WordAntonym.Text = word.WordAntonym;
                    R_WordHyperonym.Text = word.WordHyperonym;
                    R_WordHyponym.Text = word.WordHyponym;
                    R_WordExample.Text = word.WordExample;
                }
            }
            else if (L_List.SelectedItems.Count == 0)
            {
                ClearAll();
            }
        }

        //после этой строки сериализация
        private void L_ButtonSerialize_Click(object sender, EventArgs e)
        {
            ToSerialize();
        }

        //с проверкой словаря
        private void ToSerialize()
        {
            if (L_List.Items.Count >= 1)
            {
                Words words = new Words();

                foreach (ListViewItem item in L_List.Items)
                {
                    if (item.Tag != null)
                    {
                        words.WordsList.Add((Word)item.Tag);
                    }

                }

                XMLSerialize(words);
            }

            else if(L_List.Items.Count == 0)
            {
                const string savemess = "Словарь пуст. Чтобы начать работу с ним, добавьте в него хотя бы одно слово.";
                const string savecap = "Сохранение словаря";

                var delbadres = MessageBox.Show(savemess, savecap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearAll();
            }
        }

        private void XMLSerialize(Words words)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Words));

            using (FileStream fstr = new FileStream("words.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fstr, words);
            }
        }

        private Words XMLDeserialize()
        {

            XmlSerializer xml = new XmlSerializer(typeof(Words));

            using (FileStream fstr = new FileStream("words.xml", FileMode.OpenOrCreate))

            {
                Words words = (Words)xml.Deserialize(fstr);
                return words;
            }

        }

        private void AddThis(Word word)
        {
            ListViewItem LVI = new ListViewItem(word.WordName);
            LVI.Tag = word;

            L_List.Items.Add(LVI);
        }

        private void L_ButtonDeserialize_Click(object sender, EventArgs e)
        {
            ToDeserialize();
        }

        //с проверкой словаря
        private void ToDeserialize()
        
        {
            ClearAll();

            L_List.Items.Clear();

            try
            {
                Words words = XMLDeserialize();

                foreach (Word word in words.WordsList)
                {
                    AddThis(word);
                }

            }

            catch
            {
                const string delmess = "Словарь пуст. Чтобы начать работу с ним, добавьте в него хотя бы одно слово.";
                const string delcap = "Загрузка словаря";

                var delbadres = MessageBox.Show(delmess, delcap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearAll();
            }

            /*   
            else if
            {
                const string delmess = "нет директории";
                const string delcap = "тест";

                var delbadres = MessageBox.Show(delmess, delcap, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (L_List.Items.Count == 0) 
            {
                const string delmess = "Словарь пуст. Чтобы начать работу с ним, добавьте в него хотя бы одно слово.";
                const string delcap = "Загрузка словаря";

                var delbadres = MessageBox.Show(delmess, delcap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearAll();
            */
        }

        private void R_ButtonClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void L_ButtonDeleteString_Click(object sender, EventArgs e)
        {
            if (L_List.SelectedItems.Count == 1)
            {
                DeleteThis();
            }

            else if(L_List.SelectedItems.Count == 0)
            {
                const string delmess = "Вы не выбрали ни одно слово";
                const string delcap = "Удаление слова";

                var delbadres = MessageBox.Show(delmess, delcap, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void DeleteThis()
        {
            string xmlpath = "words.xml";
            string thisPath;
            string choosenelement;
            string removethis;

            thisPath = Path.GetFullPath(xmlpath);

            XmlDocument docum = new XmlDocument();
            docum.Load(thisPath);

            choosenelement = L_List.FocusedItem.Text;

            removethis = "Words/WordsList/Word[WordName = '" + choosenelement + "']";

            var node = docum.SelectSingleNode(removethis);
            node.ParentNode.RemoveChild(node);
            docum.Save(thisPath);

            ToDeserialize();

            /*
            XmlNode root = docum.DocumentElement;
            XmlNode node = root.SelectSingleNode(removethis);
            */
        }

        private void R_WordSynonymLabel_Click(object sender, EventArgs e) { }

        private void L_ListSearchLabel_Click(object sender, EventArgs e) { }

        private void L_ListSearch_TextChanged(object sender, EventArgs e) 
        {
            if (L_ListSearch.Text != "")
            {
                R_ButtonAdd.Enabled = false;
                R_ButtonAdd.BackColor = Color.LightSlateGray;

                L_ButtonDeleteString.Enabled = false;
                L_ButtonDeleteString.BackColor = Color.LightSlateGray;

                L_ButtonDeserialize.Enabled = false;
                L_ButtonDeserialize.BackColor = Color.LightSlateGray;

                L_ButtonSerialize.Enabled = false;
                L_ButtonSerialize.BackColor = Color.LightSlateGray;

                for (int quantity = L_List.Items.Count - 1; quantity >= 0; quantity--)
                {
                    var dicwords = L_List.Items[quantity];

                    if (dicwords.Text.ToLower().Contains(L_ListSearch.Text.ToLower()))
                    {
                        dicwords.ForeColor = SystemColors.WindowText;
                    }

                    else
                    {
                        L_List.Items.Remove(dicwords);
                    }
                }
            }

            else
            {
                R_ButtonAdd.Enabled = true;
                R_ButtonAdd.BackColor = Color.RoyalBlue;

                L_ButtonDeleteString.Enabled = true;
                L_ButtonDeleteString.BackColor = Color.OrangeRed;

                L_ButtonDeserialize.Enabled = true;
                L_ButtonDeserialize.BackColor = Color.Gainsboro;

                L_ButtonSerialize.Enabled = true;
                L_ButtonSerialize.BackColor = Color.Gainsboro;

                ToDeserialize();
            }
        }
    }
}