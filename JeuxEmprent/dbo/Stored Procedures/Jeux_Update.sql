CREATE PROCEDURE Jeux_Update
    @UtilisateurId UNIQUEIDENTIFIER,
    @JeuId UNIQUEIDENTIFIER,
    @NomEtat NVARCHAR(50)
AS
BEGIN
    -- Vérifier si l'état passé est valide
    IF @NomEtat NOT IN ('Neuf', 'Abimé', 'Incomplet')
    BEGIN
        RAISERROR('état du jeu est invalide.', 16, 1);
        RETURN;
    END

    -- Vérifier si l'état à mettre à jour existe pour cet utilisateur et jeu
    IF NOT EXISTS (SELECT 1 FROM Etat WHERE UtilisateurId = @UtilisateurId AND JeuId = @JeuId)
    BEGIN
        RAISERROR('état du jeu existe pas pour cet utilisateur.', 16, 1);
        RETURN;
    END
    
    -- Mettre à jour l'état du jeu
    UPDATE Etat
    SET NomEtat = @NomEtat
    WHERE UtilisateurId = @UtilisateurId
END
