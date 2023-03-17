using OmniChain;

namespace Cila
{

    internal class EventsDispatcher
    {
        private EventsHandler _handler;

        public EventsDispatcher(){
            _handler = new EventsHandler();
        }

        public void DispatchEvent(byte[] data){
            var msg = OmniChainSerializer.DeserializeWithMessageType(data);
            //var methodInfo = _handler.GetType().GetMethod("Handle", new[] { msg.GetType() });
            //methodInfo.Invoke(_handler, new [] {msg });
            dynamic dynamicHandler = _handler;
            dynamic dynamicMessage = msg;
            dynamicHandler.Handle(dynamicMessage);
        }
    }
}