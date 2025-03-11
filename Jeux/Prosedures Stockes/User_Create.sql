CREATE PROCEDURE [dbo].[User_Create]
	@pseudo  NVARCHAR(64),
	@email NVARCHAR(320),
	@motdepasse NVARCHAR(32)
AS
BEGIN
	DECLARE @salt UNIQUEIDENTIFIER
	SET @salt = NEWID()
	INSERT INTO [Utilisateur] ([Pseudo],[Email],[MotDePasse],[Salt])
	OUTPUT [inserted].[UtilisateurId]
	VALUES (@pseudo, @email, [dbo].[SF_SaltAndHash](@motdepasse, @salt), @salt)
END