using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesaurusDictionary
{
    [Serializable]
    public class Words
    {
        public List<Word> WordsList { get; set; } = new List<Word>();

        public Words() { }
    }

    [Serializable]
    public class Word
    {
        public string WordName { get; set; }
        public string WordPhonetics { get; set; }
        public int WordType { get; set; }
        public int WordSoul { get; set; }
        public int WordGen { get; set; }
        public string WordMeaning { get; set; }
        public string WordSynonym { get; set; }
        public string WordAntonym { get; set; }
        public string WordHyperonym { get; set; }
        public string WordHyponym { get; set; }
        public string WordExample { get; set; }

        public Word() { }

        public Word(string WordName, string WordPhonetics, int WordType, int WordSoul, int WordGen, string WordMeaning, string WordSynonym, string WordAntonym, string WordHyperonym, string WordHyponym, string WordExample)
        {
            this.WordName = WordName;
            this.WordPhonetics = WordPhonetics;
            this.WordType = WordType;
            this.WordSoul = WordSoul;
            this.WordGen = WordGen;
            this.WordMeaning = WordMeaning;
            this.WordSynonym = WordSynonym;
            this.WordAntonym = WordAntonym;
            this.WordHyperonym = WordHyperonym;
            this.WordHyponym = WordHyponym;
            this.WordExample = WordExample;
        }
    }
}
