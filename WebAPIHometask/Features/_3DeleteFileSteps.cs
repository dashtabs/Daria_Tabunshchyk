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
    public class _3DeleteFileSteps
    {
        public static RestRequest request;
        public static RestClient client;
        public static RestResponse response;

        [Given(@"There is a (.*) on Dropbox")]
        public void GivenThereIsImageOnDropbox(string path)
        {
            Builder b = new Delete();
            Request rq = new Request(b);
            var headers = new List<Header> {
                new Header("Content-Type", "application/json"),
                };
            rq.Build(path, headers);
            request = b.Get();
        }
        
        [When(@"I send a POST request to (.*)")]
        public void WhenISendAPOSTRequest(string where)
        {
            client = new RestClient(where);
            response = (RestResponse)client.Post(request);
        }
        [AllureTag("CI")]
        [Then(@"The response must be (.*)")]
        public void ThenTheResponseMustBeOK(string p0)
        {
            var res = response.StatusCode;
            Assert.True(res == System.Net.HttpStatusCode.OK, response.StatusCode.ToString());
        }
    }
}
