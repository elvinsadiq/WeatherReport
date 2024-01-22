namespace Application.LoginFailureTrackerDetails.Queries.Response
{
    public class GetByIdLoginFailureTrackerQueryResponse
    {
        public int Id { get; set; }
        public int LoginTryCount { get; set; }
        public bool IsBlocked { get; set; }
    }
}