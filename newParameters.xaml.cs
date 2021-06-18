using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kurs
{
    /// <summary>
    /// Логика взаимодействия для newParameters.xaml
    /// </summary>
    public partial class newParameters : Window
    {
        public bool buttonPressed = false;
        public newParameters()
        {
            InitializeComponent();
        }
        private void newParam_Click(object sender, RoutedEventArgs e)
        {
            buttonPressed = true;
            Baloon.volume = Convert.ToDouble(volData.Content);
            Baloon.heater = Convert.ToDouble(heatData.Content);
            Baloon.weight = Convert.ToDouble(weigData.Content);
            this.Close();
        }
        private void sliderVolume_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            Baloon.volume = Math.Round(sliderVolume.Value, 2);
            volData.Content = Baloon.volume.ToString();
        }
        private void sliderHeater_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            Baloon.heater = Math.Round(sliderHeater.Value, 2);
            heatData.Content = Baloon.heater.ToString();
        }
        private void sliderWeight_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            Baloon.weight = Math.Round(sliderWeight.Value, 2);
            weigData.Content = Baloon.weight.ToString();
        }
    }
}
