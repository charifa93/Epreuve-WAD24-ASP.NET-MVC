CREATE PROCEDURE User_GetById
    @UtilisateurId UNIQUEIDENTIFIER
AS
BEGIN
    -- Sélectionner les informations de l'utilisateur et les jeux qu'il possède avec leur état
    SELECT
        u.UtilisateurId,
        u.Email,
        u.Pseudo,
        u.DateCreation AS DateCreationUtilisateur,
        u.DateDesactivation AS DateDesactivationUtilisateur,
        
        -- Détails des jeux possédés par l'utilisateur
        j.JeuId,
        j.Nom AS NomJeu,
        j.Description AS DescriptionJeu,
        j.AgeMin,
        j.AgeMax,
        j.NbJoueurMin,
        j.NbJoueurMax,
        j.DureeMinute,
        
        -- Etat du jeu
        e.NomEtat AS EtatJeu
    FROM
        Utilisateur u
        INNER JOIN Etat e ON u.UtilisateurId = e.UtilisateurId
        INNER JOIN Jeux j ON e.JeuId = j.JeuId
    WHERE
        u.UtilisateurId = @UtilisateurId;
END;