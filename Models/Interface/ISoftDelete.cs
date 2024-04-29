namespace SpinsOnlineRazor.Models.Interface
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public void Undo()
        {
            IsDeleted = false;
            DeletedDate = null;
        }
    }
}