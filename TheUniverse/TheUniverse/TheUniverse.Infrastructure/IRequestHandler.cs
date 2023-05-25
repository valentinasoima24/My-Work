namespace RemoteLearning.TheUniverse.Infrastructure
{
    public interface IRequestHandler
    {
        object Execute(object request);
    }
}