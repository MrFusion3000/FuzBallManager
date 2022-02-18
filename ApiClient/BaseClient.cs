using Flurl;
using Flurl.Http;

namespace ApiClient;

public abstract class BaseClient
{
    protected static Url GetClient()
    {
        return "https://localhost:5001/".AppendPathSegment("api");
    }
}
