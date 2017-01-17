namespace ACM.BL.BusinessObjects
{
    public abstract class EntityBase
    {
        public enum EntityStateOption
        {
            Active,
            Deleted
        }

        public bool IsNew { get; private set; }
        public bool HasChanges { get; set; }
        public EntityStateOption EntityState { get; set; }
        public bool IsValid 
        {
            get 
            {
                return this.Validate();
            }
        }

        public abstract bool Validate();
    }
}
