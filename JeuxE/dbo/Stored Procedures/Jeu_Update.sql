CREATE PROCEDURE Jeu_Update
    @JeuId UNIQUEIDENTIFIER, @Nom NVARCHAR(255), @Description TEXT
AS
BEGIN
    UPDATE Jeux SET Nom = @Nom, Description = @Description WHERE JeuId = @JeuId;
END;
