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
    public class _1UploadFileSteps
    {
        public static RestRequest request;
        public static RestClient client;
        public static RestResponse response;

        [Given(@"I have an (.*) i want to upload to (.*)")]
        public void GivenIHaveAnImageJpgIWantToUploadToWebAPIHometaskImage_Jpg(string name, string path)
        {
            Builder b = new Upload();
            Request rq = new Request(b);
            var headers = new List<Header> {
                new Header("Dropbox-API-Arg", "{\"path\":\"" + path + "\",\"mode\":\"add\"}"),
                new Header("Content-Type", "application/octet-stream"),
                };
            rq.Build(name, headers);
            request = b.Get();
        }
        [When(@"I send POST request to Dropbox (.*)")]
        public void WhenISendPOSTRequestToDropbox(string p0)
        {
            client = new RestClient(p0);
            response = (RestResponse)client.Post(request);
        }
        [AllureTag("CI")]
        [Then(@"I should get response (.*)")]
        public void ThenIShouldGetResponse(string p0)
        {
            var res = response.StatusCode;
            Assert.True(res == System.Net.HttpStatusCode.OK, response.StatusCode.ToString());
        }
    }
}
