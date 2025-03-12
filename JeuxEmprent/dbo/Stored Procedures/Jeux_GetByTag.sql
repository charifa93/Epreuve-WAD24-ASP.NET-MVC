CREATE PROCEDURE Jeux_GetByTag
    @TagId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT *
    FROM Jeux j
    INNER JOIN Associer a ON j.JeuId = a.JeuId
    INNER JOIN Tag t ON a.TagId = t.TagId
    WHERE t.TagId = @TagId;
END;

