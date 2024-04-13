using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_and_repo_pattern.helper
{
    public struct BaseUrl
    {

        public const string FoodOrderApi = "https://localhost:7067/";


    }
    public struct Request
    {
        public const string FoodOrderApi = "ShowtimeMulti";
    }

    public static class Router
    {

        public static string route(this string Route, string project)
        {
            string route = null;
            switch (project)
            {
                case Request.FoodOrderApi:
                    route = $"{BaseUrl.FoodOrderApi}{Route}";
                    break;
                default:
                    throw new ArgumentException("Invalid Route");
            }
            return route;
        }
    }
}
