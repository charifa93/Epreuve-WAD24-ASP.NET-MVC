CREATE PROCEDURE Jeux_GetByNom
    @Nom NVARCHAR(255)
AS
BEGIN
    SELECT 
        JeuId, 
        Nom, 
        Description, 
        NbJoueurMin, 
        NbJoueurMax, 
        AgeMin, 
        AgeMax, 
        DureeMinute
    FROM Jeux
    WHERE Nom LIKE '%' + @Nom + '%';
END;
