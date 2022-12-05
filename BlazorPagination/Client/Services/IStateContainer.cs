namespace BlazorPagination.Client.Services
{
    public interface IStateContainer
    {
        public int LastPageNo { get; set; }
    }

    public class StateContainer : IStateContainer
    {
        public int LastPageNo { get; set ; }
    }
}
