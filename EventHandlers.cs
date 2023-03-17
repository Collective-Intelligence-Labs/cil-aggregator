
using Example.Protobuf;

internal class EventsHandler
{
    private static Dictionary<string,Item> items = new Dictionary<string, Item>();

    public void Handle(ItemMinted e){
        if (items.ContainsKey(e.Hash))
        {
            return;
        };
        items[e.Hash] = new Item(e.Hash,e.Owner);
    }

    public void Hander (ItemTransfered e)
    {
        if (!items.ContainsKey(e.Hash))
        {
            return;
        };
        items[e.Hash].Owner = e.To;
    }
}