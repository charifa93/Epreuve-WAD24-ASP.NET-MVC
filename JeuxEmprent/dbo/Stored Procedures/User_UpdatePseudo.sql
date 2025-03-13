CREATE PROCEDURE User_UpdatePseudo
    @UtilisateurId UNIQUEIDENTIFIER,
    @Pseudo NVARCHAR(100)
AS
BEGIN
   

    UPDATE Utilisateur
    SET Pseudo = @Pseudo
    WHERE UtilisateurId = @UtilisateurId;
    
   
END;
