namespace OOP_Assignment_5
{
    public abstract partial class Shipment
    {
        public string GetTrackingStatus()
        {
            return TrackingStatus;
        }

        public void UpdateTrackingStatus(string newStatus)
        {
            if (!string.IsNullOrWhiteSpace(newStatus))
            {
                TrackingStatus = newStatus;

                OnTrackingStatusChanged(newStatus);
            }
        }

        partial void OnTrackingStatusChanged(
            string newStatus)
        {
            Console.WriteLine(
                $"Tracking status changed to: {newStatus}");
        }
    }
}