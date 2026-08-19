namespace OOP_Assignment_5
{
    public class InternationalShipment : Shipment, IInsurable
    {
        public string DestinationCountry { get; set; }

        public decimal CustomsFee { get; set; }

        public InternationalShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination,
            string destinationCountry,
            decimal customsFee)
            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;

            SetInitialTrackingStatus("Delivered");
        }

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5) + CustomsFee;
            }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment");
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description : {Description}");
            Console.WriteLine($"Weight : {Weight} KG");
            Console.WriteLine($"Delivery Fee : {DeliveryFee} EGP");
            Console.WriteLine($"Destination Country : {DestinationCountry}");
            Console.WriteLine($"Customs Fee : {CustomsFee} EGP");
            Console.WriteLine($"Estimated Cost : {EstimatedCost} EGP");
        }

        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.12m;
        }

        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine(
                $"Customs Report for {TrackingCode}");
        }
    }
}