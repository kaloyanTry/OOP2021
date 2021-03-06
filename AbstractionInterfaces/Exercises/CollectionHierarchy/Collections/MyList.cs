namespace CollectionHierarchy.Collections
{
    using Contracts;
    public class MyList<T> : AddRemoveCollection<T>, IUsable
    {
        public MyList()
            : base() { }

        public int Used => this.Collection.Count;

        public override T Remove()
        {
            T removedItem = this.Collection[0];
            this.Collection.RemoveAt(0);
            return removedItem;
        }
    }
}
