CREATE PROCEDURE SearchJeux
    @SearchText NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DISTINCT j.JeuId, j.Nom AS NomJeu, CAST(j.Description AS NVARCHAR(MAX)) AS DescriptionJeu
    FROM Jeux j
    LEFT JOIN Associer a ON j.JeuId = a.JeuId
    LEFT JOIN Tag t ON a.TagId = t.TagId
    WHERE 
        j.Nom LIKE '%' + @SearchText + '%' -- Recherche dans le nom du jeu
        OR t.NomTag LIKE '%' + @SearchText + '%' -- Recherche dans les tags
    ORDER BY j.Nom;
END;