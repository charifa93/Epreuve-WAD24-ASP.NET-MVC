CREATE PROCEDURE Jeux_Insert
    @nom NVARCHAR(255), @description NVARCHAR(MAX), @ageMin INT, @ageMax INT, @NbJoueurMin INT, @nbJoueurMax INT, @dureeMinute INT
AS
BEGIN
    INSERT INTO Jeux (JeuId, Nom, Description, AgeMin, AgeMax, NbJoueurMin, NbJoueurMax, DureeMinute, DateCreation)
    VALUES (NEWID(), @Nom, @Description, @AgeMin, @AgeMax, @NbJoueurMin, @NbJoueurMax, @DureeMinute, GETDATE());
END;
