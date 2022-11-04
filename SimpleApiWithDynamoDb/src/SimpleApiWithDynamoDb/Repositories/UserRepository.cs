using System.Net;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using SimpleApiWithDynamoDb.Contracts.Data;

namespace SimpleApiWithDynamoDb.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IAmazonDynamoDB _dynamoDb;
    private readonly string _tableName;

    public UserRepository(IAmazonDynamoDB dynamoDb, string tableName)
    {
        _dynamoDb = dynamoDb;
        _tableName = tableName;
    }
    
    public async Task<bool> CreateAsync(UserDto user)
    {
        var userAsJson = JsonSerializer.Serialize(user);
        var itemAsDocument = Document.FromJson(userAsJson);
        var itemAsAttributes = itemAsDocument.ToAttributeMap();
        var request = new PutItemRequest
        {
            TableName = _tableName,
            Item = itemAsAttributes
        };
        var response = await _dynamoDb.PutItemAsync(request);
        return response.HttpStatusCode == HttpStatusCode.OK;
    }

    public async Task<UserDto?> GetAsync(Guid id)
    {
        var request = new GetItemRequest
        {
            TableName = _tableName,
            Key = new Dictionary<string, AttributeValue>
            {
                { "pk", new AttributeValue { S = id.ToString() } },
                { "sk", new AttributeValue { S = id.ToString() } }
            },
            ConsistentRead = true
        };
        
        var response = await _dynamoDb.GetItemAsync(request);
        if (response.Item.Count == 0)
        {
            return null;
        }
        
        var itemAsDocument = Document.FromAttributeMap(response.Item);
        return JsonSerializer.Deserialize<UserDto>(itemAsDocument.ToJson());
    }

    public async Task<bool> UpdateAsync(UserDto user)
    {
        var userAsJson = JsonSerializer.Serialize(user);
        var itemAsDocument = Document.FromJson(userAsJson);
        var itemAsAttributes = itemAsDocument.ToAttributeMap();
        var request = new PutItemRequest()
        {
            TableName = _tableName,
            Item = itemAsAttributes
        };
        var response = await _dynamoDb.PutItemAsync(request);
        return response.HttpStatusCode == HttpStatusCode.OK;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var request = new DeleteItemRequest
        {
            TableName = _tableName,
            Key = new Dictionary<string, AttributeValue>
            {
                { "pk", new AttributeValue { S = id.ToString() } },
                { "sk", new AttributeValue { S = id.ToString() } }
            }
        };
        var response = await _dynamoDb.DeleteItemAsync(request);
        return response.HttpStatusCode == HttpStatusCode.OK;
    }
}