﻿namespace Ascentic.Sample.ViewModel.IO_Models
{
    public class Output<T> : OutputResult
    {
        public T Result { get; set; }

        public static Output<T> FailOutput(string errorMessage, string additionalMessage = null, string description = null)
        {
            return new Output<T>
            {
                Sucess = false,
                Error = new Error(errorMessage, description),
                AdditionalMessage = additionalMessage
            };
        }
    }
}
