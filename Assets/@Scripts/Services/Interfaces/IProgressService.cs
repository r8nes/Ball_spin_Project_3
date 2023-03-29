namespace SpinProject.Service
{
    public interface IProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}