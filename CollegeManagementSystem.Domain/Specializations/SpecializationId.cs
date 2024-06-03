using SharedKernel;

namespace CollegeManagementSystem.Domain.Specializations;

public sealed class SpecializationId : EntityId
{
    public SpecializationId(Guid id) : base(id) { }
    public SpecializationId() : base() { }
}
