# Pre-compiled-Azure-Functions-in-Visual-Studio-2017

## Introduction
This Visual Studio Solution contains several Azure Functions and uses Azure Table Storage to  Create, Read, Update and Delete orders. The project is created in Visual Studio 2017 version 15.3 Preview. The sample can easy be modified for other type of objects. 
Azure Table Storage is a NoSQL key-value store for rapid development using massive semi-structured datasets


## Code
### Model classes
The Solution contains several model classes. A model is an object that represents the data in your application. In this case, the models used are a TableOrder that contains data from the Azure Table  and a ClientOrder to communicate with the client.

### Order Repository class
A repository is an object that encapsulates the data layer. The repository contains logic for retrieving and mapping data to an entity model. This sample uses Azure Tables as database.

### Visual Studio 2017 version 15.3 Preview
![visual studio 2017 version 15 3 preview](https://cloud.githubusercontent.com/assets/4686866/26531801/73f54cfe-43f1-11e7-8bcf-0f8be41d9ed4.png)


## Testing
Use a tool like Postman to test the API App.

### Functions Runtime 
![runtime](https://cloud.githubusercontent.com/assets/4686866/26531818/df2e9dd6-43f1-11e7-84f1-034678a7eb82.png)

### Create Order
![postman - post order](https://cloud.githubusercontent.com/assets/4686866/26531743/14cbd97e-43f0-11e7-9e23-25e4d3635884.png)

### Get Order by id
![postman - get order](https://cloud.githubusercontent.com/assets/4686866/26531777/9ccdb478-43f0-11e7-8a21-fa205df0d990.png)

### Update Order
![postman - put order](https://cloud.githubusercontent.com/assets/4686866/26531779/df46e3b0-43f0-11e7-9c59-f40b490d9b58.png)

## Delete Order by id
![postman - delete order](https://cloud.githubusercontent.com/assets/4686866/26531794/35398840-43f1-11e7-9a3d-08b4b5981a0c.png)
