using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_and_repo_pattern.helper
{
    public interface IApiRequestFactory
    {
        Task<string> PostGetString<T>(string url, T entity, bool isCompressed = true);
        Task<U> PostDiffRequest<T, U>(string url, T entity, bool isCompressed = true);
        Task<T> GetRequest<T>(string url, bool isCompressed = false, string rootUrl = null);
        Task<T> PostRequest<T>(string url, T entity, string rootUrl = null);
    }
}
