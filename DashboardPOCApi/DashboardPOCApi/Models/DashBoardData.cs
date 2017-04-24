namespace DashboardPOCApi.Models
{
    public class DashBoardData
    {
        public HospitalDelivery Hospital { get; }
        public Visualization Visualization { get; }

        public DashBoardData(HospitalDelivery hospitalDelivery, Visualization visualization)
        {
            Hospital = hospitalDelivery;
            Visualization = visualization;
        }
    }
}