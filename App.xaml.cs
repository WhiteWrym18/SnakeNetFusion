using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SnakeNetMaui;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new MainPage();
    }
}
