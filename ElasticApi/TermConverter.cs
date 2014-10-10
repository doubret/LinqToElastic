namespace ElasticApi
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using ElasticApi.Types;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
	
    public class PrefixDefinition
    {
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortDirection
    {
        [EnumMember(Value ="asc")]
        Ascending,
        [EnumMember(Value = "desc")]
        Descending,
    }

    [JsonConverter(typeof(CustomConverter))]
    public class Sort : ICustomSerialization
    {
        public string Field { get; set; }
        public SortDirection Direction { get; set; }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(this.Field);
            serializer.Serialize(writer, this.Direction);
            writer.WriteEndObject();
        }
    }

    public class BoolDefinition
    {
        [JsonProperty("must", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IEnumerable<Query> Must { get; set; }

        [JsonProperty("should", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IEnumerable<Query> Should { get; set; }

        [JsonProperty("must_not", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IEnumerable<Query> MustNot { get; set; }
    }

    public interface ICustomSerialization
    {
        void WriteJson(JsonWriter writer, JsonSerializer serializer);
    }

    public abstract class TermDefinition
    {
    }

    [JsonConverter(typeof(CustomConverter))]
    public class TermDefinition<T> : TermDefinition, ICustomSerialization
    {
        public string Name { get; set; }
        public T Value { get; set; }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(this.Name);
            serializer.Serialize(writer, this.Value);
            writer.WriteEndObject();
        }
    }

	public class RangeCriteria
	{
        [JsonProperty("gt", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public object Greater { get; set; }

		[JsonProperty("gte", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public object GreaterOrEqual { get; set; }

		[JsonProperty("lt", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public object Smaller { get; set; }

		[JsonProperty("lte", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public object SmallerOrEqual { get; set; }
	}

    [JsonConverter(typeof(CustomConverter))]
    public class RangeDefinition : ICustomSerialization
    {
        public string Field { get; set; }
        public RangeCriteria Criteria { get; set; }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(this.Field);
            serializer.Serialize(writer, this.Criteria);
            writer.WriteEndObject();
        }
    }


    [JsonConverter(typeof(CustomConverter))]
    public class TermsDefinition : ICustomSerialization
    {
        public string Name { get; set; }
        public object Value { get; set; }

        [JsonProperty("execution", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Execution { get; set; }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(this.Name);

            serializer.Serialize(writer, this.Value);

            if (this.Execution != null)
            {
                writer.WritePropertyName("execution");
                writer.WriteValue(this.Execution);
            }

            writer.WriteEndObject();
        }
    }

    class CustomConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ICustomSerialization custom = value as ICustomSerialization;

            custom.WriteJson(writer, serializer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // TODO...
            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
