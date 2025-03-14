CREATE PROCEDURE [dbo].[User_CheckPassword]
    @Email NVARCHAR(320),
    @MotDePasse NVARCHAR(32)
AS
BEGIN
    SELECT [UtilisateurId]
    FROM [Utilisateur]
    WHERE [Email] = @Email
      AND [MotDePasse] = [dbo].[SF_SaltAndHash](@MotDePasse, [Salt])
END