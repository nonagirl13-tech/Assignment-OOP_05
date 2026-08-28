using System;
using System.Collections.Generic;
using System.Text;



namespace Assignment_OOP_05
{
    public abstract partial class Shipment
    {
        public string TrackingStatus { get; set; } = "Ready";

        public virtual string GetTrackingStatus() => $"Shipment {TrackingCode} is {TrackingStatus}.";

        public void UpdateTrackingStatus(string newStatus)
        {
            TrackingStatus = newStatus;
            // Call partial method when status changes (Requirement 10)
            OnTrackingStatusChanged(newStatus);
        }

        // Partial method declaration (Requirement 10)
        partial void OnTrackingStatusChanged(string newStatus);
    }
}
