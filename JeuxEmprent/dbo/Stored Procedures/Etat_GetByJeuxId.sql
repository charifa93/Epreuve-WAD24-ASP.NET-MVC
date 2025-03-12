CREATE PROCEDURE Etat_GetByJeuxId
    @JeuId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT EtatId, UtilisateurId, JeuId, NomEtat
    FROM Etat
    WHERE JeuId = @JeuId;
END;