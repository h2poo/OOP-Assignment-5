using SmartDeliveryManagementSystem;

namespace OOP_Assignment_5
{
    public static class ShipmentExtensions
    {
        public static string GetSummary(
            this Shipment shipment)
        {
            return $"{shipment.TrackingCode} | " +
                   $"{GetShipmentType(shipment)} | " +
                   $"{shipment.Weight} KG | " +
                   $"{shipment.GetTrackingStatus()}";
        }

        public static bool IsDelivered(
            this Shipment shipment)
        {
            return shipment.GetTrackingStatus() == "Delivered";
        }

        private static string GetShipmentType(
            Shipment shipment)
        {
            if (shipment is StandardShipment)
            {
                return "Standard";
            }

            if (shipment is ExpressShipment)
            {
                return "Express";
            }

            if (shipment is InternationalShipment)
            {
                return "International";
            }

            if (shipment is CompletedShipment)
            {
                return "Completed";
            }

            return shipment.GetType().Name;
        }
    }
}