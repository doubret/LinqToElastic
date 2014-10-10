//	API TYPES

namespace ElasticApi.Types
{
	using System;
	using System.Collections.Generic;

	[Newtonsoft.Json.JsonObject("alias_action")]
	public class AliasAction 
	{
	}
	[Newtonsoft.Json.JsonObject("add")]
	public class AddAliasAction : AliasAction 
	{
	}
	[Newtonsoft.Json.JsonObject("remove")]
	public class RemoveAliasAction : AliasAction 
	{
	}
	[Newtonsoft.Json.JsonObject("cluster_health")]
	public class ClusterHealth 
	{
		[Newtonsoft.Json.JsonProperty("cluster_name", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ClusterName { get; set; }
		[Newtonsoft.Json.JsonProperty("status", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Status { get; set; }
		[Newtonsoft.Json.JsonProperty("timed_out", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public bool TimedOut { get; set; }
		[Newtonsoft.Json.JsonProperty("number_of_nodes", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long NumberOfNodes { get; set; }
		[Newtonsoft.Json.JsonProperty("number_of_data_nodes", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long NumberOfDataNodes { get; set; }
		[Newtonsoft.Json.JsonProperty("active_primary_shards", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long ActivePrimaryShards { get; set; }
		[Newtonsoft.Json.JsonProperty("active_shards", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long ActiveShards { get; set; }
		[Newtonsoft.Json.JsonProperty("relocating_shards", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long RelocatingShards { get; set; }
		[Newtonsoft.Json.JsonProperty("initializing_shards", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long InitializingShards { get; set; }
		[Newtonsoft.Json.JsonProperty("unassigned_shards", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long UnassignedShards { get; set; }
		[Newtonsoft.Json.JsonProperty("indices", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Dictionary<string, IndexHealth> Indices { get; set; }
	}
	[Newtonsoft.Json.JsonObject("index_health")]
	public class IndexHealth 
	{
		[Newtonsoft.Json.JsonProperty("status", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Status { get; set; }
		[Newtonsoft.Json.JsonProperty("number_of_shards", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long NumberOfShards { get; set; }
		[Newtonsoft.Json.JsonProperty("number_of_replicas", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long NumberOfReplicas { get; set; }
		[Newtonsoft.Json.JsonProperty("active_primary_shards", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long ActivePrimaryShards { get; set; }
		[Newtonsoft.Json.JsonProperty("active_shards", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long ActiveShards { get; set; }
		[Newtonsoft.Json.JsonProperty("relocating_shards", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long RelocatingShards { get; set; }
		[Newtonsoft.Json.JsonProperty("initializing_shards", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long InitializingShards { get; set; }
		[Newtonsoft.Json.JsonProperty("unassigned_shards", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long UnassignedShards { get; set; }
		[Newtonsoft.Json.JsonProperty("shards", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Dictionary<string, ShardHealth> Shards { get; set; }
	}
	[Newtonsoft.Json.JsonObject("shard_health")]
	public class ShardHealth 
	{
		[Newtonsoft.Json.JsonProperty("status", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Status { get; set; }
		[Newtonsoft.Json.JsonProperty("primary_active", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public bool PrimaryActive { get; set; }
		[Newtonsoft.Json.JsonProperty("active_shards", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long ActiveShards { get; set; }
		[Newtonsoft.Json.JsonProperty("relocating_shards", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long RelocatingShards { get; set; }
		[Newtonsoft.Json.JsonProperty("initializing_shards", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long InitializingShards { get; set; }
		[Newtonsoft.Json.JsonProperty("unassigned_shards", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long UnassignedShards { get; set; }
	}
	[Newtonsoft.Json.JsonObject("index_alias")]
	public class IndexAlias 
	{
		[Newtonsoft.Json.JsonProperty("index_routing", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long IndexRouting { get; set; }
		[Newtonsoft.Json.JsonProperty("search_routing", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long SearchRouting { get; set; }
	}
	[Newtonsoft.Json.JsonObject("index_aliases")]
	public class IndexAliases 
	{
		[Newtonsoft.Json.JsonProperty("aliases", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Dictionary<string, IndexAlias> Aliases { get; set; }
	}
	[Newtonsoft.Json.JsonObject("acknowledged_response")]
	public class AcknowledgedResponse 
	{
		[Newtonsoft.Json.JsonProperty("acknowledged", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public bool Acknowledged { get; set; }
	}
	[Newtonsoft.Json.JsonObject("task")]
	public class Task 
	{
		[Newtonsoft.Json.JsonProperty("insert_order", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long InsertOrder { get; set; }
		[Newtonsoft.Json.JsonProperty("priority", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Priority { get; set; }
		[Newtonsoft.Json.JsonProperty("source", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Source { get; set; }
		[Newtonsoft.Json.JsonProperty("time_in_queue_millis", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long TimeInQueueMillis { get; set; }
		[Newtonsoft.Json.JsonProperty("time_in_queue", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string TimeInQueue { get; set; }
	}
	[Newtonsoft.Json.JsonObject("pending_tasks_response")]
	public class PendingTasksResponse 
	{
		[Newtonsoft.Json.JsonProperty("tasks", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<Task> Tasks { get; set; }
	}
	[Newtonsoft.Json.JsonObject("get_document_response")]
	public class GetDocumentResponse 
	{
		[Newtonsoft.Json.JsonProperty("_index", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Index { get; set; }
		[Newtonsoft.Json.JsonProperty("_type", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Type { get; set; }
		[Newtonsoft.Json.JsonProperty("_id", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Id { get; set; }
		[Newtonsoft.Json.JsonProperty("_version", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long Version { get; set; }
		[Newtonsoft.Json.JsonProperty("found", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public bool Found { get; set; }
		[Newtonsoft.Json.JsonProperty("_source", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Object Source { get; set; }
	}
	[Newtonsoft.Json.JsonObject("index_document_response")]
	public class IndexDocumentResponse 
	{
		[Newtonsoft.Json.JsonProperty("_index", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Index { get; set; }
		[Newtonsoft.Json.JsonProperty("_type", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Type { get; set; }
		[Newtonsoft.Json.JsonProperty("_id", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Id { get; set; }
		[Newtonsoft.Json.JsonProperty("_version", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long Version { get; set; }
		[Newtonsoft.Json.JsonProperty("created", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public bool Created { get; set; }
	}
	[Newtonsoft.Json.JsonObject("delete_document_response")]
	public class DeleteDocumentResponse 
	{
		[Newtonsoft.Json.JsonProperty("_index", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Index { get; set; }
		[Newtonsoft.Json.JsonProperty("_type", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Type { get; set; }
		[Newtonsoft.Json.JsonProperty("_id", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Id { get; set; }
		[Newtonsoft.Json.JsonProperty("_version", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long Version { get; set; }
		[Newtonsoft.Json.JsonProperty("found", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public bool Found { get; set; }
	}
	[Newtonsoft.Json.JsonObject("create_alias_body")]
	public class CreateAliasBody 
	{
		[Newtonsoft.Json.JsonProperty("routing", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Routing { get; set; }
		[Newtonsoft.Json.JsonProperty("filter", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Filter { get; set; }
	}
	[Newtonsoft.Json.JsonObject("update_document_body")]
	public class UpdateDocumentBody 
	{
		[Newtonsoft.Json.JsonProperty("doc", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Object Doc { get; set; }
		[Newtonsoft.Json.JsonProperty("body_script", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string BodyScript { get; set; }
	}
	[Newtonsoft.Json.JsonObject("search_body")]
	public class SearchBody 
	{
		[Newtonsoft.Json.JsonProperty("query", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public FilteredQuery Query { get; set; }
		[Newtonsoft.Json.JsonProperty("filter", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Filter Filter { get; set; }
		[Newtonsoft.Json.JsonProperty("from", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long From { get; set; }
		[Newtonsoft.Json.JsonProperty("size", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long Size { get; set; }
		[Newtonsoft.Json.JsonProperty("sort", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<Sort> Sort { get; set; }
		[Newtonsoft.Json.JsonProperty("fields", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<string> Fields { get; set; }
	}
	[Newtonsoft.Json.JsonObject("empty_response")]
	public class EmptyResponse 
	{
	}
	[Newtonsoft.Json.JsonObject("query")]
	public class Query 
	{
	}
	[Newtonsoft.Json.JsonObject("match_all_definition")]
	public class MatchAllDefinition 
	{
		[Newtonsoft.Json.JsonProperty("boost", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public long Boost { get; set; }
	}
	[Newtonsoft.Json.JsonObject("match_all")]
	public class MatchAllQuery : Query 
	{
		[Newtonsoft.Json.JsonProperty("match_all", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public MatchAllDefinition MatchAll { get; set; }
	}
	[Newtonsoft.Json.JsonObject("term")]
	public class TermQuery : Query 
	{
		[Newtonsoft.Json.JsonProperty("term", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public TermDefinition Term { get; set; }
	}
	[Newtonsoft.Json.JsonObject("terms")]
	public class TermsQuery : Query 
	{
		[Newtonsoft.Json.JsonProperty("terms", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public TermsDefinition Terms { get; set; }
	}
	[Newtonsoft.Json.JsonObject("filtered_definition")]
	public class FilteredDefinition 
	{
		[Newtonsoft.Json.JsonProperty("query", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public FilteredQuery Query { get; set; }
		[Newtonsoft.Json.JsonProperty("filter", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Filter Filter { get; set; }
	}
	[Newtonsoft.Json.JsonObject("filtered")]
	public class FilteredQuery : Query 
	{
		[Newtonsoft.Json.JsonProperty("filtered", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public FilteredDefinition Filtered { get; set; }
	}
	[Newtonsoft.Json.JsonObject("bool")]
	public class BoolQuery : Query 
	{
		[Newtonsoft.Json.JsonProperty("bool", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public BoolDefinition Bool { get; set; }
	}
	[Newtonsoft.Json.JsonObject("filter")]
	public class Filter 
	{
	}
	[Newtonsoft.Json.JsonObject("term")]
	public class TermFilter : Filter 
	{
		[Newtonsoft.Json.JsonProperty("term", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public TermDefinition Term { get; set; }
	}
	[Newtonsoft.Json.JsonObject("terms")]
	public class TermsFilter : Filter 
	{
		[Newtonsoft.Json.JsonProperty("terms", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public TermsDefinition Terms { get; set; }
	}
	[Newtonsoft.Json.JsonObject("and")]
	public class AndFilter : Filter 
	{
		[Newtonsoft.Json.JsonProperty("and", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<Filter> And { get; set; }
	}
	[Newtonsoft.Json.JsonObject("or")]
	public class OrFilter : Filter 
	{
		[Newtonsoft.Json.JsonProperty("or", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public List<Filter> Or { get; set; }
	}
	[Newtonsoft.Json.JsonObject("not")]
	public class NotFilter : Filter 
	{
		[Newtonsoft.Json.JsonProperty("not", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Filter Not { get; set; }
	}
	[Newtonsoft.Json.JsonObject("range")]
	public class RangeFilter : Filter 
	{
		[Newtonsoft.Json.JsonProperty("range", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public RangeDefinition Range { get; set; }
	}
	[Newtonsoft.Json.JsonObject("prefix")]
	public class PrefixFilter : Filter 
	{
		[Newtonsoft.Json.JsonProperty("prefix", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public PrefixDefinition Prefix { get; set; }
	}
	[Newtonsoft.Json.JsonObject("exists_definition")]
	public class ExistsDefinition 
	{
		[Newtonsoft.Json.JsonProperty("field", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Field { get; set; }
	}
	[Newtonsoft.Json.JsonObject("exists")]
	public class ExistsFilter : Filter 
	{
		[Newtonsoft.Json.JsonProperty("exists", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public ExistsDefinition Exists { get; set; }
	}
	[Newtonsoft.Json.JsonObject("missing_definition")]
	public class MissingDefinition 
	{
		[Newtonsoft.Json.JsonProperty("field", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Field { get; set; }
	}
	[Newtonsoft.Json.JsonObject("missing")]
	public class MissingFilter : Filter 
	{
		[Newtonsoft.Json.JsonProperty("missing", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public MissingDefinition Missing { get; set; }
	}
}

//	API REQUESTS

namespace ElasticApi.Requests
{
	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
	using Types;
	public class GetAliasRequest
	{
		[JsonIgnore]
		public string Index { get; set; }
		[JsonIgnore]
		public string Alias { get; set; }
		[JsonIgnore]
		public Nullable<bool> IgnoreUnavailable { get; set; }
	}
	public class AliasExistsRequest
	{
		[JsonIgnore]
		public string Index { get; set; }
		[JsonIgnore]
		public string Alias { get; set; }
	}
	public class PutAliasRequest
	{
		[JsonIgnore]
		public string Index { get; set; }
		[JsonIgnore]
		public string Alias { get; set; }
		[JsonIgnore]
		public CreateAliasBody Body { get; set; }
	}
	public class PostAliasRequest
	{
		[JsonIgnore]
		public string Index { get; set; }
		[JsonIgnore]
		public string Alias { get; set; }
		[JsonIgnore]
		public CreateAliasBody Body { get; set; }
	}
	public class DeleteAliasRequest
	{
		[JsonIgnore]
		public string Index { get; set; }
		[JsonIgnore]
		public string Alias { get; set; }
	}
	public class ClusterHealthRequest
	{
		[JsonIgnore]
		public string Index { get; set; }
		[JsonIgnore]
		public string Level { get; set; }
		[JsonIgnore]
		public Nullable<bool> Local { get; set; }
		[JsonIgnore]
		public Nullable<TimeSpan> MasterTimeout { get; set; }
		[JsonIgnore]
		public Nullable<TimeSpan> Timeout { get; set; }
		[JsonIgnore]
		public Nullable<long> WaitForActiveShards { get; set; }
		[JsonIgnore]
		public string WaitForNodes { get; set; }
		[JsonIgnore]
		public Nullable<long> WaitForRelocatingShards { get; set; }
		[JsonIgnore]
		public string WaitForStatus { get; set; }
	}
	public class ClusterStateRequest
	{
		[JsonIgnore]
		public string Index { get; set; }
		[JsonIgnore]
		public string Metrics { get; set; }
		[JsonIgnore]
		public Nullable<bool> Local { get; set; }
		[JsonIgnore]
		public Nullable<TimeSpan> MasterTimeout { get; set; }
		[JsonIgnore]
		public Nullable<bool> FlatSettings { get; set; }
	}
	public class ClusterStatsRequest
	{
		[JsonIgnore]
		public Nullable<bool> FlatSettings { get; set; }
	}
	public class ClusterStatsNodeRequest
	{
		[JsonIgnore]
		public string NodeId { get; set; }
		[JsonIgnore]
		public Nullable<bool> FlatSettings { get; set; }
	}
	public class ClusterPendingTasksRequest
	{
		[JsonIgnore]
		public Nullable<bool> Local { get; set; }
		[JsonIgnore]
		public Nullable<TimeSpan> MasterTimeout { get; set; }
	}
	public class GetDocumentRequest
	{
		[JsonIgnore]
		public string Id { get; set; }
		[JsonIgnore]
		public string Index { get; set; }
		[JsonIgnore]
		public string Type { get; set; }
		[JsonIgnore]
		public List<string> Fields { get; set; }
		[JsonIgnore]
		public string Parent { get; set; }
		[JsonIgnore]
		public string Preference { get; set; }
		[JsonIgnore]
		public Nullable<bool> Realtime { get; set; }
		[JsonIgnore]
		public Nullable<bool> Refresh { get; set; }
		[JsonIgnore]
		public string Routing { get; set; }
		[JsonIgnore]
		public List<string> Source { get; set; }
		[JsonIgnore]
		public List<string> SourceExclude { get; set; }
		[JsonIgnore]
		public List<string> SourceInclude { get; set; }
		[JsonIgnore]
		public Nullable<long> Version { get; set; }
		[JsonIgnore]
		public string VersionType { get; set; }
	}
	public class PutDocumentRequest
	{
		[JsonIgnore]
		public string Id { get; set; }
		[JsonIgnore]
		public string Index { get; set; }
		[JsonIgnore]
		public string Type { get; set; }
		[JsonIgnore]
		public string Consistency { get; set; }
		[JsonIgnore]
		public string OpType { get; set; }
		[JsonIgnore]
		public string Parent { get; set; }
		[JsonIgnore]
		public Nullable<bool> Refresh { get; set; }
		[JsonIgnore]
		public string Replication { get; set; }
		[JsonIgnore]
		public string Routing { get; set; }
		[JsonIgnore]
		public Nullable<TimeSpan> Timeout { get; set; }
		[JsonIgnore]
		public Nullable<TimeSpan> Timestamp { get; set; }
		[JsonIgnore]
		public Nullable<TimeSpan> Ttl { get; set; }
		[JsonIgnore]
		public Nullable<long> Version { get; set; }
		[JsonIgnore]
		public string VersionType { get; set; }
		[JsonIgnore]
		public Object Body { get; set; }
	}
	public class PostDocumentRequest
	{
		[JsonIgnore]
		public string Index { get; set; }
		[JsonIgnore]
		public string Type { get; set; }
		[JsonIgnore]
		public string Consistency { get; set; }
		[JsonIgnore]
		public string OpType { get; set; }
		[JsonIgnore]
		public string Parent { get; set; }
		[JsonIgnore]
		public Nullable<bool> Refresh { get; set; }
		[JsonIgnore]
		public string Replication { get; set; }
		[JsonIgnore]
		public string Routing { get; set; }
		[JsonIgnore]
		public Nullable<TimeSpan> Timeout { get; set; }
		[JsonIgnore]
		public Nullable<TimeSpan> Timestamp { get; set; }
		[JsonIgnore]
		public Nullable<TimeSpan> Ttl { get; set; }
		[JsonIgnore]
		public Nullable<long> Version { get; set; }
		[JsonIgnore]
		public string VersionType { get; set; }
		[JsonIgnore]
		public Object Body { get; set; }
	}
	public class DeleteDocumentRequest
	{
		[JsonIgnore]
		public string Id { get; set; }
		[JsonIgnore]
		public string Index { get; set; }
		[JsonIgnore]
		public string Type { get; set; }
		[JsonIgnore]
		public string Consistency { get; set; }
		[JsonIgnore]
		public string Parent { get; set; }
		[JsonIgnore]
		public Nullable<bool> Refresh { get; set; }
		[JsonIgnore]
		public string Replication { get; set; }
		[JsonIgnore]
		public string Routing { get; set; }
		[JsonIgnore]
		public Nullable<TimeSpan> Timeout { get; set; }
		[JsonIgnore]
		public Nullable<long> Version { get; set; }
		[JsonIgnore]
		public string VersionType { get; set; }
	}
	public class UpdateDocumentRequest
	{
		[JsonIgnore]
		public string Id { get; set; }
		[JsonIgnore]
		public string Index { get; set; }
		[JsonIgnore]
		public string Type { get; set; }
		[JsonIgnore]
		public string Consistency { get; set; }
		[JsonIgnore]
		public IEnumerable<string> Fields { get; set; }
		[JsonIgnore]
		public string Lang { get; set; }
		[JsonIgnore]
		public string Parent { get; set; }
		[JsonIgnore]
		public Nullable<bool> Refresh { get; set; }
		[JsonIgnore]
		public string Replication { get; set; }
		[JsonIgnore]
		public Nullable<long> RetryOnConflict { get; set; }
		[JsonIgnore]
		public string Routing { get; set; }
		[JsonIgnore]
		public string Script { get; set; }
		[JsonIgnore]
		public Nullable<long> ScriptId { get; set; }
		[JsonIgnore]
		public Nullable<bool> ScriptedUpsert { get; set; }
		[JsonIgnore]
		public Nullable<TimeSpan> Timeout { get; set; }
		[JsonIgnore]
		public Nullable<TimeSpan> Timestamp { get; set; }
		[JsonIgnore]
		public Nullable<TimeSpan> Ttl { get; set; }
		[JsonIgnore]
		public Nullable<long> Version { get; set; }
		[JsonIgnore]
		public string VersionType { get; set; }
		[JsonIgnore]
		public UpdateDocumentBody Body { get; set; }
	}
	public class PostSearchRequest
	{
		[JsonIgnore]
		public string Index { get; set; }
		[JsonIgnore]
		public string Type { get; set; }
		[JsonIgnore]
		public SearchBody Body { get; set; }
	}
}

//	API METHODS

namespace ElasticApi
{
    using System;
    using System.Collections.Generic;
    using Types;
    using Requests;

	public static partial class Elastic
	{
		public static Dictionary<string, IndexAliases> GetAlias(IConnection connection, GetAliasRequest request)
		{
			IEnumerable<string> path = Routing.GetPath(request);
			IDictionary<string, object> parameters = Routing.GetParameters(request);
			return connection.Get<Dictionary<string, IndexAliases>>(path, parameters);
		}
		public static EmptyResponse AliasExists(IConnection connection, AliasExistsRequest request)
		{
			IEnumerable<string> path = Routing.GetPath(request);
			IDictionary<string, object> parameters = Routing.GetParameters(request);
			return connection.Head<EmptyResponse>(path, parameters);
		}
		public static AcknowledgedResponse PutAlias(IConnection connection, PutAliasRequest request)
		{
			IEnumerable<string> path = Routing.GetPath(request);
			IDictionary<string, object> parameters = Routing.GetParameters(request);
			return connection.Put<AcknowledgedResponse>(path, parameters, request.Body);
		}
		public static AcknowledgedResponse PostAlias(IConnection connection, PostAliasRequest request)
		{
			IEnumerable<string> path = Routing.GetPath(request);
			IDictionary<string, object> parameters = Routing.GetParameters(request);
			return connection.Post<AcknowledgedResponse>(path, parameters, request.Body);
		}
		public static AcknowledgedResponse DeleteAlias(IConnection connection, DeleteAliasRequest request)
		{
			IEnumerable<string> path = Routing.GetPath(request);
			IDictionary<string, object> parameters = Routing.GetParameters(request);
			return connection.Delete<AcknowledgedResponse>(path, parameters);
		}
		public static ClusterHealth ClusterHealth(IConnection connection, ClusterHealthRequest request)
		{
			IEnumerable<string> path = Routing.GetPath(request);
			IDictionary<string, object> parameters = Routing.GetParameters(request);
			return connection.Get<ClusterHealth>(path, parameters);
		}
		public static EmptyResponse ClusterState(IConnection connection, ClusterStateRequest request)
		{
			IEnumerable<string> path = Routing.GetPath(request);
			IDictionary<string, object> parameters = Routing.GetParameters(request);
			return connection.Get<EmptyResponse>(path, parameters);
		}
		public static EmptyResponse ClusterStats(IConnection connection, ClusterStatsRequest request)
		{
			IEnumerable<string> path = Routing.GetPath(request);
			IDictionary<string, object> parameters = Routing.GetParameters(request);
			return connection.Get<EmptyResponse>(path, parameters);
		}
		public static EmptyResponse ClusterStatsNode(IConnection connection, ClusterStatsNodeRequest request)
		{
			IEnumerable<string> path = Routing.GetPath(request);
			IDictionary<string, object> parameters = Routing.GetParameters(request);
			return connection.Get<EmptyResponse>(path, parameters);
		}
		public static PendingTasksResponse ClusterPendingTasks(IConnection connection, ClusterPendingTasksRequest request)
		{
			IEnumerable<string> path = Routing.GetPath(request);
			IDictionary<string, object> parameters = Routing.GetParameters(request);
			return connection.Get<PendingTasksResponse>(path, parameters);
		}
		public static GetDocumentResponse GetDocument(IConnection connection, GetDocumentRequest request)
		{
			IEnumerable<string> path = Routing.GetPath(request);
			IDictionary<string, object> parameters = Routing.GetParameters(request);
			return connection.Get<GetDocumentResponse>(path, parameters);
		}
		public static IndexDocumentResponse PutDocument(IConnection connection, PutDocumentRequest request)
		{
			IEnumerable<string> path = Routing.GetPath(request);
			IDictionary<string, object> parameters = Routing.GetParameters(request);
			return connection.Put<IndexDocumentResponse>(path, parameters, request.Body);
		}
		public static IndexDocumentResponse PostDocument(IConnection connection, PostDocumentRequest request)
		{
			IEnumerable<string> path = Routing.GetPath(request);
			IDictionary<string, object> parameters = Routing.GetParameters(request);
			return connection.Post<IndexDocumentResponse>(path, parameters, request.Body);
		}
		public static DeleteDocumentResponse DeleteDocument(IConnection connection, DeleteDocumentRequest request)
		{
			IEnumerable<string> path = Routing.GetPath(request);
			IDictionary<string, object> parameters = Routing.GetParameters(request);
			return connection.Delete<DeleteDocumentResponse>(path, parameters);
		}
		public static EmptyResponse UpdateDocument(IConnection connection, UpdateDocumentRequest request)
		{
			IEnumerable<string> path = Routing.GetPath(request);
			IDictionary<string, object> parameters = Routing.GetParameters(request);
			return connection.Post<EmptyResponse>(path, parameters, request.Body);
		}
		public static EmptyResponse PostSearch(IConnection connection, PostSearchRequest request)
		{
			IEnumerable<string> path = Routing.GetPath(request);
			IDictionary<string, object> parameters = Routing.GetParameters(request);
			return connection.Post<EmptyResponse>(path, parameters, request.Body);
		}
	}
}

//	API ROUTING

namespace ElasticApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Requests;

	public static partial class Routing
	{
		private static readonly Func<GetAliasRequest, string>[] GetAliasPaths = new Func<GetAliasRequest, string>[]
		{
			x => x.Index,
			x => "_alias",
			x => x.Alias,
		};
		public static IEnumerable<string> GetPath(GetAliasRequest request)
		{
			return GetAliasPaths.Select(x => x(request));
		}
		public static IDictionary<string, object> GetParameters(GetAliasRequest request)
		{
			var parameters = new Dictionary<string, object>();
			AddParameter(parameters, "ignore_unavailable", request.IgnoreUnavailable);
			AddCommonParameters(parameters);

			return parameters;
		}
		private static readonly Func<AliasExistsRequest, string>[] AliasExistsPaths = new Func<AliasExistsRequest, string>[]
		{
			x => x.Index,
			x => "_alias",
			x => x.Alias,
		};
		public static IEnumerable<string> GetPath(AliasExistsRequest request)
		{
			return AliasExistsPaths.Select(x => x(request));
		}
		public static IDictionary<string, object> GetParameters(AliasExistsRequest request)
		{
			var parameters = new Dictionary<string, object>();
			AddCommonParameters(parameters);

			return parameters;
		}
		private static readonly Func<PutAliasRequest, string>[] PutAliasPaths = new Func<PutAliasRequest, string>[]
		{
			x => x.Index,
			x => "_alias",
			x => x.Alias,
		};
		public static IEnumerable<string> GetPath(PutAliasRequest request)
		{
			return PutAliasPaths.Select(x => x(request));
		}
		public static IDictionary<string, object> GetParameters(PutAliasRequest request)
		{
			var parameters = new Dictionary<string, object>();
			AddCommonParameters(parameters);

			return parameters;
		}
		private static readonly Func<PostAliasRequest, string>[] PostAliasPaths = new Func<PostAliasRequest, string>[]
		{
			x => x.Index,
			x => "_alias",
			x => x.Alias,
		};
		public static IEnumerable<string> GetPath(PostAliasRequest request)
		{
			return PostAliasPaths.Select(x => x(request));
		}
		public static IDictionary<string, object> GetParameters(PostAliasRequest request)
		{
			var parameters = new Dictionary<string, object>();
			AddCommonParameters(parameters);

			return parameters;
		}
		private static readonly Func<DeleteAliasRequest, string>[] DeleteAliasPaths = new Func<DeleteAliasRequest, string>[]
		{
			x => x.Index,
			x => "_alias",
			x => x.Alias,
		};
		public static IEnumerable<string> GetPath(DeleteAliasRequest request)
		{
			return DeleteAliasPaths.Select(x => x(request));
		}
		public static IDictionary<string, object> GetParameters(DeleteAliasRequest request)
		{
			var parameters = new Dictionary<string, object>();
			AddCommonParameters(parameters);

			return parameters;
		}
		private static readonly Func<ClusterHealthRequest, string>[] ClusterHealthPaths = new Func<ClusterHealthRequest, string>[]
		{
			x => "_cluster",
			x => "health",
			x => x.Index,
		};
		public static IEnumerable<string> GetPath(ClusterHealthRequest request)
		{
			return ClusterHealthPaths.Select(x => x(request));
		}
		public static IDictionary<string, object> GetParameters(ClusterHealthRequest request)
		{
			var parameters = new Dictionary<string, object>();
			AddParameter(parameters, "level", request.Level);
			AddParameter(parameters, "local", request.Local);
			AddParameter(parameters, "master_timeout", request.MasterTimeout);
			AddParameter(parameters, "timeout", request.Timeout);
			AddParameter(parameters, "wait_for_active_shards", request.WaitForActiveShards);
			AddParameter(parameters, "wait_for_nodes", request.WaitForNodes);
			AddParameter(parameters, "wait_for_relocating_shards", request.WaitForRelocatingShards);
			AddParameter(parameters, "wait_for_status", request.WaitForStatus);
			AddCommonParameters(parameters);

			return parameters;
		}
		private static readonly Func<ClusterStateRequest, string>[] ClusterStatePaths = new Func<ClusterStateRequest, string>[]
		{
			x => "_cluster",
			x => "state",
			x => x.Metrics,
			x => x.Index,
		};
		public static IEnumerable<string> GetPath(ClusterStateRequest request)
		{
			return ClusterStatePaths.Select(x => x(request));
		}
		public static IDictionary<string, object> GetParameters(ClusterStateRequest request)
		{
			var parameters = new Dictionary<string, object>();
			AddParameter(parameters, "local", request.Local);
			AddParameter(parameters, "master_timeout", request.MasterTimeout);
			AddParameter(parameters, "flat_settings", request.FlatSettings);
			AddCommonParameters(parameters);

			return parameters;
		}
		private static readonly Func<ClusterStatsRequest, string>[] ClusterStatsPaths = new Func<ClusterStatsRequest, string>[]
		{
			x => "_cluster",
			x => "stats",
		};
		public static IEnumerable<string> GetPath(ClusterStatsRequest request)
		{
			return ClusterStatsPaths.Select(x => x(request));
		}
		public static IDictionary<string, object> GetParameters(ClusterStatsRequest request)
		{
			var parameters = new Dictionary<string, object>();
			AddParameter(parameters, "flat_settings", request.FlatSettings);
			AddCommonParameters(parameters);

			return parameters;
		}
		private static readonly Func<ClusterStatsNodeRequest, string>[] ClusterStatsNodePaths = new Func<ClusterStatsNodeRequest, string>[]
		{
			x => "_cluster",
			x => "stats",
			x => "nodes",
			x => x.NodeId,
		};
		public static IEnumerable<string> GetPath(ClusterStatsNodeRequest request)
		{
			return ClusterStatsNodePaths.Select(x => x(request));
		}
		public static IDictionary<string, object> GetParameters(ClusterStatsNodeRequest request)
		{
			var parameters = new Dictionary<string, object>();
			AddParameter(parameters, "flat_settings", request.FlatSettings);
			AddCommonParameters(parameters);

			return parameters;
		}
		private static readonly Func<ClusterPendingTasksRequest, string>[] ClusterPendingTasksPaths = new Func<ClusterPendingTasksRequest, string>[]
		{
			x => "_cluster",
			x => "pending_tasks",
		};
		public static IEnumerable<string> GetPath(ClusterPendingTasksRequest request)
		{
			return ClusterPendingTasksPaths.Select(x => x(request));
		}
		public static IDictionary<string, object> GetParameters(ClusterPendingTasksRequest request)
		{
			var parameters = new Dictionary<string, object>();
			AddParameter(parameters, "local", request.Local);
			AddParameter(parameters, "master_timeout", request.MasterTimeout);
			AddCommonParameters(parameters);

			return parameters;
		}
		private static readonly Func<GetDocumentRequest, string>[] GetDocumentPaths = new Func<GetDocumentRequest, string>[]
		{
			x => x.Index,
			x => x.Type,
			x => x.Id,
		};
		public static IEnumerable<string> GetPath(GetDocumentRequest request)
		{
			return GetDocumentPaths.Select(x => x(request));
		}
		public static IDictionary<string, object> GetParameters(GetDocumentRequest request)
		{
			var parameters = new Dictionary<string, object>();
			AddParameter(parameters, "fields", request.Fields);
			AddParameter(parameters, "parent", request.Parent);
			AddParameter(parameters, "preference", request.Preference);
			AddParameter(parameters, "realtime", request.Realtime);
			AddParameter(parameters, "refresh", request.Refresh);
			AddParameter(parameters, "routing", request.Routing);
			AddParameter(parameters, "_source", request.Source);
			AddParameter(parameters, "_source_exclude", request.SourceExclude);
			AddParameter(parameters, "_source_include", request.SourceInclude);
			AddParameter(parameters, "version", request.Version);
			AddParameter(parameters, "version_type", request.VersionType);
			AddCommonParameters(parameters);

			return parameters;
		}
		private static readonly Func<PutDocumentRequest, string>[] PutDocumentPaths = new Func<PutDocumentRequest, string>[]
		{
			x => x.Index,
			x => x.Type,
			x => x.Id,
		};
		public static IEnumerable<string> GetPath(PutDocumentRequest request)
		{
			return PutDocumentPaths.Select(x => x(request));
		}
		public static IDictionary<string, object> GetParameters(PutDocumentRequest request)
		{
			var parameters = new Dictionary<string, object>();
			AddParameter(parameters, "consistency", request.Consistency);
			AddParameter(parameters, "op_type", request.OpType);
			AddParameter(parameters, "parent", request.Parent);
			AddParameter(parameters, "refresh", request.Refresh);
			AddParameter(parameters, "replication", request.Replication);
			AddParameter(parameters, "routing", request.Routing);
			AddParameter(parameters, "timeout", request.Timeout);
			AddParameter(parameters, "timestamp", request.Timestamp);
			AddParameter(parameters, "ttl", request.Ttl);
			AddParameter(parameters, "version", request.Version);
			AddParameter(parameters, "version_type", request.VersionType);
			AddCommonParameters(parameters);

			return parameters;
		}
		private static readonly Func<PostDocumentRequest, string>[] PostDocumentPaths = new Func<PostDocumentRequest, string>[]
		{
			x => x.Index,
			x => x.Type,
		};
		public static IEnumerable<string> GetPath(PostDocumentRequest request)
		{
			return PostDocumentPaths.Select(x => x(request));
		}
		public static IDictionary<string, object> GetParameters(PostDocumentRequest request)
		{
			var parameters = new Dictionary<string, object>();
			AddParameter(parameters, "consistency", request.Consistency);
			AddParameter(parameters, "op_type", request.OpType);
			AddParameter(parameters, "parent", request.Parent);
			AddParameter(parameters, "refresh", request.Refresh);
			AddParameter(parameters, "replication", request.Replication);
			AddParameter(parameters, "routing", request.Routing);
			AddParameter(parameters, "timeout", request.Timeout);
			AddParameter(parameters, "timestamp", request.Timestamp);
			AddParameter(parameters, "ttl", request.Ttl);
			AddParameter(parameters, "version", request.Version);
			AddParameter(parameters, "version_type", request.VersionType);
			AddCommonParameters(parameters);

			return parameters;
		}
		private static readonly Func<DeleteDocumentRequest, string>[] DeleteDocumentPaths = new Func<DeleteDocumentRequest, string>[]
		{
			x => x.Index,
			x => x.Type,
			x => x.Id,
		};
		public static IEnumerable<string> GetPath(DeleteDocumentRequest request)
		{
			return DeleteDocumentPaths.Select(x => x(request));
		}
		public static IDictionary<string, object> GetParameters(DeleteDocumentRequest request)
		{
			var parameters = new Dictionary<string, object>();
			AddParameter(parameters, "consistency", request.Consistency);
			AddParameter(parameters, "parent", request.Parent);
			AddParameter(parameters, "refresh", request.Refresh);
			AddParameter(parameters, "replication", request.Replication);
			AddParameter(parameters, "routing", request.Routing);
			AddParameter(parameters, "timeout", request.Timeout);
			AddParameter(parameters, "version", request.Version);
			AddParameter(parameters, "version_type", request.VersionType);
			AddCommonParameters(parameters);

			return parameters;
		}
		private static readonly Func<UpdateDocumentRequest, string>[] UpdateDocumentPaths = new Func<UpdateDocumentRequest, string>[]
		{
			x => x.Index,
			x => x.Type,
			x => x.Id,
			x => "_update",
		};
		public static IEnumerable<string> GetPath(UpdateDocumentRequest request)
		{
			return UpdateDocumentPaths.Select(x => x(request));
		}
		public static IDictionary<string, object> GetParameters(UpdateDocumentRequest request)
		{
			var parameters = new Dictionary<string, object>();
			AddParameter(parameters, "consistency", request.Consistency);
			AddParameter(parameters, "fields", request.Fields);
			AddParameter(parameters, "lang", request.Lang);
			AddParameter(parameters, "parent", request.Parent);
			AddParameter(parameters, "refresh", request.Refresh);
			AddParameter(parameters, "replication", request.Replication);
			AddParameter(parameters, "retry_on_conflict", request.RetryOnConflict);
			AddParameter(parameters, "routing", request.Routing);
			AddParameter(parameters, "script", request.Script);
			AddParameter(parameters, "script_id", request.ScriptId);
			AddParameter(parameters, "scripted_upsert", request.ScriptedUpsert);
			AddParameter(parameters, "timeout", request.Timeout);
			AddParameter(parameters, "timestamp", request.Timestamp);
			AddParameter(parameters, "ttl", request.Ttl);
			AddParameter(parameters, "version", request.Version);
			AddParameter(parameters, "version_type", request.VersionType);
			AddCommonParameters(parameters);

			return parameters;
		}
		private static readonly Func<PostSearchRequest, string>[] PostSearchPaths = new Func<PostSearchRequest, string>[]
		{
			x => x.Index,
			x => x.Type,
			x => "_search",
		};
		public static IEnumerable<string> GetPath(PostSearchRequest request)
		{
			return PostSearchPaths.Select(x => x(request));
		}
		public static IDictionary<string, object> GetParameters(PostSearchRequest request)
		{
			var parameters = new Dictionary<string, object>();
			AddCommonParameters(parameters);

			return parameters;
		}
        private static void AddParameter(IDictionary<string, object> parameters, string name, object value)
        {
			if (value != null)
			{
                parameters.Add(name, value);
			}
        }
        private static void AddCommonParameters(IDictionary<string, object> parameters)
        {
            parameters.Add("pretty", true);
            parameters.Add("human", false);
        }
	}
}