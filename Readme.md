<center><img src="./images/dotnet-on-aws.png" alt=".NET on AWS" title=".NET on AWS" width="150" height="100" /></center>

## Making a serverless rest API in .NET 6 with AWS Lambda

This is a very quick demo of how to create a serverless rest API using `AWS Lambda` and `.NET 6`. The project is created using the `dotnet new` command and the `Amazon.Lambda.Templates` NuGet package.

### Installing AWS Lambda Templates

Install the AWS Lambda templates for .NET 6 using the following command:

```bash
dotnet new -i Amazon.Lambda.Templates
```

If already installed check the installed templates using the following command:

```bash
dotnet new --list
```

Install Amazon.Lambda.Tools Global Tools if not already installed.
```bash
dotnet tool install -g Amazon.Lambda.Tools
```

If already installed check if new version is available.
```bash
dotnet tool update -g Amazon.Lambda.Tools
```

### Creating a new project


|Template Name|Short Name|Language|Tags|
|--|--|--|--|
|Lambda Empty Serverless                               |serverless.EmptyServerless                   | [C#],F# |     AWS/Lambda/Serverless |

We will create a new project using the `serverless.EmptyServerless` template. 

##### dotnet CLI

```bash
dotnet new serverless.EmptyServerless --name SimpleApi --output dotnet-rest-api-with-lambda
```

##### Rider IDE

![Rider IDE](./images/rider-ide-create-project.png)

### Configuring the project

This project's purpose is only demostrating how to create a serverless rest API using `AWS Lambda` and `.NET 6`. 

We don't need `serverless.template` file. So, we can delete it.

Now we need to configure `aws-lambda-tools-defaults.json` file. 

![Project Configurations](./images/project-configurations.png)

We must set `function-runtime` to `dotnet6`, `function-memory-size` to `256` and `function-timeout` to `30`.

`function-handler` is the name of the class that will handle the request. In this project, we will use <strong>`SimpleApi::SimpleApi.Functions::Get`</strong> as the handler.

First part is the assembly name, second part is the namespace and the class name. Last part is the method name.

### Looking at the code

We have a `Get` method in `Functions` class. This method will handle the request. 

```csharp
public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
{
    return new APIGatewayProxyResponse
    {
        StatusCode = 200,
        Body = "Hello World!",
        Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
    };
}
```

### Deploying the project

Now that we have created the project, we can deploy it to AWS Lambda. Go to the project directory and run the following command:

```bash
dotnet lambda deploy-function
```

### Configuring the Lambda function on AWS Console

We need to configure the Lambda function on AWS Console.

In the `Configuration` tab, we need to create a new `Function URL`.

![Lambda Function Configuration](./images/aws-config.png)

The auth type should be `NONE`. Then click on `Save`.

![Create Function URL](./images/create-function-url.png)

### Congratulations!

You have created a serverless rest API using `AWS Lambda` and `.NET 6`.