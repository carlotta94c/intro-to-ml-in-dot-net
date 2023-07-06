
using Microsoft.ML.Data;
using Microsoft.ML;
using static Microsoft.ML.DataOperationsCatalog;
using TextClassifierConsoleApp;
using Microsoft.ML.AutoML;

var userInput = string.Empty;

//Optionally retrain the model before making predictions
Console.WriteLine("Do you wish to retrain the model? Type YES or NO\n\n");
if (!string.IsNullOrWhiteSpace(userInput = Console.ReadLine()) && string.Equals(userInput, "YES", StringComparison.CurrentCultureIgnoreCase))
{
    RetrainModelWithHyperParameters();
}

Console.WriteLine("Using model to make predictions\n\n");
Console.WriteLine("Insert the news title you want to verify:");

while (!string.IsNullOrWhiteSpace(userInput = Console.ReadLine()) && !string.Equals(userInput, "END", StringComparison.CurrentCultureIgnoreCase))
{
    // Create single instance of sample data from first line of dataset for model input
    TextClassifier.ModelInput sampleData = new TextClassifier.ModelInput()
    {
        Title = userInput,
    };

    // Make a single prediction on the sample data and print results
    var predictionResult = TextClassifier.Predict(sampleData);
    if (predictionResult.PredictedLabel)
    {
        Console.WriteLine("This news is fake");
    }
    else
    {
        Console.WriteLine("This news is authentic");
    }

    Console.WriteLine("Insert the news title you want to verify. Type END to leave");
}

void RetrainModelWithHyperParameters(int batchSize = 32, int maxEpochs = 16)
{
    var mlContext = new MLContext();

    var dataPath = Path.GetFullPath(@"..\..\data\FakeNewsNet_TrainingSet.csv");

    // Infer column information
    ColumnInferenceResults columnInference =
        mlContext.Auto().InferColumns(dataPath, labelColumnName: "real", groupColumns: false);

    // Create text loader
    TextLoader loader = mlContext.Data.CreateTextLoader(columnInference.TextLoaderOptions);

    // Load data into IDataView
    IDataView data = loader.Load(dataPath);

    Console.WriteLine("Splitting dataset into train (80%) and test (20%)");
    // Split into train (80%), validation (20%) sets
    TrainTestData trainValidationData = mlContext.Data.TrainTestSplit(data, testFraction: 0.2);

    Console.WriteLine("Retraining pipeline with batchsize = " + batchSize + " and maxEpochs = " + maxEpochs);
    //Retraining model with hyper parameters tuning
    ITransformer mlModel = TextClassifier.RetrainPipeline(mlContext, trainValidationData.TrainSet, batchSize, maxEpochs);
    var predictions = mlModel.Transform(trainValidationData.TestSet);

    Console.WriteLine("Evaluating retrained model");
    //Evaluate Model
    var evaluationMetrics =
                            mlContext
                                .MulticlassClassification
                                .Evaluate(predictions, "real");

    Console.WriteLine("Retrained model microaccuracy:" + evaluationMetrics.MicroAccuracy);

    // Save Trained Model
    mlContext.Model.Save(mlModel, data.Schema, "TextClassifier.zip");
}
