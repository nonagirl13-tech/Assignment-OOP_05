
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_OOP_05
{

    public class ExpressShipment : Shipment
    {
        public decimal ExtraFee { get; set; }

        public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, decimal extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }

        public override decimal EstimatedCost => DeliveryFee + ExtraFee + (Weight * 10);

        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment");
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Extra Fee     : {ExtraFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }

        public override decimal CalculateInsurance() => EstimatedCost * 0.08m;

        public override Shipment DeepCopy()
        {
            DeliveryAddress newAddress = new DeliveryAddress(Destination.City, Destination.Country);
            ExpressShipment copy = new ExpressShipment(TrackingCode, Description, Weight, DeliveryFee, newAddress, ExtraFee);
            TotalShipmentsCreated--;

            copy.TrackingStatus = this.TrackingStatus;
            return copy;
        }
    }
}
