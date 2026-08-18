CREATE PROCEDURE SP_Articles_Delete
    @ArticleId INT
AS
BEGIN
    DELETE FROM Articles
    WHERE ArticleId = @ArticleId;
END