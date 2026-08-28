using System.Net;

namespace Assignment_OOP_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Part 01 — Theoretical Questions
            #region Q1 Object Copying
            // A- The referance is copied, not the object itself. Both variables will point to the exact same object in memory.
            // B- No, it does not create a new object. It only creates a new reference pointing to the existing object. Any modification made through either variable will affect the same object.
            /* C- Copying a reference makes two variables point to the same object (modifying one affects the other).
             Copying an object creates a brand new, independent object in memory with its own data.*/



            #endregion

            #region Q2 Shallow Copy vs Deep Copy
            // A-It is a copy where value-type fields are copied directly, but for reference-type fields, only their references (addresses) are copied, not the objects they point to.
            // B-It is a complete copy where both the object and all nested reference-type objects are duplicated, making the new object completely independent of the original.
            // C-They continue to point to the same original objects shared between the original and the copy.
            // D-New independent copies of those referenced objects are created.
            // E-When an object contains a nested object (like a DeliveryAddress) and you want to modify the address in the copied object without changing the original shipment's address.

            #endregion

            #region Q3 Static Members
            //A -A static field belongs to the class itself rather than any specific instance, and its value is shared across all objects. An instance field has a separate copy for every object.
            //B - A static method belongs to the class and does not require an object instance to be called. it cannot directly access instance members because it doesn't have a( this ) reference
            //C - A static constructor is used to initialize static members of a class and is called automatically before any static members are accessed or any instances are created. An instance constructor initializes instance members and is called when an object is created.
            // D- A static class contains only static members and cannot be instantiated (you cannot create an object from it).

            #endregion

            #region Q4 Extension Methods
            // A- A method that allows you to add new functionality to an existing class without modifying the original class or creating a derived class.
            // B- this
            //C- It must be declared inside a static class.
            //D- No, it can only access public or accessible members.


            #endregion

            #region Q5 Partial Classes and Partial Methods
            //A-It is a class whose definition is split across multiple files using the partial keyword, and the compiler combines them into a single class at compile time.
            //B- To organize code, facilitate team collaboration.
            //C- A partial method is a method declared in one part of a partial class, and it can be implemented in another part.
            //D -The compiler completely removes the declaration and all calls to it during compilation as if it never existed.
            #endregion
            //______________________________________________________________________________________________________________________
            // Part 02 — Practical Questions

            // Static Constructor and System Title Demo
            DeliveryUtilities.PrintSystemTitle("Smart Delivery Management System");

            Console.WriteLine("Creating Shipments...");
            DeliveryAddress address1 = new DeliveryAddress("Cairo", "Egypt");

            StandardShipment shipment1 = new StandardShipment("SH001", "Laptop", 3m, 50m, address1);
            Console.WriteLine("Standard Shipment Created");

            ExpressShipment shipment2 = new ExpressShipment("SH002", "Phone", 2m, 40m, address1, 30m);
            Console.WriteLine("Express Shipment Created");

            InternationalShipment shipment3 = new InternationalShipment("SH003", "Server", 8m, 100m, new DeliveryAddress("Berlin", "Germany"));
            Console.WriteLine("International Shipment Created");

            // Static Method Demo 
            Console.WriteLine($"Total Shipments Created : {Shipment.TotalShipmentsCreated}");

            // Object Copying Demo 
            DeliveryUtilities.PrintSystemTitle("Object Copying");
            Shipment assignedShipment = shipment1.CopyShipment();
            Console.WriteLine($"Original Shipment  : {shipment1.TrackingCode}");
            Console.WriteLine($"Assigned Shipment  : {assignedShipment.TrackingCode}");
            Console.WriteLine($"Same Object : {ReferenceEquals(shipment1, assignedShipment)}");

            // Shallow Copy Demo 
            DeliveryUtilities.PrintSystemTitle("Shallow Copy");
            Shipment shallowCopy = shipment1.ShallowCopy();
            Console.WriteLine($"Original Shipment Address : {shipment1.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {shallowCopy.Destination.City}");

            Console.WriteLine("Changing copied shipment address...");
            shallowCopy.Destination.City = "Giza";

            Console.WriteLine($"Original Shipment Address : {shipment1.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {shallowCopy.Destination.City}");
            Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(shipment1.Destination, shallowCopy.Destination)}");

            // Deep Copy Demo 
            DeliveryUtilities.PrintSystemTitle("Deep Copy");
            // Reset address back for clean demo
            shipment1.Destination.City = "Cairo";
            Shipment deepCopy = shipment1.DeepCopy();

            Console.WriteLine($"Original Shipment Address : {shipment1.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {deepCopy.Destination.City}");

            Console.WriteLine("Changing copied shipment address...");
            deepCopy.Destination.City = "Giza";

            Console.WriteLine($"Original Shipment Address : {shipment1.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {deepCopy.Destination.City}");
            Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(shipment1.Destination, deepCopy.Destination)}");

            // Extension Methods Demo 
            DeliveryUtilities.PrintSystemTitle("Extension Methods");
            shipment1.TrackingStatus = "In Transit";
            shipment2.TrackingStatus = "Out For Delivery";
            shipment3.TrackingStatus = "Delivered";

            Console.WriteLine(shipment1.GetSummary());
            Console.WriteLine(shipment2.GetSummary());
            Console.WriteLine(shipment3.GetSummary());

            Console.WriteLine($"SH001 Is Delivered : {shipment1.IsDelivered()}");
            Console.WriteLine($"SH003 Is Delivered : {shipment3.IsDelivered()}");

            // Partial Method Demo 
            DeliveryUtilities.PrintSystemTitle("Tracking Status");
            shipment2.UpdateTrackingStatus("Out For Delivery");

            DeliveryUtilities.PrintSystemTitle("Static Utilities");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Delivery Center");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine($"Total Shipments Created : {Shipment.TotalShipmentsCreated}");

            DeliveryUtilities.PrintSystemTitle("Partial Method");
            shipment3.UpdateTrackingStatus("Delivered");

            DeliveryUtilities.PrintSystemTitle("Assignment Completed");
        }
    }

}
    

