namespace Backend.Dto;

public sealed record CreateCategoryBody(string Name);
public sealed record ModifyCategoryBody(string Name);
public sealed record CreateRecipe(
    string Title,
    Guid CategoryId,



    );
