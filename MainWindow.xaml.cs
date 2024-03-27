using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CourtSystem;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddWpfBlazorWebView();
        serviceCollection.AddBlazorWebViewDeveloperTools();
        Resources.Add("services", serviceCollection.BuildServiceProvider());
    }
}