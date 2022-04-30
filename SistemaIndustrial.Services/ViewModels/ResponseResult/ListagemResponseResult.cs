namespace SistemaIndustrial.Services.ViewModels.ResponseResult
{
    public class ListagemResponseResult<T> : ResponseResult<T>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalResult { get; set; }
    }
}
