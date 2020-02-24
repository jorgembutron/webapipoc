using Company.Biz.Domain.SeedWork;

namespace Company.Biz.Domain.Model
{

    /// <summary>
    /// This should not be an Anemic domain model :)
    /// </summary>
    public class Ping : Entity
    {
        public string Name { get; set; }
    }
}
