using System.Reflection;
using OmniChain;

namespace Cila
{

    internal class EventsDispatcher
    {
        private Dictionary<Type, List<Type>> _subscriptions = new Dictionary<Type, List<Type>>();

        public EventsDispatcher(IServiceLocator serviceLocator){
            RegisterEventHanlders();
        }

        public void DispatchEvent(DomainEvent e){

            var msg = OmniChainSerializer.DeserializeEvent(e);
            
        }

        public void Dispatch(object msg)
        {
            var msgType = msg.GetType();
            var handlers = _subscriptions[msgType];
            foreach (var handler in handlers)
            {
                var methodInfo = handler.GetType().GetMethod("Handle", new[] { msgType });
                methodInfo.Invoke(handler, new [] { msg });
            }
        }

        private void RegisterEventHanlders()
        {
            var eventHandlerMap = new Dictionary<Type, List<Type>>();
            var eventHandlerTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(IEventHandler).IsAssignableFrom(type) && type != typeof(IEventHandler))
                .ToList();

            foreach (var eventType in eventHandlerTypes.SelectMany(t => t.GetMethods()
                .Where(m => m.Name == "Handle" && m.GetParameters().Length == 1)
                .Select(m => m.GetParameters()[0].ParameterType)).Distinct())
            {
                eventHandlerMap[eventType] = new List<Type>();
                foreach (var handlerType in eventHandlerTypes.Where(t => t.GetMethods()
                    .Any(m => m.Name == "Handle" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == eventType)))
                {
                    eventHandlerMap[eventType].Add(handlerType);
                }
                _subscriptions = eventHandlerMap;
            }
        }
    }
}