CREATE PROCEDURE Jeux_GetAll
AS
BEGIN
    SELECT 
        JeuId, 
        Nom, 
        Description, 
        AgeMin, 
        AgeMax, 
        NbJoueurMin, 
        NbJoueurMax, 
        DureeMinute, 
        DateCreation
    FROM Jeux
    ORDER BY DateCreation DESC;
END;