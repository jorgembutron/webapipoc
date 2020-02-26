namespace Company.Biz.WebApi.Responses
{
    public enum Result
    {
        Ok,
        Error,
        NotMoved,
        Moved,
        NotFound,
        Updated,
        NotUpdated,
        Inserted,
        Retrieved,
        Deleted,
        NotDeletedDueToDependentObjects,
        InvalidRequest,
        Created,
        NotCreated,
        DependentObjectNotFound

    }
}
