

internal class EventsHandler
{
    private static Dictionary<string,Item> items = new Dictionary<string, Item>();

    public void Handle(NFTMintedPayload e){
        string hash = e.Hash.ToString();
        if (items.ContainsKey(hash))
        {
            return;
        };
        items[hash] = new Item(hash,e.Owner.ToString());
    }

    public void Handle(NFTTransferedPayload e)
    {
        string hash = e.Hash.ToString();
        if (!items.ContainsKey(hash))
        {
            return;
        };
        items[hash].Owner = e.To.ToString();
    }
}