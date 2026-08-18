CREATE PROCEDURE SP_Articles_Add
    @Title NVARCHAR(200),
    @Content NVARCHAR(MAX),
    @Tags NVARCHAR(500) = NULL,
    @PublishedAt DATETIME2
AS
BEGIN
    INSERT INTO Articles
    (
        Title,
        Content,
        Tags,
        PublishedAt
    )
    VALUES
    (
        @Title,
        @Content,
        @Tags,
        @PublishedAt
    );

    SELECT SCOPE_IDENTITY() AS ArticleId;
END