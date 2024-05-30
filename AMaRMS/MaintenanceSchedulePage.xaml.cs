namespace AMaRMS;

public partial class MaintenanceSchedulePage : ContentPage
{
    public MaintenanceSchedulePage()
    {
        InitializeComponent();
        LoadMaintenanceSchedules();
    }

    async void LoadMaintenanceSchedules()
    {
        var scheduleList = await App.Database.GetAllMaintenanceSchedulesAsync();
        MaintenanceScheduleList.ItemsSource = scheduleList;
    }

    void AddMaintenanceSchedule_Clicked(object sender, EventArgs e)
    {
        AddFrame.IsVisible = true;
    }

    async void AddSchedule_Clicked(object sender, EventArgs e)
    {
        var schedule = new MaintenanceSchedule
        {
            EquipmentId = int.Parse(EquipmentIdEntry.Text),
            MaintenanceType = MaintenanceTypeEntry.Text,
            LastMaintenanceDate = DateTime.Parse(LastMaintenanceDateEntry.Text),
            NextMaintenanceDate = DateTime.Parse(NextMaintenanceDateEntry.Text),
            IsDone = false
        };

        await App.Database.SaveMaintenanceScheduleAsync(schedule);
        AddFrame.IsVisible = false;
        LoadMaintenanceSchedules();
    }

    void MarkAsDone_Clicked(object sender, EventArgs e)
    {
        MarkAsDoneFrame.IsVisible = true;
    }

    async void MarkDoneButton_Clicked(object sender, EventArgs e)
    {
        int equipmentId = int.Parse(EquipmentIdForMark.Text);
        DateTime date = DateTime.Parse(DateForMark.Text);

        var schedule = (await App.Database.GetAllMaintenanceSchedulesAsync()).FirstOrDefault(s => s.EquipmentId == equipmentId && s.NextMaintenanceDate == date);
        if (schedule != null)
        {
            schedule.IsDone = true;
            schedule.LastMaintenanceDate = schedule.NextMaintenanceDate;
            schedule.NextMaintenanceDate = schedule.NextMaintenanceDate.AddMonths(6); // Assuming next maintenance is 6 months later
            await App.Database.UpdateMaintenanceScheduleAsync(schedule);
            LoadMaintenanceSchedules();
        }
        MarkAsDoneFrame.IsVisible = false;
    }
}
