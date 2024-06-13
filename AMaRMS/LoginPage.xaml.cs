using Microsoft.Extensions.Logging.Abstractions;

namespace AMaRMS;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    async void Entry_Clicked(object sender, EventArgs e)
    {
        string login = EmailEntry.Text;
        string password = PasswordEntry.Text;

        var user = await App.Database.GetUserAsync(login, password);
        var manager = await App.Database.GetManagerAsync(login, password);

        if (user != null)
        {
            await Navigation.PushAsync(new WorkOrdersPage());
        }
        else if (manager != null)
        {
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Ошибка", "Логин или пароль не совпадают", "ОК");
        }
    }

    async void Registration_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Registrationpage());
    }
}
