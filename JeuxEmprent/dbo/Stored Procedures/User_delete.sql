CREATE PROCEDURE User_delete
    @UtilisateurId UNIQUEIDENTIFIER
AS
BEGIN
    UPDATE Utilisateur SET DateDesactivation = GETDATE() WHERE UtilisateurId = @UtilisateurId;
END;
