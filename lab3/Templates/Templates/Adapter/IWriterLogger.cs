namespace Templates.Adapter
{
    public interface IWriterLogger
    {
        void Log(string message);
        void Error(string message);
        void Warn(string message);
    }
}
