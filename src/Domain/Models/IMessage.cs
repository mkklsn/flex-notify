namespace flex_notify.Domain.Models
{
    public interface IMessage
    {
        string Id { get; set; }

        string SessionId { get; set; }
    }
}
