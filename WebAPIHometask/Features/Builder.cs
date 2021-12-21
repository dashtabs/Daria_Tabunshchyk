using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebAPIHometask.Features
{
    static class Authorization
    {
        public static string Token = "Bearer k9Y7Chrd5uwAAAAAAAAAAYfeFjFnPjhcmyULUV8v1kgX2VFomMUDm2eNppr4onfO";
    }
    class Header
    {
        public string key { get; set; }
        public string value { get; set; }
        public Header(string k, string v)
        {
            key = k;
            value = v;
        }
    }
    abstract class Builder
    {
        public abstract void setAuth();
        public abstract void addBody(string path);
        public abstract void addHeaders(List<Header> h);
        public abstract RestRequest Get();
    }
    class Upload : Builder
    {
        public RestRequest request = new RestRequest();
        public override void setAuth()
        {
            request.AddHeader("Authorization", Authorization.Token);
        }
        public override void addBody(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            long fileLength = fileInfo.Length;
            request.AddHeader("Content-Length", fileLength.ToString());
            byte[] data = File.ReadAllBytes(path);
            var body = new Parameter("file", data, ParameterType.RequestBody);
            request.Parameters.Add(body);
        }
        public override void addHeaders(List<Header> h)
        {
            foreach (var header in h)
            {
                request.AddHeader(header.key, header.value);
            }
        }
        public override RestRequest Get()
        {
            return request;
        }
    }
    class GetMetaData : Builder
    {
        public RestRequest request = new RestRequest();
        public override void setAuth()
        {
            request.AddHeader("Authorization", Authorization.Token);
        }
        public override void addBody(string path)
        {
            request.AddJsonBody(new { file = path });
        }
        public override void addHeaders(List<Header> h)
        {
            foreach (var header in h)
            {
                request.AddHeader(header.key, header.value);
            }
        }
        public override RestRequest Get()
        {
            return request;
        }
    }
    class Delete : Builder
    {
        public RestRequest request = new RestRequest();
        public override void setAuth()
        {
            request.AddHeader("Authorization", Authorization.Token);
        }
        public override void addBody(string p)
        {
            request.AddJsonBody(new { path = p });
        }
        public override void addHeaders(List<Header> h)
        {
            foreach (var header in h)
            {
                request.AddHeader(header.key, header.value);
            }
        }
        public override RestRequest Get()
        {
            return request;
        }
    }
    class Request
    {
        public Builder builder;
        public Request(Builder rb)
        {
            this.builder = rb;
        }
        public RestRequest Build(string body, List<Header> headers)
        {
            builder.setAuth();
            builder.addBody(body);
            builder.addHeaders(headers);
            return builder.Get();
        }
    }
}
