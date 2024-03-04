namespace BirthdayParty.WebApi.Constants
{
    public static class ApiEndPointConstant
    {
        static ApiEndPointConstant()
        {
        }

        public const string RootEndPoint = "/api";
        public const string ApiVersion = "/v1";
        public const string ApiEndpoint = RootEndPoint + ApiVersion;

        public static class Authentication
        {
            public const string AuthenticationEndpoint = ApiEndpoint + "/auth";
            public const string Login = AuthenticationEndpoint + "/login";
        }

        public static class Account
        {
            public const string AccountsEndpoint = ApiEndpoint + "/accounts";
            public const string AccountEndpoint = AccountsEndpoint + "/{id}";
        }

        public static class OrderDetail
        {
            public const string OrderDetailsEndpoint = ApiEndpoint + "/orderdetails";
            public const string OrderDetailEndpoint = OrderDetailsEndpoint + "/{id}";
        }


        public static class OrderItem
        {
            public const string OrderItemsEndpoint = ApiEndpoint + "/orderitems";
            public const string OrderItemEndpoint = OrderItemsEndpoint + "/{id}";
        }

        public static class PaymentDetail
        {
            public const string PaymentDetailsEndpoint = ApiEndpoint + "/paymentdetails";
            public const string PaymentDetailEndpoint = PaymentDetailsEndpoint + "/{id}";
        }
        public static class HostParty
        {
            public const string HostPartiesEndpoint = ApiEndpoint + "/hostparties";
            public const string HostPartyEndpoint = HostPartiesEndpoint + "/{id}";

        }

        public static class PartyPackage
        {
            public const string PartyPackagesEndpoint = ApiEndpoint + "/partypackages";
            public const string PartyPackageEndpoint = PartyPackagesEndpoint + "/{id}";
        }

        public static class Post
        {
            public const string PostsEndpoint = ApiEndpoint + "/posts";
            public const string PostEndpoint = PostsEndpoint + "/{id}";
        }

        public static class Discount
        {
            public const string DiscountsEndpoint = ApiEndpoint + "/discounts";
            public const string DiscountEndpoint = DiscountsEndpoint + "/{id}";

        }
        public static class Menu
        {
            public const string MenusEndpoint = ApiEndpoint + "/menu";
            public const string MenuEndpoint = MenusEndpoint + "/{id}";
        }
    }
}
