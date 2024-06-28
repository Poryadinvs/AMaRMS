using Microsoft.Extensions.Logging.Abstractions;

namespace AMaRMS;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        LoadData();
    }

    private async void LoadData()
    {
        var users = await App.Database.GetUsersAsync();
        var managers = await App.Database.GetManagersAsync();

        TestUser.ItemsSource = users;
        TestManager.ItemsSource = managers;
    }

    async void Entry_Clicked(object sender, EventArgs e)
    {
        string login = EmailEntry.Text;
        string password = PasswordEntry.Text;


        var result = await CheckCredentials(login, password);

        if (result == "User")
        {
            await DisplayAlert("Success", "User found", "OK");
            await Navigation.PushModalAsync(new WorkOrdersPage());
        }
        else if (result == "Manager")
        {
            await DisplayAlert("Success", "Manager found", "OK");
            await Navigation.PushModalAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Ошибка", "Логин или пароль не совпадают", "ОК");
        }
    }

    private async Task<string> CheckCredentials(string login, string password)
    {
        var user = await App.Database.GetUserAsync(login, password);
        if (user != null)
        {
            return "User";
        }

        var manager = await App.Database.GetManagerAsync(login, password);
        if (manager != null)
        {
            return "Manager";
        }

        return null;
    }

    async void Registration_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Registrationpage());
    }
}