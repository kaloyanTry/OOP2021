namespace CollectionHierarchy.Collections
{
    using Contracts;
    using System.Collections.Generic;
    public class AddCollection<T> : IAddable<T>
    {
        private IList<T> collection;

        public AddCollection()
        {
            this.collection = new List<T>();
        }

        protected IList<T> Collection { get { return this.collection; } }

        public virtual int Add(T item)
        {
            this.collection.Add(item);
            return this.Collection.Count - 1;
        }
    }
}
