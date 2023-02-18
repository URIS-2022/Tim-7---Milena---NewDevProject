namespace Gateway.Models
{
    public class ResponsePackage<T> : ResponsePackageNoData
    {
        public T? TransferObject { get; set; }

        public ResponsePackage() { }

        public ResponsePackage(int status, string message)
        {
            Status = status;
            Message = message;
        }

        public ResponsePackage(T data, int status = 200, string message = "Success")
        {
            TransferObject = data;
            Status = status;
            Message = message;
        }
    }

    public class ResponsePackageList<T> : ResponsePackageNoData
    {
        public List<T>? TransferObject { get; set; }

        public ResponsePackageList() { }

        public ResponsePackageList(int status, string message)
        {
            Status = status;
            Message = message;
        }

        public ResponsePackageList(List<T> data, int status = 200, string message = "Success")
        {
            TransferObject = data;
            Status = status;
            Message = message;
        }
    }

    public class ResponsePackageNoData
    {
        public string Message { get; set; }
        public int Status { get; set; }

        public ResponsePackageNoData()
        {
            Status = StatusCodes.Status200OK;
            Message = "Success";
        }

        public ResponsePackageNoData(int status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
