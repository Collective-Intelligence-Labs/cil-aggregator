using Cila.Database;
using Cila.Documents;
using Microsoft.AspNetCore.Mvc;

namespace cil_aggregator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NftController : ControllerBase
{
    private readonly MongoDatabase _db;

    public NftController(MongoDatabase db)
    {
        _db = db;
    }

    [HttpGet]
    public IEnumerable<NFTDocument> GetAll()
    {
        return _db.FindAllNfts();
    }

    [HttpGet("{id}")]
    public NFTDocument Get(string id)
    {
        return _db.FindOneNft(id);
    }

    [HttpGet("/owner/{id}")]
    public IEnumerable<NFTDocument> GetByOwner(string id)
    {
        return _db.FindAllNfts(id);
    }

}
