using System.Text.Json.Serialization;

namespace Common.EventBus.Events;

public class IntegrationEvent
{
    public IntegrationEvent()
    {
        Id = Guid.NewGuid();
        CreatedOn = DateTime.Now;
    }

    public IntegrationEvent(Guid id , DateTime createdOn)
    {
        Id = id;
        CreatedOn = createdOn;
    }
    
    [JsonPropertyName("id")]
    public Guid Id { get; private set; }

    [JsonPropertyName("createdOn")]
    public DateTime CreatedOn { get; private set; }
}