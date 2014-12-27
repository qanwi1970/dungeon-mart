using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace DungeonMart.Utils
{
    public class PagedListResult<T> : IHttpActionResult
    {
        private readonly HttpRequestMessage _request;
        private readonly List<T> _theList;
        private readonly long _from;
        private readonly long _to;
        private readonly long? _length;
        private readonly string _unit;

        public PagedListResult(HttpRequestMessage request, List<T> theList, long from, long to, long? length, string unit)
        {
            _request = request;
            _theList = theList;
            _from = from;
            _to = to;
            _length = length;
            _unit = unit;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpStatusCode code;
            if (_length.HasValue)
            {
                // status is 206 if there's more data
                // or 200 if it's at the end
                code = _length - 1 == _to
                    ? HttpStatusCode.OK
                    : HttpStatusCode.PartialContent;
            }
            else
            {
                // status is 200 if we don't know length
                code = HttpStatusCode.OK;
            }
            // create the response from the original request
            var response = _request.CreateResponse(code, _theList);
            // add the Content-Range header to the response
            response.Content.Headers.ContentRange = _length.HasValue
                ? new ContentRangeHeaderValue(_from, _to, _length.Value)
                : new ContentRangeHeaderValue(_from, _to);
            response.Content.Headers.ContentRange.Unit = _unit;

            return Task.FromResult(response);
        }
    }
}