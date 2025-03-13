CREATE PROCEDURE User_Insert
    @Email NVARCHAR(255),
    @MotDePasse NVARCHAR(255),
    @Pseudo NVARCHAR(100)
AS
BEGIN
    DECLARE @salt UNIQUEIDENTIFIER
    SET @salt = NEWID()

    INSERT INTO Utilisateur (UtilisateurId, Email, MotDePasse, Salt, Pseudo, DateCreation)
    OUTPUT inserted.UtilisateurId
    VALUES (NEWID(), @Email, [dbo].[SaltAndHash](@MotDePasse, @salt), @salt, @Pseudo, GETDATE());
END;
