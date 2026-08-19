namespace OOP_Assignment_5
{
    public class Driver
    {
        public string DriverId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public Driver(
            string driverId,
            string fullName,
            string phoneNumber)
        {
            DriverId = driverId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }
    }
}