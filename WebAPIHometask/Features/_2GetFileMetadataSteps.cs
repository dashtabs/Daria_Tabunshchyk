using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace WebAPIHometask.Features
{
    [TestFixture]
    [AllureNUnit]
    [Binding]
    public class _2GetFileMetadataSteps
    {
        public static RestRequest request;
        public static RestClient client;
        public static RestResponse response;

        [Given(@"There is an (.*) on Dropbox")]
        public void GivenThereIsAnImageOnDropbox(string path)
        {
            Builder b = new GetMetaData();
            Request rq = new Request(b);
            var headers = new List<Header> {
                new Header("Content-Type", "application/json"),
                };
            rq.Build(path, headers);
            request = b.Get();
        }
        
        [When(@"POST request  is sent to (.*)")]
        public void WhenISendPOSTRequest(string p0)
        {
            client = new RestClient(p0);
            response = (RestResponse)client.Post(request);
        }
        [AllureTag("CI")]
        [Then(@"The response should be (.*)")]
        public void ThenTheResponseShouldBe(string p0)
        {
            var res = response.StatusCode;
            Assert.True(res == System.Net.HttpStatusCode.OK, response.StatusCode.ToString());
        }
    }
}
