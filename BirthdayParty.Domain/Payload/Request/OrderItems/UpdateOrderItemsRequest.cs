namespace BirthdayParty.Domain.Payload.Request.OrderItems
{
    public class UpdateOrderItemsRequest
    {
        public bool? IsPreorder { get; set; }

        public string? Status { get; set; }
        public bool? IsDeleted { get; set; }
    }
}