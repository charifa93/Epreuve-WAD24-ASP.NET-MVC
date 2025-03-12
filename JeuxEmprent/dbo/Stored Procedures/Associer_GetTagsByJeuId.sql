CREATE PROCEDURE Associer_GetTagsByJeuId
    @JeuId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT 
        j.JeuId, 
        j.Nom AS NomJeu, 
        t.TagId, 
        t.NomTag
    FROM Associer a
    INNER JOIN Jeux j ON a.JeuId = j.JeuId
    INNER JOIN Tag t ON a.TagId = t.TagId
    WHERE j.JeuId = @JeuId
    ORDER BY t.NomTag;
END;
