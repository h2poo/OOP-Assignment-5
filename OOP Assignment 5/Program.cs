namespace OOP_Assignment_5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Theoretical Questions
            /*
                 
                  Q1  Object Copying
                a) What happens when you assign one object variable to another object variable?
                the new variable will reference the same object in memory as the original variable
                b) Does assigning one object to another create a new object? Explain.
                No , assigning one object to another does not create a new object . It simply copies the reference of the original object to the new variable
                c) What is the difference between copying an object and copying its reference?
                copying an object create a new object in memory with the same values as the original object , while copying its reference simply creates a new variable that points to the same object
                Q2  Shallow Copy vs Deep Copy
                a) What is a Shallow Copy?
                create new object and copies its field vallues to the new object. 
                b) What is a Deep Copy?
                create a new object and copies all the fields of the original object to the new object .
                c) What happens to reference-type members when a Shallow Copy is created?
                it is copied by reference 
                d) What happens to reference-type members when a Deep Copy is created?
                it is copied by value and a new instance of the reference type is created in memory
                e) Give one situation where Deep Copy would be safer than Shallow Copy.
                when the object has reference-type members that can be modified by other parts of the code, a deep copy would be safer to avoid unintended side effects.
                Q3  Static Members
                a) What is a static field, and how is it different from an instance field?
                static field is a field that belongs to the class itself rather than to any specific instance of the class. It is shared among all instances of the class, while an instance field is unique to each instance of the class.
                b) What is a static method? Can a static method directly access instance members?
                 static method is a method that belongs to the class itself rather than to any specific instance of the class. It can be called without creating an instance of the class.
                c) What is a static constructor, and when is it executed?
                static ctor  is a special constructor that is used to initialize static members of a class. It is executed only once, when the class is first loaded into memory.
                d) What is a static class? Can you create an object from a static class?
                static class is a class thet accessible only through its static members. It cannot be instantiated, and all its members must be static
                no you cannot create an object from a static class

                Q4  Extension Methods
                a) What is an Extension Method?
                it is a special kind of static method that allows you to add new methods to an existing class without modifying the original class or creating a new derived class. It is defined in a static class and uses the "this" keyword in its first parameter to specify the type it extends.
                b) What keyword must be used in the first parameter of an extension method?
                this
                c) Where must an extension method be declared?
                it must be declared in a static class
                d) Can an extension method access private members of the class it extends?
                yes it can access private members of the class
                Q5  Partial Classes and Partial Methods
                a) What is a Partial Class?
                it is a class that can be split into multiple files
                b) Why would a developer split one class into multiple files?
                to make the code more organized and easier to maintain 
                c) What is a Partial Method?
                it is a method that can be defined in one part of a partial class and implemented in another part of the same partial class 
                d) What happens if a declared partial method has no implementation?
                it will be removed by the compiler and will not be included in the final assembly


                 */
            #endregion

            DeliveryUtilities.PrintSystemTitle();

            Console.WriteLine("Creating Shipments...");
            DeliveryUtilities.PrintSeparator();

            Driver driver = new Driver(
                "D001",
                "Ahmed Mohamed",
                "01012345678");

            DeliveryCenter center =
                new DeliveryCenter("Cairo Delivery Center");

            center.Driver = driver;

            DeliveryAddress address1 =
                new DeliveryAddress(
                    "Cairo",
                    "Nasr City",
                    10);

            DeliveryAddress address2 =
                new DeliveryAddress(
                    "Giza",
                    "Main Street",
                    20);

            DeliveryAddress address3 =
                new DeliveryAddress(
                    "Cairo",
                    "Nile Street",
                    30);

            StandardShipment standard =
                new StandardShipment(
                    "SH001",
                    "Laptop",
                    3,
                    80,
                    address1);

            ExpressShipment express =
                new ExpressShipment(
                    "SH002",
                    "Mobile Phone",
                    2,
                    60,
                    address2,
                    30);

            InternationalShipment international =
                new InternationalShipment(
                    "SH003",
                    "Television",
                    8,
                    120,
                    address3,
                    "Germany",
                    100);

            center.AddShipment(standard);
            center.AddShipment(express);
            center.AddShipment(international);

            Console.WriteLine(
                $"Total Shipments Created : " +
                $"{Shipment.GetTotalShipmentsCreated()}");

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Object Copying");
            DeliveryUtilities.PrintSeparator();

            Shipment shipment1 = standard;
            Shipment shipment2 = shipment1;

            Console.WriteLine(
                $"Original Shipment : {shipment1.TrackingCode}");

            Console.WriteLine(
                $"Assigned Shipment : {shipment2.TrackingCode}");

            Console.WriteLine(
                $"Same Object : {ReferenceEquals(shipment1, shipment2)}");

            Console.WriteLine(
                "------------------------------------------");

            Console.WriteLine("Shallow Copy");
            Console.WriteLine(
                "------------------------------------------");

            Shipment shallowCopy =
                standard.ShallowCopy();

            Console.WriteLine(
                $"Original Shipment Address : " +
                $"{standard.Destination.City}");

            Console.WriteLine(
                $"Copied Shipment Address : " +
                $"{shallowCopy.Destination.City}");

            Console.WriteLine(
                "Changing copied shipment address...");

            shallowCopy.Destination.City = "Giza";

            Console.WriteLine(
                $"Original Shipment Address : " +
                $"{standard.Destination.City}");

            Console.WriteLine(
                $"Copied Shipment Address : " +
                $"{shallowCopy.Destination.City}");

            Console.WriteLine(
                $"Same DeliveryAddress Object : " +
                $"{ReferenceEquals(
                    standard.Destination,
                    shallowCopy.Destination)}");

            standard.Destination.City = "Cairo";

            Console.WriteLine(
                "------------------------------------------");

            Console.WriteLine("Deep Copy");
            Console.WriteLine(
                "------------------------------------------");

            Shipment deepCopy =
                standard.DeepCopy();

            Console.WriteLine(
                $"Original Shipment Address : " +
                $"{standard.Destination.City}");

            Console.WriteLine(
                $"Copied Shipment Address : " +
                $"{deepCopy.Destination.City}");

            Console.WriteLine(
                "Changing copied shipment address...");

            deepCopy.Destination.City = "Giza";

            Console.WriteLine(
                $"Original Shipment Address : " +
                $"{standard.Destination.City}");

            Console.WriteLine(
                $"Copied Shipment Address : " +
                $"{deepCopy.Destination.City}");

            Console.WriteLine(
                $"Same DeliveryAddress Object : " +
                $"{ReferenceEquals(
                    standard.Destination,
                    deepCopy.Destination)}");

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Extension Methods");
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine(
                standard.GetSummary());

            Console.WriteLine(
                express.GetSummary());

            Console.WriteLine(
                international.GetSummary());

            Console.WriteLine(
                $"SH001 Is Delivered : " +
                $"{standard.IsDelivered()}");

            Console.WriteLine(
                $"SH003 Is Delivered : " +
                $"{international.IsDelivered()}");

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Tracking Status");
            DeliveryUtilities.PrintSeparator();

            express.UpdateTrackingStatus(
                "Out For Delivery");

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Static Utilities");
            Console.WriteLine(
                "------------------------------------------");

            Console.WriteLine("Delivery Center");

            Console.WriteLine(
                "------------------------------------------");

            Console.WriteLine(
                $"Total Shipments Created : " +
                $"{Shipment.GetTotalShipmentsCreated()}");

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Partial Method");
            DeliveryUtilities.PrintSeparator();

            standard.UpdateTrackingStatus("Delivered");

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Assignment Completed");
        }
    }
}
