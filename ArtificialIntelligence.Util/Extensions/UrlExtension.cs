using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Web;

namespace ArtificialIntelligence.Util.Extensions;

[ExcludeFromCodeCoverage]
public static class UrlExtension
{
    public static string AddQueryParams(this string url, object request)
    {
        var uriBuilder = new UriBuilder(url);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);

        foreach (PropertyInfo property in request.GetType().GetProperties())
        {
            var value = property.GetValue(request);


            if (value == null)
            {
                continue;
            }

            if (value is IEnumerable enumerable && !(value is string)) 
            {
                foreach (var item in enumerable)
                {
                    query.Add(property.Name, item?.ToString());
                }
            }
            else
            {
                var stringValue = value.ToString();
                if (!string.IsNullOrEmpty(stringValue))
                {
                    query[property.Name] = stringValue;
                }
            }
        }

        uriBuilder.Query = query.ToString();
        return uriBuilder.ToString();
    }
}