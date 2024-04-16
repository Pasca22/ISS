using System.Collections.Generic;
using Iss.Entity;
using Iss.Repository;
using Iss.Windows;

namespace Iss.Service;

public class SatisticsService
{
   
    
    private static StatisticsRepository repository;
        
    public static int firstSharesPrediction;
    public static int firstLikesPrediction;
    public static int firstTotalImpressionsPrediction;
    public static int firstClickThroughRatePrediction;

    public static int[] RunNeuralNetwork()
    {
        int obs = 100;

        List<int> predictions = new List<int>();

        // Train the neural network and get the first prediction for shares
        int[,] sharesPrediction = repository.UseNeuralNetwork(obs);
        firstSharesPrediction = sharesPrediction[0, 0];
        predictions.Add(firstSharesPrediction);

        // Train the neural network and get the first prediction for likes
        int[,] likesPrediction = repository.UseNeuralNetwork(obs);
        firstLikesPrediction = likesPrediction[0, 0];
        predictions.Add(firstLikesPrediction);

        // Train the neural network and get the first prediction for total impressions
        int[,] totalImpressionsPrediction = repository.UseNeuralNetwork(obs);
        firstTotalImpressionsPrediction = totalImpressionsPrediction[0, 0];
        predictions.Add(firstTotalImpressionsPrediction);

        // Train the neural network and get the first prediction for click through rate
        int[,] clickThroughRatePrediction = repository.UseNeuralNetwork(obs);
        firstClickThroughRatePrediction = clickThroughRatePrediction[0, 0];
        predictions.Add(firstClickThroughRatePrediction);

        return predictions.ToArray();

        
    }
    // generate numbers around the first prediction
    public static List<int> GenerateNumbersAroundPrediction(int prediction)
    {  List<int> generatedNumbers = new List<int>();
        generatedNumbers.AddRange(repository.GenerateNumbersAroundPrediction(prediction));

        return generatedNumbers;
    }
    //generate the sum of the generated numbers
    public static int GenerateSum(int prediction)
    {
        List<int> generatedNumbers = GenerateNumbersAroundPrediction(prediction);
        int sum = 0;
        foreach (var number in generatedNumbers)
        {
            sum += number;
        }

        return sum;
    }
    public static int GetFirstSharesPrediction()
    {
        return firstSharesPrediction;
    }

    // Get the first likes prediction
    public static int GetFirstLikesPrediction()
    {
        return firstLikesPrediction;
    }

    // Get the first total impressions prediction
    public static int GetFirstTotalImpressionsPrediction()
    {
        return firstTotalImpressionsPrediction;
    }

    // Get the first click through rate prediction
    public static int GetFirstClickThroughRatePrediction()
    {
        return firstClickThroughRatePrediction;
    }
    
}