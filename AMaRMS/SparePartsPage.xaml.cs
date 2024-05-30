namespace AMaRMS;

public partial class SparePartsPage : ContentPage
{
    public SparePartsPage()
    {
        InitializeComponent();
        LoadSpareParts();
    }

    async void LoadSpareParts()
    {
        var sparePartsList = await App.Database.GetAllSparePartsAsync();
        SparePartsList.ItemsSource = sparePartsList;
    }

    void AddNewPart_Clicked(object sender, EventArgs e)
    {
        AddFrame.IsVisible = true;
    }

    async void AddPartButton_Clicked(object sender, EventArgs e)
    {
        var sparePart = new SpareParts
        {
            PartName = PartNameEntry.Text,
            PartNumber = PartNumberEntry.Text,
            Description = DescriptionEntry.Text,
            Quantity = int.Parse(QuantityEntry.Text),
            Location = LocationEntry.Text
        };

        await App.Database.SaveSparePartAsync(sparePart);
        AddFrame.IsVisible = false;
        LoadSpareParts();
    }

    void DeletePart_Clicked(object sender, EventArgs e)
    {
        DeleteFrame.IsVisible = true;
    }

    async void DeletePartButton_Clicked(object sender, EventArgs e)
    {
        var partName = PartNameForDelete.Text;
        var partNumber = PartNumberForDelete.Text;

        var part = (await App.Database.GetAllSparePartsAsync()).FirstOrDefault(p => p.PartName == partName && p.PartNumber == partNumber);
        if (part != null)
        {
            await App.Database.DeleteSparePartAsync(part);
            LoadSpareParts();
        }
        DeleteFrame.IsVisible = false;
    }

    void AddQuantity_Clicked(object sender, EventArgs e)
    {
        AddQuantityFrame.IsVisible = true;
    }

    async void AddQuantityButton_Clicked(object sender, EventArgs e)
    {
        var partName = PartNameForQuantity.Text;
        var partNumber = PartNumberForQuantity.Text;
        var quantityToAdd = int.Parse(QuantityForAdd.Text);

        var part = (await App.Database.GetAllSparePartsAsync()).FirstOrDefault(p => p.PartName == partName && p.PartNumber == partNumber);
        if (part != null)
        {
            part.Quantity += quantityToAdd;
            await App.Database.UpdateSparePartAsync(part);
            LoadSpareParts();
        }
        AddQuantityFrame.IsVisible = false;
    }
}
