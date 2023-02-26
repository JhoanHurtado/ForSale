namespace Commons.Commons
{
    public class BusinessResult<T>
    {
        public string Msg { get; set; }
        public bool IsIsuccess { get; set; }
        public T Result { get; set; }

        public BusinessResult() { }
        public static BusinessResult<T> Success(T result,string msg) {
            return new BusinessResult<T>() { Msg = msg, IsIsuccess = true, Result = result };
        }

        public static BusinessResult<T> Issue(T result, string msg)
        {
            return new BusinessResult<T>() { Msg = msg, IsIsuccess = false, Result = result };
        }
    }
}