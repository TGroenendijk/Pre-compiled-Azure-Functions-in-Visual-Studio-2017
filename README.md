# Pre-compiled-Azure-Functions-in-Visual-Studio-2017

## Introduction
On May 10th, Microsoft announced the release of the first preview of Visual Studio 2017 Tools for Azure Functions.
This preview introduces some exciting changes over the previous release:
- Enables creating pre-compiled C# functions that bring better cold start performance than script based functions
- Uses WebJobs attributes to declare function bindings directly in the C# code rather than the separate function.json file.

This Visual Studio Solution sample contains several pre-compiled Azure Functions that are build with the Visual Studio 2017 Tools for Azure Functions. The project is created in Visual Studio 2017 version 15.3 Preview. The Azure Functions use Azure Table Storage to Create, Read, Update and Delete orders. Azure Table Storage is a NoSQL key-value store for rapid development using massive semi-structured datasets


## Getting Started
To get started:
- You need to install [Visual Studio 2017 version 15.3 Preview](https://www.visualstudio.com/vs/preview/)
- You must have either the “ASP.NET and web development” or “Azure development” workload installed
- Download and install the [Visual Studio 2017 Tools for Azure Functions extension](https://marketplace.visualstudio.com/items?itemName=AndrewBHall-MSFT.AzureFunctionToolsforVisualStudio2017)
![install - small](https://cloud.githubusercontent.com/assets/4686866/26544780/6820f712-4463-11e7-96a7-e549d282f605.png)


## Code
The Azure Functions use Model classes and an Order Repository class to reduce the amount of code in the Functions.

#### Model classes
The Solution contains several model classes that represents the data in the application. In this case, the models used are a TableOrder that contains data from the Azure Table  and a ClientOrder to communicate with the client.

#### Order Repository class
The Solution contains a repository that encapsulates the data layer. The repository contains logic for retrieving and mapping data to an order model. 

#### Visual Studio 2017 version 15.3 Preview
![visual studio 2017 version 15 3 preview](https://cloud.githubusercontent.com/assets/4686866/26531801/73f54cfe-43f1-11e7-8bcf-0f8be41d9ed4.png)


## Testing
You can use a tool like Postman to test the API App.

#### Functions Runtime 
All the Azure Functions are started locally when you debug the Solution.
![runtime](https://cloud.githubusercontent.com/assets/4686866/26531818/df2e9dd6-43f1-11e7-84f1-034678a7eb82.png)

#### Create Order
Post a JSON order object to the Azure HttpPOSTTrigger Function to store the order in Azure Table Storage.
![postman - post order](https://cloud.githubusercontent.com/assets/4686866/26531743/14cbd97e-43f0-11e7-9e23-25e4d3635884.png)

#### Get Order by id
Get a JSON order object with the HttpGETTrigger Function to get the order from Azure Table Storage.
![postman - get order](https://cloud.githubusercontent.com/assets/4686866/26531777/9ccdb478-43f0-11e7-8a21-fa205df0d990.png)

#### Update Order
Put a JSON order object to the Azure HttpPUTTrigger Function to update the order in Azure Table Storage.
![postman - put order](https://cloud.githubusercontent.com/assets/4686866/26531779/df46e3b0-43f0-11e7-9c59-f40b490d9b58.png)

#### Delete Order by id
Delete an order by an id with the HttpDELETETrigger Function to delete the order from Azure Table Storage.
![postman - delete order](https://cloud.githubusercontent.com/assets/4686866/26531794/35398840-43f1-11e7-9a3d-08b4b5981a0c.png)


## More Information
For more information about Visual Studio 2017 Tools for Azure Functions go to: 
https://blogs.msdn.microsoft.com/webdev/2017/05/10/azure-function-tools-for-visual-studio-2017/
