using Cila;
using Google.Protobuf;

namespace OmniChain
{
    public class OmniChainSerializer
    {

        public static DomainEvent DeserializeDomainEvent(byte[] data)
        {
            var msg = new DomainEvent();
            msg.MergeFrom(data);
            return msg;
        }

        public static InfrastructureEvent DeserializeInfrastructureEvent(byte[] data)
        {
            var msg = new InfrastructureEvent();
            msg.MergeFrom(data);
            return msg;
        }


        public static IMessage DeserializeEvent(DomainEvent e)
        {
            DomainEventType messageType = (DomainEventType)e.EvntType;
            byte[] messageBytes = e.EvntPayload.ToArray();
            IMessage message;

            switch (messageType)
            {
                case DomainEventType.NftMinted:
                    message = new NFTMintedPayload();
                    break;
                case DomainEventType.NftTransfered:
                    message = new NFTTransferedPayload();
                    break;
                default:
                    throw new ArgumentException("Invalid message type");
            }

            message.MergeFrom(messageBytes);
            return message;
        }
    }
}