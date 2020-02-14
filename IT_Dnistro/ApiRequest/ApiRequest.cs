using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using ApiRequest.Enumerations;
using Microsoft.Extensions.Configuration;
//using AspNet.Security.OAuth.Intita;

namespace ApiRequest
{
    public class ApiRequest<TResponse>
    {
        private string _requestUri;
        private string _requestBody;
        private string _token;
        private RequestType _httpMethod;
        private ContentTypes _contentType = ContentTypes.ApplicationJson;
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();
        private AuthenticationConfig _authenticationConfig;

        public IConfiguration Configuration { get; set; }
        
        public ApiResponse<TResponse> Send()
        {
            ValidateForSend();
            
            var response = new ApiResponse<TResponse>();
            var httpRequest = (HttpWebRequest)WebRequest.Create(_requestUri);
                
            httpRequest.Method = _httpMethod.ToString().ToUpper();

            if (_httpMethod == RequestType.Get)
            {
                httpRequest.ContentType = _contentType.GetDisplayText();
                if (_requestBody != null)
                {
                    var requestData = Encoding.ASCII.GetBytes(_requestBody);
                    var requestDataLength = requestData.Length;

                    using (var stream = httpRequest.GetRequestStream())
                    {
                        stream.Write(requestData, 0, requestDataLength);
                    }
                }
                else
                {
                    httpRequest.ContentLength = 0;
                }

                if (_authenticationConfig != null)
                {
                    _headers.Add("Authorization", GetAccessToken());
                }

                foreach (var header in _headers)
                {
                    httpRequest.Headers.Add(header.Key, header.Value);
                }

                string responseString = string.Empty;

                try
                {
                    var webResponse = (HttpWebResponse) httpRequest.GetResponse();

                    using (var streamReader =
                        new StreamReader(webResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                    {
                        responseString = streamReader.ReadToEnd();
                    }

                    response.ContentAsString = responseString;
                    response.StatusCode = int.Parse(webResponse.StatusCode.ToString("D"));
                    response.Response = JsonConvert.DeserializeObject<TResponse>(responseString);
                    response.IsDeserializeSuccess = response.Response != null;
                }
                catch (WebException ex)
                {
                    Console.WriteLine("Error, please check 'AccessToken' in appsettings.json.");
                    Console.WriteLine($"ResponseString: {responseString}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error, please check 'AccessToken' in appsettings.json.");
                    Console.WriteLine($"ResponseString: {responseString}");
                }
            }
            
            return response;
        }

        private string GetAccessToken()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            return $"Bearer {_token ?? Configuration["AccessToken"]}";
            //return Configuration["AccessToken"];
        }

        public ApiRequest<TResponse> Authenticate(AuthenticationConfig config)
        {
            _authenticationConfig = config.Copy();
            return this;
        }

        public ApiRequest<TResponse> Authenticate()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            _authenticationConfig = new AuthenticationConfig()
            {
                AuthUrl = Configuration["AuthUrl"],
                TokenUrl = Configuration["TokenUrl"],
                ClientId = Configuration["ClientId"],
                ClientSecret = Configuration["ClientSecret"]
            };
            
            return this;
        }

        public ApiRequest<TResponse> Authenticate(String token)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            _authenticationConfig = new AuthenticationConfig()
            {
                AuthUrl = Configuration["AuthUrl"],
                TokenUrl = Configuration["TokenUrl"],
                ClientId = Configuration["ClientId"],
                ClientSecret = Configuration["ClientSecret"]
            };
            _token = token;
            return this;
        }

        private void ValidateForSend()
        {
            string validationError = String.Empty;
            if (_requestUri == String.Empty)
            {
                validationError += "Url is empty. ";
            }
            if (_httpMethod == RequestType.Post && _requestBody == null)
            {
                validationError += "Body is empty. ";
            }
            if (validationError != String.Empty)
            {
                throw new ValidationException(validationError);
            }
        }

        public string GetHeaders()
        {
            var result = String.Empty;
            foreach (var header in _headers)
            {
                if (header.Key == "Authorization")
                    continue;

                result += $"{header.Key} {header.Value}{Environment.NewLine}";
            }
            return result;
        }

        public ApiRequest<TResponse> AddHeader(string name, string value)
        {
            _headers.Add(name, value);
            return this;
        }

        public ApiRequest<TResponse> ContentType(ContentTypes type)
        {
            _contentType = type;
            return this;
        }

        public ApiRequest<TResponse> Body(string jsonString)
        {
            _requestBody = jsonString;
            return this;
        }

        public ApiRequest<TResponse> Body(object o)
        {
            _requestBody = JsonConvert.SerializeObject(o);
            return this;
        }

        public ApiRequest<TResponse> Url(string url)
        {
            _requestUri = url;
            return this;
        }

        public ApiRequest<TResponse> Get()
        {
            _httpMethod = RequestType.Get;
            return this;
        }

        public ApiRequest<TResponse> Delete()
        {
            _httpMethod = RequestType.Delete;
            return this;
        }

        public ApiRequest<TResponse> Post()
        {
            _httpMethod = RequestType.Post;
            return this;
        }

        public ApiRequest<TResponse> Put()
        {
            _httpMethod = RequestType.Put;
            return this;
        }
    }
}
