namespace AMaRMS;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    async void Entry_Clicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        var user = await App.Database.GetUserByEmailAndPasswordAsync(email, password);

        if (user != null)
        {
            await Navigation.PushModalAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Ошибка", "Неверный логин или пароль", "OK");
        }
    }

    async void Registration_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Registrationpage());
    }
}
