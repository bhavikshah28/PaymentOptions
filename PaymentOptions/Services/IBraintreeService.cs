using Braintree;

namespace PaymentOptions.Services
{
    public interface IBraintreeService
    {
        IBraintreeGateway createGateway();

        IBraintreeGateway GetGateway();
    }
}
