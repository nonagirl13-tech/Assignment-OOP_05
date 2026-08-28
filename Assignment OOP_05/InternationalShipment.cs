
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_OOP_05
{
    
        public class InternationalShipment : Shipment
        {
            public InternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
                : base(trackingCode, description, weight, deliveryFee, destination) { }

            public override decimal EstimatedCost => DeliveryFee + (Weight * 20);

            public override void PrintShipment()
            {
                Console.WriteLine("International Shipment");
                Console.WriteLine($"Tracking Code       : {TrackingCode}");
                Console.WriteLine($"Destination Country : {Destination.Country}");
                Console.WriteLine($"Estimated Cost      : {EstimatedCost} EGP");
            }

       public override decimal CalculateInsurance() => EstimatedCost * 0.12m;

            public override Shipment DeepCopy()
            {
                DeliveryAddress newAddress = new DeliveryAddress(Destination.City, Destination.Country);
                InternationalShipment copy = new InternationalShipment(TrackingCode, Description, Weight, DeliveryFee, newAddress);
                TotalShipmentsCreated--;

                copy.TrackingStatus = this.TrackingStatus;
                return copy;
            }
        }
    
}

