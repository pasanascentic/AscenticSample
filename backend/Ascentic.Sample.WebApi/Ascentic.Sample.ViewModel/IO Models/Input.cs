namespace Ascentic.Sample.ViewModel.IO_Models
{
    public class Input<T>
    {
        public string OperationBy { get; set; }

        public T Arguments { get; set; }

        public virtual bool Validate
        {
            get
            {
                return Arguments != null;
            }
        }
    }
}
