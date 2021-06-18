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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kurs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public System.Windows.Threading.DispatcherTimer animationTimer = new System.Windows.Threading.DispatcherTimer();
        public System.Windows.Threading.DispatcherTimer heightTimer = new System.Windows.Threading.DispatcherTimer();

        int tick = 0; int height = 0; double velocity = 0; int maxHeight = 10000;

        public Baloon theBaloon = new Baloon();
        public Baloon defaultBaloon = new Baloon((Baloon.maxVolume + Baloon.minVolume) / 2,
                                                 (Baloon.maxHeater + Baloon.minHeater) / 2,
                                                 (Baloon.maxWeight + Baloon.minWeight) / 2);
        bool started = false;
        bool data = false;
        int count = 0;
        double duration = 0; double time = 0;
        readonly double begin = 0.3;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (data == true)
            {
                
                started = true;
                height = 0;
                heightLabel.Content = height.ToString();
                double R = Math.Pow(3 * theBaloon._volume / (4 * Math.PI), (double)1 / 3);
                double M = 8 * Math.PI * Math.Pow(R, 4) / 3 + theBaloon._weight;
                double Mh = 0.17 * theBaloon._volume;
                double Ma = theBaloon._heater;
                double multiplier1 = 8 * 9.81 * R / (3 * 0.14);
                double multiplier2 = 1 - ((M / 10 + 0.77 * Ma + Mh) / (Ma * 100));
                duration = Math.Sqrt(multiplier1 / multiplier2) - (Math.Round(heaterRegulator.Value, 2) / 250);
                time = duration;
                velocity = Math.Round(120 - duration, 2);
                count = maxHeight / (int)velocity - 80;
                tick = maxHeight / (count * (int)duration / 3);
                velocityLabel.Content = tick.ToString();
                borderAnimation(Ground, duration, begin);
                borderAnimation(CloudsBorder, duration, begin);
                borderAnimation(CloudsBorder_2, duration, begin);
                borderAnimation(CloudsBorder_3, duration, begin);
                borderAnimation(CloudsBorder_4, duration, begin);
                animTimer(sender, e);
            }
            else
            {
                MessageBox.Show("Установите параметры шара");
                newParameters win = new newParameters();
                win.ShowDialog();
                if (win.buttonPressed == true)
                {
                    win.buttonPressed = false;
                    data = true;
                    started = true;
                    theBaloon = new Baloon(Baloon.volume, Baloon.heater, Baloon.weight);
                    heaterRegulator.Value = Baloon.heater;
                    volumeLabel.Content = theBaloon._volume.ToString();
                    heaterLabel.Content = theBaloon._heater.ToString();
                    weightLabel.Content = theBaloon._weight.ToString();
                    height = 0;
                    heightLabel.Content = height.ToString();
                    double R = Math.Pow(3 * theBaloon._volume / (4 * Math.PI), (double)1 / 3);
                    double M = 8 * Math.PI * Math.Pow(R, 4) / 3 + theBaloon._weight;
                    double Mh = 0.17 * theBaloon._volume;
                    double Ma = theBaloon._heater;
                    double multiplier1 = 8 * 9.81 * R / (3 * 0.14);
                    double multiplier2 = 1 - ((M / 10 + 0.77 * Ma + Mh) / (Ma * 100));
                    duration = Math.Sqrt(multiplier1 / multiplier2) - (Math.Round(heaterRegulator.Value, 2) / 250);
                    time = duration;
                    velocity = Math.Round(120 - duration, 2);
                    count = maxHeight / (int)velocity - 80;
                    tick = maxHeight / (count * (int)duration / 3);
                    velocityLabel.Content = tick.ToString();
                    borderAnimation(Ground, duration, begin);
                    borderAnimation(CloudsBorder, duration, begin);
                    borderAnimation(CloudsBorder_2, duration, begin);
                    borderAnimation(CloudsBorder_3, duration, begin);
                    borderAnimation(CloudsBorder_4, duration, begin);
                    animTimer(sender, e);
                }
                else
                    MessageBox.Show("Вы не ввели данные");
            }
        }
        private void setParameters_Click(object sender, RoutedEventArgs e)
        {
            stopAnimation(Ground);
            stopAnimation(CloudsBorder);
            stopAnimation(CloudsBorder_2);
            stopAnimation(CloudsBorder_3);
            stopAnimation(CloudsBorder_4);
            animationTimer.Stop();
            heightTimer.Stop();
            newParameters win = new newParameters();
            win.ShowDialog();
            if (win.buttonPressed == true)
            {
                win.buttonPressed = false;
                data = true;
                theBaloon = new Baloon(Baloon.volume, Baloon.heater, Baloon.weight);
                heaterRegulator.Value = theBaloon._heater;
                volumeLabel.Content = theBaloon._volume.ToString();
                heaterLabel.Content = theBaloon._heater.ToString();
                weightLabel.Content = theBaloon._weight.ToString();
                velocity = 0;
                velocityLabel.Content = velocity.ToString();
                height = 0;
                heightLabel.Content = height.ToString();
            }
            else
                MessageBox.Show("Вы не ввели данные");
        }
        private void resetParameters_Click(object sender, RoutedEventArgs e)
        {
            stopAnimation(Ground);
            stopAnimation(CloudsBorder);
            stopAnimation(CloudsBorder_2);
            stopAnimation(CloudsBorder_3);
            stopAnimation(CloudsBorder_4);
            animationTimer.Stop();
            heightTimer.Stop();
            data = true;
            theBaloon = (Baloon)defaultBaloon.Clone();
            heaterRegulator.Value = theBaloon._heater;
            volumeLabel.Content = theBaloon._volume.ToString();
            heaterLabel.Content = theBaloon._heater.ToString();
            weightLabel.Content = theBaloon._weight.ToString();
            velocity = 0;
            velocityLabel.Content = velocity.ToString();
            height = 0;
            heightLabel.Content = height.ToString();
        }
        private void heaterRegulator_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            Heater.Opacity = heaterRegulator.Value / Baloon.maxHeater - 0.2;
            Baloon.heater = Math.Round(heaterRegulator.Value, 2);
            theBaloon = new Baloon(theBaloon._volume, Baloon.heater, theBaloon._weight);
            heaterLabel.Content = theBaloon._heater.ToString();
            if (started == true)
            {
                double R = Math.Pow(3 * theBaloon._volume / (4 * Math.PI), (double)1 / 3);
                double M = 8 * Math.PI * Math.Pow(R, 4) / 3 + theBaloon._weight;
                double Mh = 0.17 * theBaloon._volume;
                double Ma = theBaloon._heater;
                double multiplier1 = 8 * 9.81 * R / (3 * 0.14);
                double multiplier2 = 1 - ((M / 10 + 0.77 * Ma + Mh) / (Ma * 100));
                duration = Math.Sqrt(multiplier1 / multiplier2) - (Math.Round(heaterRegulator.Value, 2) / 250);
                velocity = Math.Round(120 - duration, 2);
                count = maxHeight / (int)velocity - 80;
                tick = maxHeight / (count * (int)duration / 3);
                velocityLabel.Content = tick.ToString();
                borderAnimation(CloudsBorder, duration, begin);
                borderAnimation(CloudsBorder_2, duration, begin);
                borderAnimation(CloudsBorder_3, duration, begin);
                borderAnimation(CloudsBorder_4, duration, begin);
            }
        }
        private void borderAnimation(Border border, double duration, double begin)
        {
            border.RenderTransform = new TranslateTransform();
            if (border != Ground)
            {
                var translateY = new DoubleAnimation
                {
                    From = border.Margin.Bottom,
                    To = ((Grid)border.Parent).ActualHeight + border.Height + border.Margin.Top + 1000,
                    Duration = TimeSpan.FromSeconds(duration),
                    BeginTime = TimeSpan.FromSeconds(begin),
                    RepeatBehavior = new RepeatBehavior(TimeSpan.FromSeconds(count*time/3)),
                };
                ((TranslateTransform)border.RenderTransform).BeginAnimation(TranslateTransform.YProperty, translateY);
            }
            else
            {
                var translateY = new DoubleAnimation
                {
                    From = border.Margin.Bottom,
                    To = ((Grid)border.Parent).ActualHeight + border.Height + border.Margin.Top + 500,
                    Duration = TimeSpan.FromSeconds(duration),
                    BeginTime = TimeSpan.FromSeconds(begin),
                };
                ((TranslateTransform)border.RenderTransform).BeginAnimation(TranslateTransform.YProperty, translateY);
            } 
        }
        private void stopAnimation(Border border)
        {
            border.RenderTransform = new TranslateTransform();
            var translateY = new DoubleAnimation
            {
                From = border.Margin.Bottom,
                To = border.Margin.Bottom,
                BeginTime = null,
            };
            ((TranslateTransform)border.RenderTransform).BeginAnimation(TranslateTransform.YProperty, translateY); 
        }
        private void animTimer(object sender, RoutedEventArgs e)
        {
            animationTimer.Tick += new EventHandler(timerTick);
            animationTimer.Interval = TimeSpan.FromSeconds((count * (int)duration) / 3 + 1);
            heightTimer.Tick += new EventHandler(heightTick);
            heightTimer.Interval = TimeSpan.FromSeconds(1);

            animationTimer.Start();
            heightTimer.Start();
        }
        private void timerTick(object sender, EventArgs e)
        {
            stopAnimation(Ground);
            stopAnimation(CloudsBorder);
            stopAnimation(CloudsBorder_2);
            stopAnimation(CloudsBorder_3);
            stopAnimation(CloudsBorder_4);
            heightTimer.Stop();
            heightLabel.Content = "10000";
            MessageBox.Show("Шар достиг высоты 10 километров");
        }
        private void heightTick(object sender, EventArgs e)
        {
            height += tick;
            heightLabel.Content = height.ToString();
        }
    }
}