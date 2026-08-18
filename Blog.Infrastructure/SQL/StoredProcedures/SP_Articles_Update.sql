CREATE PROCEDURE SP_Articles_Update
    @ArticleId INT,
    @Title NVARCHAR(200),
    @Content NVARCHAR(MAX),
    @Tags NVARCHAR(500) = NULL,
    @PublishedAt DATETIME2
AS
BEGIN
    UPDATE Articles
    SET
        Title = @Title,
        Content = @Content,
        Tags = @Tags,
        PublishedAt = @PublishedAt
    WHERE ArticleId = @ArticleId;
END