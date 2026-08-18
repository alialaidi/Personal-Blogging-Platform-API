CREATE PROCEDURE SP_Articles_GetById
    @ArticleId INT
AS
BEGIN
    SELECT
        ArticleId,
        Title,
        Content,
        Tags,
        PublishedAt
    FROM Articles
    WHERE ArticleId = @ArticleId;
END