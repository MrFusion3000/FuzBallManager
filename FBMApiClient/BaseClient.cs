using Flurl;
using Flurl.Http;

namespace FBMApiClient;
public abstract class BaseClient
{
    protected static FormUrlEncodedContent GetClient()
    {
        return "http://localhost:5001".AppendPathSegment("api");
    }
}
