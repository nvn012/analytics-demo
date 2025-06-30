namespace AnalyticsDemo.Domain.DTO.User
{
    /// <summary>
    /// dto for further detail analytics
    /// like user behaviour intraction and all
    /// </summary>
    internal class UserImpression 
    {
        public long UserId { get; private set; }
        public InteractionType Type { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid CampaignId { get; private set; }
        public DateTime OccurredAt { get; private set; }
    }
    public enum InteractionType
    {
        View,
        Click,
        AddToBasket,
        Purchase
    }
}
