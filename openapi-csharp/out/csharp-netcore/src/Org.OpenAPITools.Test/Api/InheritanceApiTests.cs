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
    ///  Class for testing InheritanceApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class InheritanceApiTests : IDisposable
    {
        private InheritanceApi instance;

        public InheritanceApiTests()
        {
            instance = new InheritanceApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of InheritanceApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' InheritanceApi
            //Assert.IsType<InheritanceApi>(instance);
        }

        /// <summary>
        /// Test MyCustomOpId
        /// </summary>
        [Fact]
        public void MyCustomOpIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //MyCustomOpIdRequest myCustomOpIdRequest = null;
            //var response = instance.MyCustomOpId(myCustomOpIdRequest);
            //Assert.IsType<AnimalOkObjectResult>(response);
        }
    }
}
