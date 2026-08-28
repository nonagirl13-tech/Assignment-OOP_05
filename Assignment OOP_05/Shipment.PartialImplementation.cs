using System;
using System.Collections.Generic;
using System.Text;



namespace Assignment_OOP_05
{
    public abstract partial class Shipment
    {
        // Partial method implementation (Requirement 10)
        partial void OnTrackingStatusChanged(string newStatus)
        {
            Console.WriteLine($"Tracking status changed to: {newStatus}");
        }
    }
}
