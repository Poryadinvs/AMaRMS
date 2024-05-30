namespace AMaRMS;

public partial class Registrationpage : ContentPage
{
    public Registrationpage()
    {
        InitializeComponent();
    }

    async void Registration_Clicked(object sender, EventArgs e)
    {
        string name = NameEntry.Text;
        string lastName = LastNameEntry.Text;
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;

        if (password != confirmPassword)
        {
            await DisplayAlert("Ошибка", "Пароли не совпадают", "OK");
            return;
        }

        var user = new User
        {
            Name = name,
            LastName = lastName,
            Email = email,
            Password = password
        };

        await App.Database.SaveUserAsync(user);
        await DisplayAlert("Успех", "Регистрация завершена", "OK");
        await Navigation.PushAsync(new LoginPage());
    }

    async void Entry_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new LoginPage());
    }
}
