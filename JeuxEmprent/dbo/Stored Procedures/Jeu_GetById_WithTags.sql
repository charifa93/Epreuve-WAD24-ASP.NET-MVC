CREATE PROCEDURE Jeu_GetById_WithTags
    @JeuId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT 
        j.Nom,
        j.Description,
        j.NbJoueurMin,
        j.NbJoueurMax,
        j.AgeMin,
        j.AgeMax,
        j.DureeMinute,
        STRING_AGG(t.NomTag, ', ') AS Tags
    FROM Jeux j
    LEFT JOIN Associer a ON j.JeuId = a.JeuId
    LEFT JOIN Tag t ON a.TagId = t.TagId
    WHERE j.JeuId = @JeuId
    GROUP BY j.Nom, j.Description,j.NbJoueurMin, j.NbJoueurMax, j.AgeMin, j.AgeMax, j.DureeMinute;
END;
