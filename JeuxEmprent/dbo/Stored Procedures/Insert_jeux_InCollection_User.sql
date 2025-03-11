CREATE PROCEDURE [dbo].[Insert_jeux_InCollection_User]
    @UtilisateurId UNIQUEIDENTIFIER,
    @JeuId UNIQUEIDENTIFIER,
    @NomEtat NVARCHAR(50)
AS
BEGIN
    IF @NomEtat NOT IN ('Neuf', 'Abimé')
    BEGIN
        RAISERROR('NomEtat invalide. Veuillez choisir parmi: Neuf, Abimé.', 16, 1);
        RETURN;
    END;
    
    IF NOT EXISTS (
        SELECT 1 FROM Etat WHERE UtilisateurId = @UtilisateurId AND JeuId = @JeuId
    )
    BEGIN
        INSERT INTO Etat (EtatId, UtilisateurId, JeuId, NomEtat)
        VALUES (NEWID(), @UtilisateurId, @JeuId, @NomEtat);
    END
END;
