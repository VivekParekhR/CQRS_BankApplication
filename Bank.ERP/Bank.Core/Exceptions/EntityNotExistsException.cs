namespace Bank.Core.Exceptions
{
    [Serializable]
    public class EntityNotExistsException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="EntityName"></param>
        public EntityNotExistsException(string EntityName)
        : base($"Object {EntityName} does not Exists")
        {
        }
    }
}
