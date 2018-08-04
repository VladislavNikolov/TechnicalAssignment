namespace TA.MVC.Services
{
    using RestSharp;
    using System;

    public class BaseService
    {
        protected IRestClient restClient;

        public BaseService(IRestClient restClient)
        {
            this.restClient = restClient;
            this.restClient.BaseUrl = new Uri("http://localhost:57424");
        }
    }
}