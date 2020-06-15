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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBinarySerialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Car> cars;
        public MainWindow()
        {
            InitializeComponent();
            //Initialization();
            cars = new List<Car>();
            carsGrid.ItemsSource = cars;
        }

        private void Initialization()
        {
            Car car1 = new Car();
            Car car2 = new Car();
            Car car3 = new Car();

            Owner owner1 = new Owner();
            Owner owner2 = new Owner();
            Owner owner3 = new Owner();

            owner1.FirstName = "aa";
            owner1.LastName = "bb";
            car1.Owner = owner1;
            car1.Make = "Chevrolet";
            car1.Model = "Aveo";
            car1.Year = 2005;

            owner2.FirstName = "xx";
            owner2.LastName = "yy";
            car2.Owner = owner2;
            car2.Make = "Ford";
            car2.Model = "Focus";
            car2.Year = 2006;

            owner3.FirstName = "xyz";
            owner3.LastName = "abc";
            car3.Owner = owner3;
            car3.Make = "Dacia";
            car3.Model = "Duster";
            car3.Year = 2011;

            cars = new List<Car>();
            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
        }

        public void testSerialize()
        {
            ObjectToSerialize objectToSerialize = new ObjectToSerialize();
            objectToSerialize.Cars = cars;
            Serializer serializer = new Serializer();
            serializer.SerializeObject("outputFile.txt", objectToSerialize);
            MessageBox.Show("Serializarea a reusit cu succes!");
        }
        public void testDeserialize()
        {
            Serializer serializer = new Serializer();
            ObjectToSerialize objectToSerialize = serializer.DeserializeObject("outputFile.txt");
            cars = objectToSerialize.Cars;
        }

        private void btnSerialize_Click(object sender, RoutedEventArgs e)
        {
            testSerialize();
        }

        private void btnDeserialize_Click(object sender, RoutedEventArgs e)
        {
            testDeserialize();
            carsGrid.ItemsSource = cars;
        } 
    }
}
