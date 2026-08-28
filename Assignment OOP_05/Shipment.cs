
using System;
using System;
using System.Collections.Generic;
using System.Text;




namespace Assignment_OOP_05
{
    public abstract partial class Shipment
    {
        public static int TotalShipmentsCreated { get; protected set; }

        static Shipment()
        {
            TotalShipmentsCreated = 0;
            Console.WriteLine("Shipment System Initialized");
        }

        public string TrackingCode { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public decimal DeliveryFee { get; set; }
        public DeliveryAddress Destination { get; set; }

        
        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        {
            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
            TotalShipmentsCreated++;
        }

        public abstract decimal EstimatedCost { get; }
        public abstract void PrintShipment();
        public abstract decimal CalculateInsurance();

        public Shipment CopyShipment() => this;

        public Shipment ShallowCopy() => (Shipment)this.MemberwiseClone();

        public abstract Shipment DeepCopy();
    }
}