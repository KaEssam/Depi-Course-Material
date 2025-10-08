namespace Day1.Services.LifeCycle
{
    public class ScopedService:IScopedService
    {
        public string id { get; } = Guid.NewGuid().ToString();

    }
}
