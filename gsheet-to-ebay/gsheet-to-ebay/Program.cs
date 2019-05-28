using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;

namespace gsheet_to_ebay
{
    public class Program
    {

                static void Main(string[] args)
        {
            var context = NewApiContext(Settings.Default.eBayURI, Settings.Default.eBayToken);
            //var apiCall = new GeteBayOfficialTimeCall(context);
            var apiCall = new SetStoreCall(context);

            //var time = apiCall.GeteBayOfficialTime();
            //var options = apiCall.GetStoreOptions();
            var store = new StoreType()
            {
                Description = "Test Store",
                Name = "Test Store",
                SubscriptionLevel = StoreSubscriptionLevelCodeType.Basic,
                Theme = new StoreThemeType() { ThemeID = 1 }
            };

            apiCall.SetStore(store);

            var addCall = new AddFixedPriceItemCall(context);


            addCall.AddFixedPriceItem(item);

            //Console.WriteLine(time);
            //Console.WriteLine(options);

            Console.ReadKey();
        }

        private static ItemType NewItem(
            string title, 
            string description, 
            string category, 
            int condition, 
            string duration, 
            string email, 
            string photo1URL, 
            string photo2URL, 
            string zipCode, 
            string shipService, 
            ListingTypeCodeType type = ListingTypeCodeType.FixedPriceItem)
        {
            string htmlDescription = 
                string.Format(@"<![CDATA[<table cellspacing ='28' cellpadding='0' width='100%'>
                                           <tbody>
                                             <tr>
                                               <td valign='top'>
                                               <hr size='6'>
                                               <br>
                                               <div align='left'>
                                                 <font size='4'><b>I T E M&nbsp;&nbsp;&nbsp; D E S C R I P T I O N:</b></font>
                                                 <br>
                                               </div>
                                               <font size='3'><br>%s<br><br>
                                                 <b>All of my items are stored in a clean and smoke free home.</b>
                                                 <br><br><br><hr><br><br>
                                                 <i><b>NOW OFFERING COMBINED SHIPPING!</b></i>
                                                 <br><br>
                                                 <i>Add items to your cart to see the HUGE savings! Shipping charges will be calculated automatically based on weight.</i>
                                                 <br><br><br><hr size='6'>
                                               </font>
                                             </td>
                                           </tr>
                                         </tbody>
                                       </table>]]>{0}", description);

            var item = new ItemType
            {
                Title = title,
                Description = htmlDescription,
                PrimaryCategory = new CategoryType { CategoryID = category },
                StartPrice = new AmountType() { Value = 0 },
                CategoryMappingAllowed = true,
                Country = CountryCodeType.US,
                ConditionID = condition,
                Currency = CurrencyCodeType.USD,
                DispatchTimeMax = 3,
                ListingDuration = duration,
                ListingType = type,
                PaymentMethods = { BuyerPaymentMethodCodeType.PayPal },
                PayPalEmailAddress = email,
                PictureDetails = new PictureDetailsType() { PictureURL = { photo1URL, photo2URL } },
                PostalCode = zipCode,
                Quantity = 0,
                ReturnPolicy = new ReturnPolicyType()
                {
                    ReturnsAcceptedOption = "ReturnsAccepted",
                    RefundOption = "MoneyBack",
                    ReturnsWithinOption = "Days_30",
                    Description = "If you are not satisfied, return the book for refund.",
                    ShippingCostPaidByOption = "Buyer"
                },
                SellerProfiles = new SellerProfilesType()
                {
                    SellerPaymentProfile = new SellerPaymentProfileType() { PaymentProfileName = "PayPal:Immediate pay" },
                    SellerReturnProfile = new SellerReturnProfileType() { ReturnProfileName = "30 Day Return Policy" },
                    SellerShippingProfile = new SellerShippingProfileType() { ShippingProfileName = "" }
                },
                ShippingDetails = new ShippingDetailsType()
                {
                    ShippingType = ShippingTypeCodeType.Calculated,
                    ShippingServiceOptions = new ShippingServiceOptionsTypeCollection()
                    {
                        new ShippingServiceOptionsType() { ShippingServicePriority = 1 },
                        new ShippingServiceOptionsType() { ShippingService = "USPSMedia" }
                    },
                    CalculatedShippingRate = new CalculatedShippingRateType()
                    {
                        OriginatingPostalCode = zipCode,
                        PackagingHandlingCosts = new AmountType() { Value = 0 }
                    }
                },
                ShippingPackageDetails = new ShipPackageDetailsType()
                {
                    ShippingPackage = ShippingPackageCodeType.PackageThickEnvelope,
                    WeightMajor = new MeasureType() { Value = 0 },
                    WeightMinor = new MeasureType() { Value = 0 }
                },
                Site = SiteCodeType.US
            };

            return item;
        }

        private static ApiContext NewApiContext(string apiURI, string token, SiteCodeType site = SiteCodeType.US)
        {
            var apiContext = new ApiContext()
            {
                SoapApiServerUrl = apiURI,
                ApiCredential = new ApiCredential(token),
                Site = site
            };

            return apiContext;
        }
        
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
