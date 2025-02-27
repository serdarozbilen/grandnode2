using Grand.Business.Checkout.Enum;

namespace Grand.Business.Checkout.Interfaces.Shipping
{
    /// <summary>
    /// Shipment tracker
    /// </summary>
    public partial interface IShipmentTracker
    {
        /// <summary>
        /// Gets if the current tracker can track the tracking number.
        /// </summary>
        /// <param name="trackingNumber">The tracking number to track.</param>
        /// <returns>True if the tracker can track, otherwise false.</returns>
        Task<bool> IsMatch(string trackingNumber);

        /// <summary>
        /// Gets a url for a page to show tracking info (third party tracking page).
        /// </summary>
        /// <param name="trackingNumber">The tracking number to track.</param>
        /// <returns>A url to a tracking page.</returns>
        Task<string> GetUrl(string trackingNumber);

        /// <summary>
        /// Gets all events for a tracking number.
        /// </summary>
        /// <param name="trackingNumber">The tracking number to track</param>
        /// <returns>List of Shipment Events.</returns>
        Task<IList<ShipmentStatusEvent>> GetShipmentEvents(string trackingNumber);
    }
}
