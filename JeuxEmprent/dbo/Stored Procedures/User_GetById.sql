CREATE PROCEDURE User_GetById
    @UtilisateurId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        UtilisateurId,
        Email,
        Pseudo,
        DateCreation,
        DateDesactivation
    FROM Utilisateur
    WHERE UtilisateurId = @UtilisateurId;
END;

