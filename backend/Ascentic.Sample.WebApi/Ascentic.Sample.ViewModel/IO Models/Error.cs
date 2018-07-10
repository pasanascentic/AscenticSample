namespace Ascentic.Sample.ViewModel.IO_Models
{
    public class Error
    {
        public Error()
        {

        }

        public Error(string errormessage, string description = null)
        {
            ErrorMessage = errormessage;
            Description = description;
        }

        public string ErrorMessage { get; set; }

        public string Description { get; set; }
    }
}
