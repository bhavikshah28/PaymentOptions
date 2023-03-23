using Braintree;
using Microsoft.Extensions.Configuration;

namespace PaymentOptions.Services
{
    public class BraintreeService: IBraintreeService
    {
        private readonly IConfiguration _config;

        public BraintreeService(IConfiguration config)
        {
            _config = config;
        }

        public IBraintreeGateway createGateway()
        {
            var gateway = new BraintreeGateway()
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = _config.GetValue<string>("BraintreeGateway:MerchantId"),
                PublicKey = _config.GetValue<string>("BraintreeGateway:PublicKey"),
                PrivateKey = _config.GetValue<string>("BraintreeGateway:PrivateKey")
            };

            return gateway;
        }

        public IBraintreeGateway GetGateway()
        {
            return createGateway();
        }
    }
}
