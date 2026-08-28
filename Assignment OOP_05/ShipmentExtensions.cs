
using System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_OOP_05
{
    public static class ShipmentExtensions
    {
        public static string GetSummary(this Shipment shipment)
        {
            string type = shipment switch
            {
                StandardShipment => "Standard",
                ExpressShipment => "Express",
                InternationalShipment => "International",
                _ => "Shipment"
            };

            return $"{shipment.TrackingCode} | {type} | {shipment.Weight} KG | {shipment.TrackingStatus}";
        }

        public static bool IsDelivered(this Shipment shipment)
        {
            return shipment.TrackingStatus.Equals("Delivered", StringComparison.OrdinalIgnoreCase);
        }
    }
}
