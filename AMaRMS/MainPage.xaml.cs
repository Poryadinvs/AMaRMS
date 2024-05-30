namespace AMaRMS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnEquipmentClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EquipmentPage());
        }

        private async void OnMaintenanceScheduleClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MaintenanceSchedulePage());
        }

        private async void OnMaintenanceRecordClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CompletedWorkPage());
        }

        private async void OnSparePartsClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SparePartsPage());
        }

        private async void OnWorkOrdersClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new WorkOrdersPage());
        }
    }

}
