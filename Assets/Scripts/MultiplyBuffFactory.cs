namespace DefaultNamespace
{
    public class MultiplyBuffFactory : IBuffFactory
    {
        private string _idContext;

        public MultiplyBuffFactory(string idContext)
        {
            _idContext = idContext;
        }

        public bool CanCreate(string id)
        {
            return id.Contains(_idContext);
        }

        public IBuff Create(string id)
        {
            return new MultiplyBuff(1, "Manufacture/Cursor");
        }
    }
}