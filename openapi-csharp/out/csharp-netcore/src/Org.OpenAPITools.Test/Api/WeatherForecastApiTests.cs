/*
 * openapi-clients
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Xunit;

using Org.OpenAPITools.Client;
using Org.OpenAPITools.Api;
// uncomment below to import models
//using Org.OpenAPITools.Model;

namespace Org.OpenAPITools.Test.Api
{
    /// <summary>
    ///  Class for testing WeatherForecastApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class WeatherForecastApiTests : IDisposable
    {
        private WeatherForecastApi instance;

        public WeatherForecastApiTests()
        {
            instance = new WeatherForecastApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of WeatherForecastApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' WeatherForecastApi
            //Assert.IsType<WeatherForecastApi>(instance);
        }

        /// <summary>
        /// Test WeatherForecast
        /// </summary>
        [Fact]
        public void WeatherForecastTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.WeatherForecast();
            //Assert.IsType<Object>(response);
        }

        /// <summary>
        /// Test WeatherForecastForm
        /// </summary>
        [Fact]
        public void WeatherForecastFormTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string someString = null;
            //var response = instance.WeatherForecastForm(someString);
            //Assert.IsType<Object>(response);
        }

        /// <summary>
        /// Test WeatherForecastHeaderComplexType
        /// </summary>
        [Fact]
        public void WeatherForecastHeaderComplexTypeTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //KnownType payload = null;
            //var response = instance.WeatherForecastHeaderComplexType(payload);
            //Assert.IsType<Object>(response);
        }

        /// <summary>
        /// Test WeatherForecastHeaderComplexTypeRce
        /// </summary>
        [Fact]
        public void WeatherForecastHeaderComplexTypeRceTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //KnownTypeWithRce knownTypeWithRce = null;
            //var response = instance.WeatherForecastHeaderComplexTypeRce(knownTypeWithRce);
            //Assert.IsType<Object>(response);
        }

        /// <summary>
        /// Test WeatherForecastHeaderString
        /// </summary>
        [Fact]
        public void WeatherForecastHeaderStringTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string payload = null;
            //var response = instance.WeatherForecastHeaderString(payload);
            //Assert.IsType<Object>(response);
        }

        /// <summary>
        /// Test WeatherForecastPatch
        /// </summary>
        [Fact]
        public void WeatherForecastPatchTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //MyCustomOpIdRequest myCustomOpIdRequest = null;
            //var response = instance.WeatherForecastPatch(myCustomOpIdRequest);
            //Assert.IsType<AnimalOkObjectResult>(response);
        }

        /// <summary>
        /// Test WeatherForecastPost
        /// </summary>
        [Fact]
        public void WeatherForecastPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //KnownType knownType = null;
            //var response = instance.WeatherForecastPost(knownType);
            //Assert.IsType<Object>(response);
        }
    }
}