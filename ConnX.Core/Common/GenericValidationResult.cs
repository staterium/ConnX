namespace ConnX.Core.Common
{
    /// <summary>
    /// Represents a generic validation result that can be used across validation rule types.
    /// </summary>
    public class GenericValidationResult
    {
        public bool IsValid { get; set; }

        public string? CardType { get; set; }

        public string? ErrorMessage { get; set; }

    }
}
