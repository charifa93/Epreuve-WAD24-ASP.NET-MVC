CREATE PROCEDURE [dbo].[Jeux_Insert]
    @Nom NVARCHAR(255), @Description TEXT, @AgeMin INT, @AgeMax INT, @NbJoueurMin INT, @NbJoueurMax INT, @DureeMinute INT
AS
BEGIN
    INSERT INTO Jeux (JeuId, Nom, Description, AgeMin, AgeMax, NbJoueurMin, NbJoueurMax, DureeMinute, DateCreation)
    VALUES (NEWID(), @Nom, @Description, @AgeMin, @AgeMax, @NbJoueurMin, @NbJoueurMax, @DureeMinute, GETDATE());
END;
GO
