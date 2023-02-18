namespace Student.Business.Services.Utilities
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException() { }

        public StudentNotFoundException(string message) : base(message) { }

        public StudentNotFoundException(string message, Exception exception) : base(message, exception) { }

    }
}
