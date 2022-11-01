# Org.OpenAPITools.Api.InheritanceApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**MyCustomOpId**](InheritanceApi.md#mycustomopid) | **POST** /WeatherForecast/Inheritance | Inheritance sample |

<a name="mycustomopid"></a>
# **MyCustomOpId**
> AnimalOkObjectResult MyCustomOpId (MyCustomOpIdRequest myCustomOpIdRequest = null)

Inheritance sample

Some longer explaination

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class MyCustomOpIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new InheritanceApi(httpClient, config, httpClientHandler);
            var myCustomOpIdRequest = new MyCustomOpIdRequest(); // MyCustomOpIdRequest |  (optional) 

            try
            {
                // Inheritance sample
                AnimalOkObjectResult result = apiInstance.MyCustomOpId(myCustomOpIdRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InheritanceApi.MyCustomOpId: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the MyCustomOpIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Inheritance sample
    ApiResponse<AnimalOkObjectResult> response = apiInstance.MyCustomOpIdWithHttpInfo(myCustomOpIdRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InheritanceApi.MyCustomOpIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **myCustomOpIdRequest** | [**MyCustomOpIdRequest**](MyCustomOpIdRequest.md) |  | [optional]  |

### Return type

[**AnimalOkObjectResult**](AnimalOkObjectResult.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

