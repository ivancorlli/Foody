using Backend.Enum;

namespace Backend.Dto;

public sealed record CreateCategoryBody(string Name);
public sealed record ModifyCategoryBody(string Name);
public sealed record CreateRecipeBody(
    string Title,
    string Description,
    Guid CategoryId
    );

public sealed record IngridientRecipeBody(
    string Name,
    double Qty,
    Measure Measure
    );
