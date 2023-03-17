using Cila;
using Example.Protobuf;
using Google.Protobuf;

namespace OmniChain
{
    public class OmniChainSerializer
    {
        public static IMessage DeserializeWithMessageType(DomainEvent e)
        {
            DomainEventType messageType = (DomainEventType)e.EventType;
            byte[] messageBytes = e.Payload;
            IMessage message;

            switch (messageType)
            {
                case DomainEventType.ItemMinted:
                    message = new ItemMinted();
                    break;
                case DomainEventType.ItemTransfered:
                    message = new ItemTransfered();
                    break;
                default:
                    throw new ArgumentException("Invalid message type");
            }

            message.MergeFrom(messageBytes);
            return message;
        }
    }
}