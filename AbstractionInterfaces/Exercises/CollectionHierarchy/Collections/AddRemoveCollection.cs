namespace CollectionHierarchy.Collections
{
    using Contracts;
    public class AddRemoveCollection<T> : AddCollection<T>, IRemovable<T>
    {
        public AddRemoveCollection()
            : base() { }

        public override int Add(T item)
        {
            this.Collection.Insert(0, item);
            return 0;
        }

        public virtual T Remove()
        {
            T removedItem = this.Collection[this.Collection.Count - 1];
            this.Collection.RemoveAt(this.Collection.Count - 1);
            return removedItem;
        }
    }
}
