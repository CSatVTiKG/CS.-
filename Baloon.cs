using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs
{
    public class Baloon : ICloneable
    { 
        public double _volume;
        public static double volume;
        public static double minVolume = 650;
        public static double maxVolume = 5950;

        public double _heater;
        public static double heater;
        public static double minHeater = 4000;
        public static double maxHeater = 6000;

        public double _weight;
        public static double weight;
        public static double minWeight = 55;
        public static double maxWeight = 85;

        public Baloon()
        {
        }
        public Baloon(double volume, double heater, double weight)
        {
            this._volume = volume;
            this._heater = heater;
            this._weight = weight;
        }
        public object Clone()
        {
            Baloon baloonClone = new Baloon();
            baloonClone._volume = this._volume;
            baloonClone._heater = this._heater;
            baloonClone._weight = this._weight;
            return baloonClone;
        }
    }
}
