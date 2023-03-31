using Cila.Database;
using Cila.Documents;
using Microsoft.AspNetCore.Mvc;

namespace cil_aggregator.Controllers;

[ApiController]
[Route("[controller]")]
public class OperationsController : ControllerBase
{
    private readonly MongoDatabase _db;

    public OperationsController(MongoDatabase db)
    {
        _db = db;
    }

    [HttpGet(Name = "GetAll")]
    public IEnumerable<OperationDocument> GetAl()
    {
        return _db.FindAllOperations();
    }
}

public class NftDto
{
    public string Hash { get; set; }
    
    public string Owner { get; set; }
}
