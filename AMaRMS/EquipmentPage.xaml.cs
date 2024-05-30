namespace AMaRMS;

public partial class EquipmentPage : ContentPage
{
    public EquipmentPage()
    {
        InitializeComponent();
        LoadEquipment();
    }

    async void LoadEquipment()
    {
        var equipmentList = await App.Database.GetAllEquipmentAsync();
        EquipmentList.ItemsSource = equipmentList;
    }

    void AddNewEquipment_Clicked(object sender, EventArgs e)
    {
        AddFrame.IsVisible = true;
    }

    async void AddEquipment_Clicked(object sender, EventArgs e)
    {
        var equipment = new Equipment
        {
            Name = NameEntry.Text,
            Description = DescriptionEntry.Text,
            SerialNumber = SerialNumberEntry.Text,
            Location = LocationEntry.Text,
            InstallationDate = DateTime.Parse(InstallationDateEntry.Text)
        };

        await App.Database.SaveEquipmentAsync(equipment);
        AddFrame.IsVisible = false;
        LoadEquipment();
    }

    void DeleteEquipment_Clicked(object sender, EventArgs e)
    {
        DeleteFrame.IsVisible = true;
    }

    async void DeleteEquipmentButton_Clicked(object sender, EventArgs e)
    {
        var name = NameForDelete.Text;
        var serialNumber = SerialNumberForDelete.Text;

        var equipment = (await App.Database.GetAllEquipmentAsync()).FirstOrDefault(e => e.Name == name && e.SerialNumber == serialNumber);
        if (equipment != null)
        {
            await App.Database.DeleteEquipmentAsync(equipment);
            LoadEquipment();
        }
        DeleteFrame.IsVisible = false;
    }
}
