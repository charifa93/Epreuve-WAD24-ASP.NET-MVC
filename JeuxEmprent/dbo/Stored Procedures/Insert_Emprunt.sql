CREATE PROCEDURE Insert_Emprunt
    @PreteurId UNIQUEIDENTIFIER,
    @EmprunteurId UNIQUEIDENTIFIER,
    @JeuId UNIQUEIDENTIFIER,
    @DateEmprunt DATE
AS
BEGIN
    IF @PreteurId = @EmprunteurId
    BEGIN
        RAISERROR('Un utilisateur ne peut pas emprunter son propre jeu.', 16, 1);
        RETURN;
    END;
    
    INSERT INTO Emprunt (EmpruntId, PreteurId, EmprunteurId, JeuId, DateEmprunt)
    VALUES (NEWID(), @PreteurId, @EmprunteurId, @JeuId, @DateEmprunt);
END;