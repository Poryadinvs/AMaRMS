namespace AMaRMS;

public partial class CompletedWorkPage : ContentPage
{
    public CompletedWorkPage()
    {
        InitializeComponent();
        LoadMaintenanceRecords();
    }

    async void LoadMaintenanceRecords()
    {
        var recordList = await App.Database.GetAllMaintenanceRecordsAsync();
        MaintenanceRecordList.ItemsSource = recordList;
    }

    void AddNewRecord_Clicked(object sender, EventArgs e)
    {
        AddFrame.IsVisible = true;
    }

    async void AddRecord_Clicked(object sender, EventArgs e)
    {
        var record = new MaintenanceRecord
        {
            EquipmentId = int.Parse(EquipmentIdEntry.Text),
            MaintenanceDate = DateTime.Parse(MaintenanceDateEntry.Text),
            MaintenanceType = MaintenanceTypeEntry.Text,
            Description = DescriptionEntry.Text,
            DurationHours = int.Parse(DurationHoursEntry.Text),
            Cost = double.Parse(CostEntry.Text),
            PerformedBy = PerformedByEntry.Text
        };

        await App.Database.SaveMaintenanceRecordAsync(record);
        AddFrame.IsVisible = false;
        LoadMaintenanceRecords();
    }

    void DeleteRecord_Clicked(object sender, EventArgs e)
    {
        DeleteFrame.IsVisible = true;
    }

    async void DeleteRecordButton_Clicked(object sender, EventArgs e)
    {
        int equipmentId = int.Parse(EquipmentIdForDelete.Text);
        DateTime date = DateTime.Parse(MaintenanceDateForDelete.Text);

        var record = (await App.Database.GetAllMaintenanceRecordsAsync()).FirstOrDefault(r => r.EquipmentId == equipmentId && r.MaintenanceDate == date);
        if (record != null)
        {
            await App.Database.DeleteMaintenanceRecordAsync(record);
            LoadMaintenanceRecords();
        }
        DeleteFrame.IsVisible = false;
    }
}
