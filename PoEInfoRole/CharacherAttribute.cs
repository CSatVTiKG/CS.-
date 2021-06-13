using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEInfoRole
{
    [Serializable]

    public class Characher
    {
        public List<CharacherAttribute> CharacherList { get; set; } = new List<CharacherAttribute>();

        public Characher() { }
    }
    
    [Serializable]
    public class CharacherAttribute
    {
        public string Name { get; set; }
        public string Spec { get; set; }
        public string Weapon { get; set; }
        public string Damage { get; set; }
        public string Defence { get; set; }
        public string Actually { get; set; }
        public string ForBeginners { get; set; }
        public string Quote { get; set; }
        public string PassiveSkills { get; set; }
        public string Overview { get; set; }

        public CharacherAttribute() { }

      
        public CharacherAttribute(string name, string spec, string weapon, string damage, string defence, string actually, string forbegginers, string quote, string passiveSkills, string overview)
        {
            Name = name;
            Spec = spec;
            Weapon = weapon;
            Damage = damage;
            Defence = defence;
            Actually = actually;
            ForBeginners = forbegginers;
            Quote = quote;
            PassiveSkills = passiveSkills;
            Overview = overview;
        }
    }
}
