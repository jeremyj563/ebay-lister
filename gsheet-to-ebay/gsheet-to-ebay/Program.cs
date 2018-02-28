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

        public static void Main(string[] args)
        {
            //Instantiate and set properties in ApiContext
            ApiContext apiContext = GetApiContext();

            //Instantiate the call wrapper class
            GeteBayOfficialTimeCall apiCall = new GeteBayOfficialTimeCall(apiContext);

            //Send the call to eBay and get the results
            DateTime officialTime = apiCall.GeteBayOfficialTime();

            //Handle the result returned
            Console.WriteLine("eBay official Time: " + officialTime);

            //BuildWebHost(args).Run();
        }

        // Instantiating and setting ApiContext
        private static ApiContext GetApiContext()
        {
            ApiContext apiContext = new ApiContext();

            //supply Api Server Url
            apiContext.SoapApiServerUrl = "https://api.sandbox.ebay.com/wsapi";

            //Supply user token
            ApiCredential apiCredential = new ApiCredential();

            //Just a partial token is shown for display purposes
            apiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**mqPNWQ**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6AFkYqjDpKEowmdj6x9nY+seQ**PIgDAA**AAMAAA**zt+0mG0kQZAk3iLwMY4LOvkKfJqX3KaitUDSNaiPz0o+23vlGXpAcQ9VsdY4u+6JPUz+cBqfeDC88IKm6cFF/7FrFavFvF4z/eD3ds/hRaGRjW34927U4dro1ihh+e/H9b0X6sVBxIcG4VbDidf3FeypGEqutRrxHi1n1TbaRFA4Jhg3yjJrhreGIVf6Sy4xV+dve4SUQVE6CmchSBPwbdvivEVaxsBWB5RXb0lMZvGC7IIkBFi3sxoWCnh21MLeP3WDxUE1AjIabbqYsjMXmIZvqUX/nwXcJb8GU08VOWcWaHxKVB56FsPMjJtJtuydTEArwqibOuSSNs1MQV2GnI9PMARFVwl5R6O+a8A3DK8/XwpaYhMa/+LxQSwExP0mlWU7VGfBQNjAMbg5ldl9oeT+wk9RDg6or7OjOTuAXMJU2pn2Ay9fdG+poBPw/jmDpq6JL97e1YwuWFugB0YI6HOVvEBIJtzfjhGPzXoTvxLDLdwbx6GdjisI9r7k0sANtUdsEnnJ2BNi5uKcrOeLKe6o7t7F46DuAQIrKUM4uIQh+zT2M0bS4XYoTil1M41KbG6ARrMlpkyKbkpkqHcERhARUSrK75OOjJadGQa2i4egWM3D598INiaLIZaMwt6ure+IIPdFH1zAzybIEf/zk5u6W23YHfOJIRu3LCDLLfwRNph1XknIPFE+U634MrsfhzEFSsDwEaO7XNWkd/FLQgH7MTZzAbxMtraC7S//sEDRZrPeGBpOsIee3Gd1oD8B";
            apiContext.ApiCredential = apiCredential;

            //Specify site: here we use US site
            apiContext.Site = SiteCodeType.US;

            return apiContext;

        } //GetApiContext

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
