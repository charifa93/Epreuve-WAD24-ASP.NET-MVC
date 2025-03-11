CREATE PROCEDURE User_UpdatePseudo
    @UtilisateurId UNIQUEIDENTIFIER,
    @NewPseudo NVARCHAR(100)
AS
BEGIN
    -- Vérifier que le pseudonyme n'est pas déjà utilisé par un autre utilisateur
    IF EXISTS (SELECT 1 FROM Utilisateur WHERE Pseudo = @NewPseudo)
    BEGIN
        RAISERROR('Le pseudonyme est déjà pris.', 16, 1);
        RETURN;
    END

    -- Mettre à jour uniquement le pseudonyme de l'utilisateur
    UPDATE Utilisateur
    SET Pseudo = @NewPseudo
    WHERE UtilisateurId = @UtilisateurId;

END;
