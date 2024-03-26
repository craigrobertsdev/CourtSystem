using CourtSystem.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net.Http.Json;
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

    private void HandleNewCourtListClick(object sender, RoutedEventArgs e) {
        popup.IsOpen = true;
    }

    private void HandleOpenPreviousCourtListClick(object sender, RoutedEventArgs e) {

    }

    private async void save_btn_Click(object sender, RoutedEventArgs e) {
        var client = new HttpClient();
        var response = await client.PostAsJsonAsync("https://localhost:7150/test", txtBox.Text);
    }

    private void close_btn_Click(object sender, RoutedEventArgs e) {
        popup.IsOpen = false;
    }
}