using System;
using System.Collections.Generic;
using System.Text;





namespace Assignment_OOP_05
{
    public class StandardShipment : Shipment
    {
        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination) { }

        public override decimal EstimatedCost => DeliveryFee + (Weight * 15);

        public override void PrintShipment()
        {
            Console.WriteLine("Standard Shipment");
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }

        public override decimal CalculateInsurance() => EstimatedCost * 0.05m;

        public override Shipment DeepCopy()
        {
            DeliveryAddress newAddress = new DeliveryAddress(Destination.City, Destination.Country);
            StandardShipment copy = new StandardShipment(TrackingCode, Description, Weight, DeliveryFee, newAddress);
            TotalShipmentsCreated--; 
            copy.TrackingStatus = this.TrackingStatus;
            return copy;
        }
    }
}
