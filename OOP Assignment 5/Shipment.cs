namespace OOP_Assignment_5
{
    public abstract partial class Shipment : ITrackable
    {
        private string trackingCode;
        private string description;
        private decimal weight;
        private decimal deliveryFee;

        private string trackingStatus;

        public static int TotalShipmentsCreated;

        static Shipment()
        {
            TotalShipmentsCreated = 0;

            Console.WriteLine("Shipment System Initialized");
        }

        public string TrackingCode
        {
            get
            {
                return trackingCode;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public decimal Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
            }
        }

        public decimal DeliveryFee
        {
            get
            {
                return deliveryFee;
            }
            protected set
            {
                if (value >= 0)
                {
                    deliveryFee = value;
                }
            }
        }

        public DeliveryAddress Destination { get; set; }

        public string TrackingStatus
        {
            get
            {
                return trackingStatus;
            }
            private set
            {
                trackingStatus = value;
            }
        }

        public abstract decimal EstimatedCost { get; }

        public abstract void PrintShipment();

        public Shipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination)
        {
            this.trackingCode = trackingCode;
            this.description = description;

            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;

            trackingStatus = "In Transit";

            TotalShipmentsCreated++;
        }

        public void UpdateWeight(decimal newWeight)
        {
            if (newWeight > 0)
            {
                Weight = newWeight;
            }
        }

        public void UpdateWeight(
            decimal newWeight,
            decimal packingWeight)
        {
            if (newWeight > 0 && packingWeight >= 0)
            {
                Weight = newWeight + packingWeight;
            }
        }

        public static int GetTotalShipmentsCreated()
        {
            return TotalShipmentsCreated;
        }

        public Shipment CopyShipment()
        {
            return DeepCopy();
        }

        public Shipment ShallowCopy()
        {
            return (Shipment)this.MemberwiseClone();
        }

        public Shipment DeepCopy()
        {
            Shipment copy = (Shipment)this.MemberwiseClone();

            copy.Destination = new DeliveryAddress(
                Destination.City,
                Destination.Street,
                Destination.BuildingNumber);

            return copy;
        }

        protected void SetInitialTrackingStatus(string status)
        {
            trackingStatus = status;
        }

        partial void OnTrackingStatusChanged(
            string newStatus);

        public override string ToString()
        {
            return $"Tracking Code : {TrackingCode}\n" +
                   $"Description : {Description}\n" +
                   $"Weight : {Weight} KG\n" +
                   $"Delivery Fee : {DeliveryFee} EGP\n" +
                   $"Estimated Cost : {EstimatedCost} EGP";
        }
    }
}