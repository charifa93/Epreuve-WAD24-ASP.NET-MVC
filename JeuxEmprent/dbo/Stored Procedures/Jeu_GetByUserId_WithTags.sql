CREATE PROCEDURE Jeux_GetByUserId_WithTags
    @UtilisateurId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT 
        j.JeuId, 
        j.Nom, 
        j.Description, 
        j.NbJoueurMin, 
        j.NbJoueurMax, 
        j.AgeMin, 
        j.AgeMax, 
        j.DureeMinute,
        STRING_AGG(t.NomTag, ', ') AS Tags
    FROM Jeux j
    INNER JOIN Etat e ON j.JeuId = e.JeuId
    LEFT JOIN Associer a ON j.JeuId = a.JeuId
    LEFT JOIN Tag t ON a.TagId = t.TagId
    WHERE e.UtilisateurId = @UtilisateurId
    GROUP BY 
        j.JeuId, 
        j.Nom, 
        j.Description, 
        j.NbJoueurMin, 
        j.NbJoueurMax, 
        j.AgeMin, 
        j.AgeMax, 
        j.DureeMinute;
END;
