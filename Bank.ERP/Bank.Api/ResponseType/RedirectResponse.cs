namespace Bank.Api.ResponseType
{
    public class RedirectResponse<T>
    {
        public RedirectResponse(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
    }
}
