CREATE PROCEDURE SP_Articles_GetAll
AS
BEGIN
    SELECT
        ArticleId,
        Title,
        Content,
        Tags,
        PublishedAt
    FROM Articles
    ORDER BY PublishedAt DESC;
END