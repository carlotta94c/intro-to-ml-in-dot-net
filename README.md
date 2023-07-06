# Introduction to ML.NET
This repository contains the exercise material for the O'Reilly course [*Introduction to ML.NET - Machine Learning for .NET developers*](https://www.oreilly.com/live-events/introduction-to-mlnet/0636920091003/).

Nowadays, machine learning is everywhere and we use ML-empowered applications every day: when choosing the next TV series to watch based on Netflix recommendations, for example, or when asking Alexa to play our favorite song.

If you think of yourself as a developer, you might see machine learning as a separate art, practiced by an elite group of data scientists and statisticians. You might be uncertain about how it fits into application development. During this training you'll learn how ML.NET framework is designed to democratize the art of machine learning, making it accessible to all developers and making a smoother experience of integrating a trained model into an existing or a new .NET solution.

* Trainer: [Carlotta Castelluccio](https://www.linkedin.com/in/carlotta-castelluccio/), Cloud Advocate at Microsoft 

## Exercise 1 - Training a classification model in ML.NET

The key learning objective of this exercise is building a data classification model in ML.NET using Visual Studio Model Builder and integrate it into a console app. The model will be trained to predict a potential sleep disorder starting from information about the sleep habits and lifestyles of the patient. 
The application enables the user to interact with the model and get the predictions through the console.
Here's the data source: [Kaggle Sleep Health and Lifestyle Dataset](https://www.kaggle.com/datasets/uom190346a/sleep-health-and-lifestyle-dataset)
Exercise project: [Classification with Model Builder](./ClassificationWithModelBuilder/) 

## Exercise 2 - Fine-tuning a text classification model with Model Builder

The key learning objective of this exercise is building a text classifier in ML.NET able to predict if a news title is fake or not. The model will be consumed into an ASP.NET Razor Pages web app, enabling the user to interact with the model trough the console, get the predictions and also re-train the machine learning pipeline with hyper parameters to improve model performance.
Here's the data source: [Kaggle Fake News Dataset](https://www.kaggle.com/datasets/algord/fake-news)
Exercise project: [Text Classifier in a Console App](./TextClassifierConsoleApp/) 

## Exercise 3 - Embed a text classifier into a Razor Pages web app 

The key learning objective of this exercise is embedding the text classifier model obtained in exercise 2 into an ASP.NET Razor Pages web app, enabling the user to interact with the model and get the predictions through a simple GUI. The app can be deployed into the Azure Cloud using Azure Web App service, building a CI/CD pipeline using GitHub Workflow Actions.
Exercise project: [Text Classifier in a Web App](./TextClassifierWebApp/) 

### Pre-requisites
To set up your local environment and run the ML.NET projects you need to configure the following pre-requisites:
* [Visual Studio 2022 Community](https://aka.ms/install-visual-studio)
* [.Net 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [Model Builder](https://marketplace.visualstudio.com/items?itemName=MLNET.ModelBuilder2022)

Optional step
If you'd like to deploy your web app on the cloud you'd need a pair of additional prerequisites:
* [GitHub account](https://github.com/)
* [Azure free trial](https://azure.microsoft.com/it-it/free/)

### Useful Resources
* [ML.NET samples](https://github.com/dotnet/machinelearning-samples/)
* [ML.NET docs](https://learn.microsoft.com/en-gb/dotnet/machine-learning/)

