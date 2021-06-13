using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PoEInfoRole
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HideAll();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            ToDeserialize();
            InvisiblePassiveButton();
        }

        private void HideAll()
        {
            juggernaut.Visible = false;
            berserker.Visible = false;
            chieftain.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;
            button20.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            justBox.Visible = false;
            InvisiblePassiveButton();
        }

        private void InvisiblePassiveButton()
        {
            passive.Visible = false;
            button25.Visible = false;
            button26.Visible = false;
            button27.Visible = false;
            button28.Visible = false;
            button29.Visible = false;
            button30.Visible = false;
            button31.Visible = false;
            button32.Visible = false;
            button33.Visible = false;
            button34.Visible = false;
            button35.Visible = false;
            button36.Visible = false;
            button37.Visible = false;
            button38.Visible = false;
            button39.Visible = false;
            button40.Visible = false;
            button41.Visible = false;
            button42.Visible = false;
        }

        private Characher XMLDeserialize()
        {

            XmlSerializer xml = new XmlSerializer(typeof(Characher));

            using (FileStream fstr = new FileStream("XMLFile1.xml", FileMode.OpenOrCreate))

            {
                Characher characher = (Characher)xml.Deserialize(fstr);
                return characher;
            }

        }

        private void ToDeserialize()
        {
            Characher characher = XMLDeserialize();
        }

            #region Главные кнопки
            private void button1_Click(object sender, EventArgs e)
        {
            HideAll();
            label8.Visible = true;
            juggernaut.Visible = true;
            berserker.Visible = true;
            chieftain.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            HideAll();
            label8.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HideAll();
            label8.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HideAll();
            label8.Visible = true;
            button16.Visible = true;
            button17.Visible = true;
            button18.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HideAll();
            label8.Visible = true;
            button19.Visible = true;
            button20.Visible = true;
            button21.Visible = true;
            label21.Visible = true;
            label22.Visible = true;
            label23.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HideAll();
            label8.Visible = true;
            button22.Visible = true;
            button23.Visible = true;
            button24.Visible = true;
            label24.Visible = true;
            label25.Visible = true;
            label26.Visible = true;
        }

        #endregion

        private void button7_Click(object sender, EventArgs e)
        {
            justBox.Visible = true; 
            InvisiblePassiveButton();
            passive.Visible = true;
            button25.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[0].Name.ToString();
            SpecializationL.Text = characher.CharacherList[0].Spec.ToString();
            WeaponL.Text = characher.CharacherList[0].Weapon.ToString();
            DamageL.Text = characher.CharacherList[0].Damage.ToString();
            DefenceL.Text = characher.CharacherList[0].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[0].Actually.ToString();
            forbegT.Text = characher.CharacherList[0].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[0].Quote.ToString();
            Overview.Text = characher.CharacherList[0].Overview.ToString();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            justBox.Visible = true;
            InvisiblePassiveButton();
            passive.Visible = true;
            button26.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[1].Name.ToString();
            SpecializationL.Text = characher.CharacherList[1].Spec.ToString();
            WeaponL.Text = characher.CharacherList[1].Weapon.ToString();
            DamageL.Text = characher.CharacherList[1].Damage.ToString();
            DefenceL.Text = characher.CharacherList[1].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[1].Actually.ToString();
            forbegT.Text = characher.CharacherList[1].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[1].Quote.ToString();
            Overview.Text = characher.CharacherList[1].Overview.ToString();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            justBox.Visible = true;
            InvisiblePassiveButton();
            passive.Visible = true;
            button27.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[2].Name.ToString();
            SpecializationL.Text = characher.CharacherList[2].Spec.ToString();
            WeaponL.Text = characher.CharacherList[2].Weapon.ToString();
            DamageL.Text = characher.CharacherList[2].Damage.ToString();
            DefenceL.Text = characher.CharacherList[2].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[2].Actually.ToString();
            forbegT.Text = characher.CharacherList[2].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[2].Quote.ToString();
            Overview.Text = characher.CharacherList[2].Overview.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            justBox.Visible = true;
            InvisiblePassiveButton();
            passive.Visible = true;
            button28.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[3].Name.ToString();
            SpecializationL.Text = characher.CharacherList[3].Spec.ToString();
            WeaponL.Text = characher.CharacherList[3].Weapon.ToString();
            DamageL.Text = characher.CharacherList[3].Damage.ToString();
            DefenceL.Text = characher.CharacherList[3].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[3].Actually.ToString();
            forbegT.Text = characher.CharacherList[3].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[3].Quote.ToString();
            Overview.Text = characher.CharacherList[3].Overview.ToString();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            justBox.Visible = true;
            InvisiblePassiveButton();
            passive.Visible = true;
            button29.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[4].Name.ToString();
            SpecializationL.Text = characher.CharacherList[4].Spec.ToString();
            WeaponL.Text = characher.CharacherList[4].Weapon.ToString();
            DamageL.Text = characher.CharacherList[4].Damage.ToString();
            DefenceL.Text = characher.CharacherList[4].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[4].Actually.ToString();
            forbegT.Text = characher.CharacherList[4].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[4].Quote.ToString();
            Overview.Text = characher.CharacherList[4].Overview.ToString();
        }        
        private void button12_Click(object sender, EventArgs e)
        {
            justBox.Visible = true;
            InvisiblePassiveButton();
            passive.Visible = true;
            button30.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[5].Name.ToString();
            SpecializationL.Text = characher.CharacherList[5].Spec.ToString();
            WeaponL.Text = characher.CharacherList[5].Weapon.ToString();
            DamageL.Text = characher.CharacherList[5].Damage.ToString();
            DefenceL.Text = characher.CharacherList[5].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[5].Actually.ToString();
            forbegT.Text = characher.CharacherList[5].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[5].Quote.ToString();
            Overview.Text = characher.CharacherList[5].Overview.ToString();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            justBox.Visible = true;
            InvisiblePassiveButton();
            passive.Visible = true;
            button31.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[6].Name.ToString();
            SpecializationL.Text = characher.CharacherList[6].Spec.ToString();
            WeaponL.Text = characher.CharacherList[6].Weapon.ToString();
            DamageL.Text = characher.CharacherList[6].Damage.ToString();
            DefenceL.Text = characher.CharacherList[6].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[6].Actually.ToString();
            forbegT.Text = characher.CharacherList[6].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[6].Quote.ToString();
            Overview.Text = characher.CharacherList[6].Overview.ToString();
        }
        private void button14_Click(object sender, EventArgs e)
        {
            justBox.Visible = true;
            InvisiblePassiveButton();
            passive.Visible = true;
            button32.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[7].Name.ToString();
            SpecializationL.Text = characher.CharacherList[7].Spec.ToString();
            WeaponL.Text = characher.CharacherList[7].Weapon.ToString();
            DamageL.Text = characher.CharacherList[7].Damage.ToString();
            DefenceL.Text = characher.CharacherList[7].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[7].Actually.ToString();
            forbegT.Text = characher.CharacherList[7].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[7].Quote.ToString();
            Overview.Text = characher.CharacherList[7].Overview.ToString();
        }        
        private void button15_Click(object sender, EventArgs e)
        {
            justBox.Visible = true;
            InvisiblePassiveButton();
            passive.Visible = true;
            button33.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[8].Name.ToString();
            SpecializationL.Text = characher.CharacherList[8].Spec.ToString();
            WeaponL.Text = characher.CharacherList[8].Weapon.ToString();
            DamageL.Text = characher.CharacherList[8].Damage.ToString();
            DefenceL.Text = characher.CharacherList[8].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[8].Actually.ToString();
            forbegT.Text = characher.CharacherList[8].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[8].Quote.ToString();
            Overview.Text = characher.CharacherList[8].Overview.ToString();
        }
        private void button16_Click(object sender, EventArgs e)
        {
            justBox.Visible = true;
            InvisiblePassiveButton();
            passive.Visible = true;
            button34.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[9].Name.ToString();
            SpecializationL.Text = characher.CharacherList[9].Spec.ToString();
            WeaponL.Text = characher.CharacherList[9].Weapon.ToString();
            DamageL.Text = characher.CharacherList[9].Damage.ToString();
            DefenceL.Text = characher.CharacherList[9].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[9].Actually.ToString();
            forbegT.Text = characher.CharacherList[9].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[9].Quote.ToString();
            Overview.Text = characher.CharacherList[9].Overview.ToString();
        }
        private void button17_Click(object sender, EventArgs e)
        {
            justBox.Visible = true;
            InvisiblePassiveButton();
            passive.Visible = true;
            button35.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[10].Name.ToString();
            SpecializationL.Text = characher.CharacherList[10].Spec.ToString();
            WeaponL.Text = characher.CharacherList[10].Weapon.ToString();
            DamageL.Text = characher.CharacherList[10].Damage.ToString();
            DefenceL.Text = characher.CharacherList[10].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[10].Actually.ToString();
            forbegT.Text = characher.CharacherList[10].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[10].Quote.ToString();
            Overview.Text = characher.CharacherList[10].Overview.ToString();
        }        
        private void button18_Click(object sender, EventArgs e)
        {
            justBox.Visible = true;
            InvisiblePassiveButton();
            passive.Visible = true;
            button36.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[11].Name.ToString();
            SpecializationL.Text = characher.CharacherList[11].Spec.ToString();
            WeaponL.Text = characher.CharacherList[11].Weapon.ToString();
            DamageL.Text = characher.CharacherList[11].Damage.ToString();
            DefenceL.Text = characher.CharacherList[11].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[11].Actually.ToString();
            forbegT.Text = characher.CharacherList[11].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[11].Quote.ToString();
            Overview.Text = characher.CharacherList[11].Overview.ToString();
        }
        private void button19_Click(object sender, EventArgs e)
        {
            justBox.Visible = true;
            InvisiblePassiveButton();
            passive.Visible = true;
            button37.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[12].Name.ToString();
            SpecializationL.Text = characher.CharacherList[12].Spec.ToString();
            WeaponL.Text = characher.CharacherList[12].Weapon.ToString();
            DamageL.Text = characher.CharacherList[12].Damage.ToString();
            DefenceL.Text = characher.CharacherList[12].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[12].Actually.ToString();
            forbegT.Text = characher.CharacherList[12].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[12].Quote.ToString();
            Overview.Text = characher.CharacherList[12].Overview.ToString();
        }
        private void button20_Click(object sender, EventArgs e)
        {
            justBox.Visible = true;
            InvisiblePassiveButton();
            passive.Visible = true;
            button38.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[13].Name.ToString();
            SpecializationL.Text = characher.CharacherList[13].Spec.ToString();
            WeaponL.Text = characher.CharacherList[13].Weapon.ToString();
            DamageL.Text = characher.CharacherList[13].Damage.ToString();
            DefenceL.Text = characher.CharacherList[13].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[13].Actually.ToString();
            forbegT.Text = characher.CharacherList[13].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[13].Quote.ToString();
            Overview.Text = characher.CharacherList[13].Overview.ToString();
        }
        private void button21_Click(object sender, EventArgs e)
        {
            justBox.Visible = true;
            InvisiblePassiveButton();
            passive.Visible = true;
            button39.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[14].Name.ToString();
            SpecializationL.Text = characher.CharacherList[14].Spec.ToString();
            WeaponL.Text = characher.CharacherList[14].Weapon.ToString();
            DamageL.Text = characher.CharacherList[14].Damage.ToString();
            DefenceL.Text = characher.CharacherList[14].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[14].Actually.ToString();
            forbegT.Text = characher.CharacherList[14].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[14].Quote.ToString();
            Overview.Text = characher.CharacherList[14].Overview.ToString();
        }        
        private void button22_Click(object sender, EventArgs e)
        {
            justBox.Visible = true;
            InvisiblePassiveButton();
            passive.Visible = true;
            button40.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[15].Name.ToString();
            SpecializationL.Text = characher.CharacherList[15].Spec.ToString();
            WeaponL.Text = characher.CharacherList[15].Weapon.ToString();
            DamageL.Text = characher.CharacherList[15].Damage.ToString();
            DefenceL.Text = characher.CharacherList[15].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[15].Actually.ToString();
            forbegT.Text = characher.CharacherList[15].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[15].Quote.ToString();
            Overview.Text = characher.CharacherList[15].Overview.ToString();
        }        
        private void button23_Click(object sender, EventArgs e)
        {
            justBox.Visible = true;
            InvisiblePassiveButton();
            passive.Visible = true;
            button41.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[16].Name.ToString();
            SpecializationL.Text = characher.CharacherList[16].Spec.ToString();
            WeaponL.Text = characher.CharacherList[16].Weapon.ToString();
            DamageL.Text = characher.CharacherList[16].Damage.ToString();
            DefenceL.Text = characher.CharacherList[16].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[16].Actually.ToString();
            forbegT.Text = characher.CharacherList[16].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[16].Quote.ToString();
            Overview.Text = characher.CharacherList[16].Overview.ToString();
        }
        private void button24_Click(object sender, EventArgs e)
        {
            justBox.Visible = true;
            InvisiblePassiveButton();
            passive.Visible = true;
            button42.Visible = true;
            Characher characher = XMLDeserialize();
            NameL.Text = characher.CharacherList[17].Name.ToString();
            SpecializationL.Text = characher.CharacherList[17].Spec.ToString();
            WeaponL.Text = characher.CharacherList[17].Weapon.ToString();
            DamageL.Text = characher.CharacherList[17].Damage.ToString();
            DefenceL.Text = characher.CharacherList[17].Defence.ToString();
            ActuallyL.Text = characher.CharacherList[17].Actually.ToString();
            forbegT.Text = characher.CharacherList[17].ForBeginners.ToString();
            Quote.Text = characher.CharacherList[17].Quote.ToString();
            Overview.Text = characher.CharacherList[17].Overview.ToString();
        }

        private void button25_Click_1(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\7.PNG") { UseShellExecute = true });
        }
        private void button26_Click_1(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\8.PNG") { UseShellExecute = true });
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\9.PNG") { UseShellExecute = true });
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\3.PNG") { UseShellExecute = true });
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\2.PNG") { UseShellExecute = true });
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\1.PNG") { UseShellExecute = true });
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\15.PNG") { UseShellExecute = true });
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\14.PNG") { UseShellExecute = true });
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\13.PNG") { UseShellExecute = true });
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\6.PNG") { UseShellExecute = true });
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\5.PNG") { UseShellExecute = true });
        }

        private void button36_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\4.PNG") { UseShellExecute = true });
        }

        private void button37_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\11.PNG") { UseShellExecute = true });
        }

        private void button38_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\12.PNG") { UseShellExecute = true });
        }

        private void button39_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\10.PNG") { UseShellExecute = true });
        }

        private void button40_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\16.PNG") { UseShellExecute = true });
        }

        private void button41_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\17.PNG") { UseShellExecute = true });
        }

        private void button42_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"Image\18.PNG") { UseShellExecute = true });
        }

        private void обРазработчикеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Данное приложение реализовал студент группы БО921ПРИ Герасимов Л.О.");
        }

        private void обИгреToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Path of Exile (с англ. — «Путь изгнанника») — многопользовательская компьютерная игра в жанре Action/RPG, разработанная и выпущенная компанией Grinding Gear Games для Windows в 2013 году.");
        }

        private void выходИзПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }        
}
