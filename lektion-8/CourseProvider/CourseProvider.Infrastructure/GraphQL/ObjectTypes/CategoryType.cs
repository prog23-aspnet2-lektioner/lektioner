using CourseProvider.Infrastructure.Data.Entities;

namespace CourseProvider.Infrastructure.GraphQL.ObjectTypes;

public class CategoryType : ObjectType<CategoryEntity>
{
    protected override void Configure(IObjectTypeDescriptor<CategoryEntity> descriptor)
    {
        descriptor.Field(c => c.Id).Type<IdType>();
        descriptor.Field(c => c.CategoryName).Type<StringType>();
    }
}
