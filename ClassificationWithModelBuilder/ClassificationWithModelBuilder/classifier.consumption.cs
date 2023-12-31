﻿// This file was auto-generated by ML.NET Model Builder.
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace ClassificationWithModelBuilder
{
    public partial class Classifier
    {
        /// <summary>
        /// model input class for Classifier.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [LoadColumn(0)]
            [ColumnName(@"Gender")]
            public string Gender { get; set; }

            [LoadColumn(1)]
            [ColumnName(@"Age")]
            public float Age { get; set; }

            [LoadColumn(2)]
            [ColumnName(@"Occupation")]
            public string Occupation { get; set; }

            [LoadColumn(3)]
            [ColumnName(@"Sleep Duration")]
            public float Sleep_Duration { get; set; }

            [LoadColumn(4)]
            [ColumnName(@"Quality of Sleep")]
            public float Quality_of_Sleep { get; set; }

            [LoadColumn(5)]
            [ColumnName(@"Physical Activity Level")]
            public float Physical_Activity_Level { get; set; }

            [LoadColumn(6)]
            [ColumnName(@"Stress Level")]
            public float Stress_Level { get; set; }

            [LoadColumn(7)]
            [ColumnName(@"BMI Category")]
            public string BMI_Category { get; set; }

            [LoadColumn(8)]
            [ColumnName(@"Sleep Disorder")]
            public string Sleep_Disorder { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for Classifier.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"Gender")]
            public float[] Gender { get; set; }

            [ColumnName(@"Age")]
            public float Age { get; set; }

            [ColumnName(@"Occupation")]
            public float[] Occupation { get; set; }

            [ColumnName(@"Sleep Duration")]
            public float Sleep_Duration { get; set; }

            [ColumnName(@"Quality of Sleep")]
            public float Quality_of_Sleep { get; set; }

            [ColumnName(@"Physical Activity Level")]
            public float Physical_Activity_Level { get; set; }

            [ColumnName(@"Stress Level")]
            public float Stress_Level { get; set; }

            [ColumnName(@"BMI Category")]
            public float[] BMI_Category { get; set; }

            [ColumnName(@"Sleep Disorder")]
            public uint Sleep_Disorder { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"PredictedLabel")]
            public string PredictedLabel { get; set; }

            [ColumnName(@"Score")]
            public float[] Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("classifier.zip");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
    }
}
