/*
 * openapi-clients
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using FileParameter = Org.OpenAPITools.Client.FileParameter;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;
using OpenAPIClientUtils = Org.OpenAPITools.Client.ClientUtils;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// Cat
    /// </summary>
    [DataContract(Name = "Cat")]
    [JsonConverter(typeof(JsonSubtypes), "Discriminator")]
    [JsonSubtypes.KnownSubType(typeof(Cat), "Cat")]
    [JsonSubtypes.KnownSubType(typeof(Dog), "Dog")]
    [JsonSubtypes.KnownSubType(typeof(Wolf), "Wolf")]
    public partial class Cat : Animal, IEquatable<Cat>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cat" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Cat() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Cat" /> class.
        /// </summary>
        /// <param name="meow">Some meow description.</param>
        /// <param name="discriminator">discriminator (required) (default to &quot;Cat&quot;).</param>
        public Cat(string meow = default(string), string discriminator = "Cat") : base()
        {
            // to ensure "discriminator" is required (not null)
            if (discriminator == null)
            {
                throw new ArgumentNullException("discriminator is a required property for Cat and cannot be null");
            }
            this.Discriminator = discriminator;
            this.Meow = meow;
        }

        /// <summary>
        /// Some meow description
        /// </summary>
        /// <value>Some meow description</value>
        [DataMember(Name = "meow", EmitDefaultValue = true)]
        public string Meow { get; set; }

        /// <summary>
        /// Gets or Sets Discriminator
        /// </summary>
        [DataMember(Name = "discriminator", IsRequired = true, EmitDefaultValue = true)]
        public string Discriminator { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Cat {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Meow: ").Append(Meow).Append("\n");
            sb.Append("  Discriminator: ").Append(Discriminator).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return OpenAPIClientUtils.compareLogic.Compare(this, input as Cat).AreEqual;
        }

        /// <summary>
        /// Returns true if Cat instances are equal
        /// </summary>
        /// <param name="input">Instance of Cat to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Cat input)
        {
            return OpenAPIClientUtils.compareLogic.Compare(this, input).AreEqual;
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = base.GetHashCode();
                if (this.Meow != null)
                {
                    hashCode = (hashCode * 59) + this.Meow.GetHashCode();
                }
                if (this.Discriminator != null)
                {
                    hashCode = (hashCode * 59) + this.Discriminator.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            return this.BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            foreach (var x in base.BaseValidate(validationContext))
            {
                yield return x;
            }
            yield break;
        }
    }

}
