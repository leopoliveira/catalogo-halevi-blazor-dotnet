namespace Halevi.Tests.Helpers
{
    internal static class ConstantsFactory
    {
        internal static readonly DateOnly _dateTime = new(2000, 12, 12);

        internal static readonly Guid _categoryId = Guid.Parse("7B04CC9B-CB6B-4FF6-9317-E564CA48C5F6");
        internal static readonly Guid _productId = Guid.Parse("370A9505-4002-4833-8DA0-4CD022A1FA71");
        internal static readonly Guid _variationId = Guid.Parse("02842B50-CB94-4B9F-A275-49E03C174287");
    }
}