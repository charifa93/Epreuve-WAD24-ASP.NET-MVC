CREATE PROCEDURE Etat_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT EtatId, UtilisateurId, JeuId, NomEtat
    FROM Etat;
END;
