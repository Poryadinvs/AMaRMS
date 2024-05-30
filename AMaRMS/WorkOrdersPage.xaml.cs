
namespace AMaRMS;

public partial class WorkOrdersPage : ContentPage
{
    public WorkOrdersPage()
    {
        InitializeComponent();
        LoadWorkOrders();
    }

    async void LoadWorkOrders()
    {
        var workOrdersList = await App.Database.GetAllWorkOrdersAsync();
        WorkOrdersList.ItemsSource = workOrdersList;
    }

    void AddWorkOrder_Clicked(object sender, EventArgs e)
    {
        AddFrame.IsVisible = true;
    }

    async void AddWorkOrderButton_Clicked(object sender, EventArgs e)
    {
        var workOrder = new WorkOrders
        {
            EquipmentId = int.Parse(EquipmentIdEntry.Text),
            WorkOrderDate = DateTime.Parse(WorkOrderDateEntry.Text),
            Description = DescriptionEntry.Text,
            Status = "Open",
            AssignedTo = AssignedToEntry.Text
        };

        await App.Database.SaveWorkOrderAsync(workOrder);
        AddFrame.IsVisible = false;
        LoadWorkOrders();
    }

    void ChangeStatus_Clicked(object sender, EventArgs e)
    {
        ChangeStatusFrame.IsVisible = true;
    }

    async void ChangeStatusButton_Clicked(object sender, EventArgs e)
    {
        int equipmentId = int.Parse(EquipmentIdForStatus.Text);
        DateTime workOrderDate = DateTime.Parse(WorkOrderDateForStatus.Text);
        var newStatus = NewStatusEntry.Text;

        var workOrder = (await App.Database.GetAllWorkOrdersAsync()).FirstOrDefault(wo => wo.EquipmentId == equipmentId && wo.WorkOrderDate == workOrderDate);
        if (workOrder != null)
        {
            workOrder.Status = newStatus;
            await App.Database.UpdateWorkOrderAsync(workOrder);
            LoadWorkOrders();
        }
        ChangeStatusFrame.IsVisible = false;
    }

    void DeleteWorkOrder_Clicked(object sender, EventArgs e)
    {
        DeleteFrame.IsVisible = true;
    }

    async void DeleteWorkOrderButton_Clicked(object sender, EventArgs e)
    {
        int equipmentId = int.Parse(EquipmentIdForDelete.Text);
        DateTime workOrderDate = DateTime.Parse(WorkOrderDateForDelete.Text);

        var workOrder = (await App.Database.GetAllWorkOrdersAsync()).FirstOrDefault(wo => wo.EquipmentId == equipmentId && wo.WorkOrderDate == workOrderDate);
        if (workOrder != null)
        {
            await App.Database.DeleteWorkOrderAsync(workOrder);
            LoadWorkOrders();
        }
        DeleteFrame.IsVisible = false;
    }
}
