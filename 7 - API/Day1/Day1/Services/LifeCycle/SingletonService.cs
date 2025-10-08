namespace Day1.Services.LifeCycle
{
    public class SingletonService : ISingletonService
    {
        public string id { get; } = Guid.NewGuid().ToString();
    }
}
