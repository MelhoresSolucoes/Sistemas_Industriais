namespace SistemaIndustrial.Services.ViewModels.ResponseResult
{
    public class ResponseResult<T>
    {
        public bool Success { get; set; }
        public List<T> Data { get; set; }
    }
}
