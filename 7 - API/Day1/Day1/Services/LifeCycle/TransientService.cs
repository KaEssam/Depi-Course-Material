namespace Day1.Services.LifeCycle
{
    public class TransientService: ITransientService
    {
        public string id { get; } = Guid.NewGuid().ToString();

    }
}
