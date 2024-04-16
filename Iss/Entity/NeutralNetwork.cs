using System;
using System.Linq;

namespace Iss.Entity;

public class NeutralNetwork
{
    public static double[,] Weights { get; set; }
    public static double[] Biases { get; set; }
    private double LearningRate { get; set; }

    public NeutralNetwork()
    {
        (Weights, Biases, LearningRate) = WeightsGenerator();
    }

    public void Train(double[,] inputs, double[,] targets, int obs)
    {
        double[,] outputs = new double[obs, 1];
        double[,] deltas = new double[obs, 1];
        double loss = 0;

        for (int i = 0; i < 100; i++)
        {
            outputs = Multiply(inputs, Weights);
            for (int j = 0; j < obs; j++)
            {
                outputs[j, 0] += Biases[0];
            }

            for (int j = 0; j < obs; j++)
            {
                deltas[j, 0] = outputs[j, 0] - targets[j, 0];
            }

            loss = deltas.Cast<double>().Select(d => d * d).Sum() / (2 * obs);
           
           

            double[,] deltasScaled = MultiplyScalar(deltas, 1.0 / obs);
            double[,] weightsUpdate = Multiply(Transpose(inputs), deltasScaled);
            for (int j = 0; j < Weights.GetLength(0); j++)
            {
                for (int k = 0; k < Weights.GetLength(1); k++)
                {
                    Weights[j, k] -= LearningRate * weightsUpdate[j, k];
                }
            }

            double biasesUpdate = deltasScaled.Cast<double>().Sum();
            Biases[0] -= LearningRate * biasesUpdate;
        }
    }

    private (double[,], double[], double) WeightsGenerator()
    {
        double initRange = 0.01;
        Random rand = new Random();
        double[,] weights = new double[2, 1];
        double[] biases = new double[1];
        double learningRate = 0.02;

        for (int i = 0; i < weights.GetLength(0); i++)
        {
            for (int j = 0; j < weights.GetLength(1); j++)
            {
                weights[i, j] = rand.NextDouble() * (2 * initRange) - initRange;
            }
        }

        biases[0] = rand.NextDouble() * (2 * initRange) - initRange;

        return (weights, biases, learningRate);
    }

    static public double[,] Multiply(double[,] a, double[,] b)
    {
        int rowsA = a.GetLength(0);
        int colsA = a.GetLength(1);
        int colsB = b.GetLength(1);

        double[,] c = new double[rowsA, colsB];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                double sum = 0;
                for (int k = 0; k < colsA; k++)
                {
                    sum += a[i, k] * b[k, j];
                }
                c[i, j] = sum;
            }
        }

        return c;
    }

    private double[,] MultiplyScalar(double[,] matrix, double scalar)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }

        return result;
    }

    private double[,] Transpose(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        double[,] result = new double[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[j, i] = matrix[i, j];
            }
        }

        return result;
    }
    
    
}