namespace Core.CrossCuttingConcerns.Exceptions.Types
{
    public class ValidationException : Exception
    {
        public ValidationException()
        {
            Errors = Array.Empty<ValidationExceptionModel>();
        }

        public ValidationException(string message) : base(message)
        {
            Errors = Array.Empty<ValidationExceptionModel>();
        }

        public ValidationException(string message, Exception inner) : base(message, inner)
        {
            Errors = Array.Empty<ValidationExceptionModel>();
        }

        public ValidationException(IEnumerable<ValidationExceptionModel> errors) : base(BuildErrorMessage(errors))
        {
            Errors = errors;
        }

        public IEnumerable<ValidationExceptionModel> Errors { get; }

        private static string BuildErrorMessage(IEnumerable<ValidationExceptionModel> errors)
        {
            IEnumerable<string> messages = errors.Select(
                error => $"{Environment.NewLine} -- {error.Property}: {string.Join(Environment.NewLine, values: error.Errors ?? Array.Empty<string>())}"
            );

            return $"Validation failed: {string.Join(string.Empty, messages)}";
        }
    }

    public class ValidationExceptionModel
    {
        public string? Property { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}
