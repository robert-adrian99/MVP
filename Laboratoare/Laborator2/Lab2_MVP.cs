// Data binding

// Putem sincroniza elementele de UI

{Binding ElementName=MySlider, Path=Value, Mode=OneWay}

// Tipuri de Mode:
// - OneWay             source->target
// - TwoWay             source<->target
// - OneWayToSource     source<-target
// - OneTime            se intampla o singura data


// XAML

<Window x:Class="Laborator1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:Laborator1"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
        <Grid>

        </Grid>
</Window>

xmlns - namespace
xmlns:x - namespace

// Putem defini noi namespace-uri

xmlns:local

local:Name - va cauta in namespace-ul xmlns:local

// App.xaml

<Application ....
    StartupUri="MainWindow.xaml"> - fereastra care se deschide prima
    ...

{StaticResource ComboBoxTtile}              - resursa statica; nu se modifica

{DynamicResource WindowBackgroundBrush}     - resursa dinamica; se atualizeaza



namespace WpfSimpleControls
{
    class User
    {
        public User()
        {
            Username = "ana";
            Password = "123";
        }
        public string Username { get; set; }
        public string Password { get; set; }

        // Trebuie getters si setters expliciti cu NotifyPropertyChanged()

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }
    }
}

<TextBox Text={Binding Username}>   // {Binding="Username"}
<TextBox Text={Binding Password}/>


|-------------------------------|
|            |---------------|  |
|   Username |_______________|  |
|                               |
|                               |
|            |_______________|  |
|   Password |_______________|  |
|                               |
|-------------------------------|

<Window ...
    xmlns:local="clr-namespace:WpfSimpleControl">
    <Window.DataContext>
        <local:User/>
    </Window.DataContext>
</Window>