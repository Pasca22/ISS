using System;
using System.Collections.Generic;
using System.Linq;
using Iss.Entity;

namespace Iss.Repository;

public class StatisticsRepository
{  public (double[,], double[,]) GenerateData(int obs)
        {
            Random rand = new Random();
            double[,] inputs = new double[obs, 2];
            double[,] targets = new double[obs, 1]; // Initialize the targets array

            for (int i = 0; i < obs; i++)
            {
                inputs[i, 0] = rand.NextDouble() * 2 - 1;
                inputs[i, 1] = rand.NextDouble() * 2 - 1;
                double noise = rand.NextDouble() * 2 - 1;
                targets[i, 0] = inputs[i, 0] * 5 - inputs[i, 1] * 3 + 0.1 + noise;
            }

            // Normalize inputs and targets
            double[,] normalizedInputs = NormalizeInputs(inputs);
            double[,] normalizedTargets = NormalizeTargets(targets);

            // Return the normalized inputs and targets
            return (normalizedInputs, normalizedTargets);
        }

        private double[,] NormalizeInputs(double[,] inputs)
        {
            double min = -1.0;
            double max = 1.0;

            double[,] normalizedInputs = new double[inputs.GetLength(0), inputs.GetLength(1)];
            for (int i = 0; i < inputs.GetLength(0); i++)
            {
                for (int j = 0; j < inputs.GetLength(1); j++)
                {
                    normalizedInputs[i, j] = (inputs[i, j] - min) / (max - min);
                }
            }

            return normalizedInputs;
        }

        private double[,] NormalizeTargets(double[,] targets)
        {
            double min = -1.0;
            double max = 1.0;

            double[,] normalizedTargets = new double[targets.GetLength(0), targets.GetLength(1)];
            for (int i = 0; i < targets.GetLength(0); i++)
            {
                normalizedTargets[i, 0] = (targets[i, 0] - min) / (max - min);
            }

            return normalizedTargets;
        }

        public int[,] UseNeuralNetwork(int obs)
        {
            NeutralNetwork neuralNetwork = new NeutralNetwork();
            (double[,] inputs, double[,] targets) = GenerateData(obs);
            neuralNetwork.Train(inputs, targets, obs);

            double[,] newInputs = new double[3, 2];
            int [,] outputs = Predict(newInputs, NeutralNetwork.Weights, NeutralNetwork.Biases);

            return outputs;
        }

        public List<int> GenerateNumbersAroundPrediction(int prediction)
        {
            List<int> generatedNumbers = new List<int>();
            Random rand = new Random();

            for (int j = 0; j < 7; j++)
            {
                int generatedNumber = prediction + rand.Next(-3000, 5000); 
                generatedNumbers.Add(generatedNumber);
            }

            return generatedNumbers;
        }

        private int[,] Predict(double[,] inputs, double[,] weights, double[] biases)
        {
            // Normalize inputs before feeding them into the neural network
            double[,] normalizedInputs = NormalizeInputs(inputs);

            // Perform the forward pass through the neural network to get predictions
            double[,] predictions = ForwardPass(normalizedInputs, weights, biases);

            // Denormalize the predictions
            double[,] denormalizedPredictions = DenormalizeOutputs(predictions);

            // Convert double predictions to integers
            int[,] intPredictions = new int[denormalizedPredictions.GetLength(0), denormalizedPredictions.GetLength(1)];
            for (int i = 0; i < denormalizedPredictions.GetLength(0); i++)
            {
                for (int j = 0; j < denormalizedPredictions.GetLength(1); j++)
                {
                    intPredictions[i, j] = (int)Math.Round(denormalizedPredictions[i, j]);
                }
            }

            return intPredictions;
        }


        private double[,] ForwardPass(double[,] inputs, double[,] weights, double[] biases)
        {
            // Perform matrix multiplication between inputs and weights
            double[,] outputs = NeutralNetwork.Multiply(inputs, weights);

            // Add biases to each output neuron
            for (int i = 0; i < outputs.GetLength(0); i++)
            {
                outputs[i, 0] += biases[0]; // Assuming biases is a 1D array
            }

            return outputs;
        }

        private double[,] DenormalizeOutputs(double[,] predictions)
        {
            // Denormalize the predictions
            double min = 10000;
            double max = 100000;

            double[,] denormalizedPredictions = new double[predictions.GetLength(0), predictions.GetLength(1)];
            for (int i = 0; i < predictions.GetLength(0); i++)
            {
                denormalizedPredictions[i, 0] = predictions[i, 0] * (max - min) + min;
            }

            return denormalizedPredictions;
        }

    }
     
