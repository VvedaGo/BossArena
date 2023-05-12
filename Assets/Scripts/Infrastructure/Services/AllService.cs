namespace Infrastructure.Services
{
    public class AllService
    {
        private static AllService _instance;

        public static AllService Container => _instance ?? (_instance=new AllService());


        public void RegisterSingle<TService>(TService service) 
        {
            ServiceCell<TService>.ServiceInstance = service;
        }

        public TService Single<TService>() 
        {
            return ServiceCell<TService>.ServiceInstance;
        }

        private class ServiceCell<TService> 
        {
            public static TService ServiceInstance;
        }
    }
}