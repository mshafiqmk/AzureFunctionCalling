# MakeCall Azure Function

This Azure Function makes a call through Twilio API.

## Prerequisites
- Azure Functions Core Tools
- Twilio Account SID and Auth Token
- Twilio Phone Number
- .NET Core 6.0 or later

## Setup
1. Clone this repository to your local machine.
2. Open the project in your preferred IDE.
3. Replace the placeholders in the `MakeCall.cs` file with your Twilio Account SID, Auth Token, and Twilio Phone Number.
4. Run `dotnet restore` in the project directory to restore the required packages.
5. Install tool required for azure function
    ## install azurite (storage emulator )
    `npm i -g azurite`
    ## install funvm for installing core tools
    `npm i -g @anthonychu/funcvm`

    ## Install azure function core tool v4
    `funcvm use 4`

    ## Create http trigger
    `func init`

6. Run `func start` to start the Azure Function on your local machine.

## Deployment
1. Create a new Azure Function App on your Azure subscription.
2. Publish the project to the function app by running `func azure functionapp publish <your-function-app-name>`
3. Update the `local.settings.json` file with your Twilio Account SID, Auth Token, and Twilio Phone Number.
4. Test the function by triggering the `MakeCall` function through the Azure portal or by making a request to the function's endpoint.

## Usage
To make a call, send a GET or POST request to the endpoint of the `MakeCall` function with a query parameter `to` set to the phone number you want to call. For example:

`https://<your-function-app-name>.azurewebsites.net/api/MakeCall?to=1234567890`


Please make sure that you have setup Twilio account and you have the valid Twilio phone number and credentials. Also, you have the Azure Function core tools and .net core 6.0 or later installed on your machine.
Please let me know if you have any other question.
