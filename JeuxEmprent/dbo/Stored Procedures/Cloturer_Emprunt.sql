CREATE PROCEDURE Cloturer_Emprunt
    @EmpruntId UNIQUEIDENTIFIER,
    @DateRetour DATE,
    @EvaluationPreteur INT NULL,
    @EvaluationEmprunteur INT NULL
AS
BEGIN
    IF @EvaluationPreteur IS NOT NULL AND (@EvaluationPreteur < 1 OR @EvaluationPreteur > 5)
    BEGIN
        RAISERROR('L''évaluation du prêteur doit être entre 1 et 5.', 16, 1);
        RETURN;
    END;
    
    IF @EvaluationEmprunteur IS NOT NULL AND (@EvaluationEmprunteur < 1 OR @EvaluationEmprunteur > 5)
    BEGIN
        RAISERROR('L''évaluation de l''emprunteur doit être entre 1 et 5.', 16, 1);
        RETURN;
    END;
    
    UPDATE Emprunt
    SET DateRetour = @DateRetour,
        EvaluationPreteur = @EvaluationPreteur,
        EvaluationEmprunteur = @EvaluationEmprunteur
    WHERE EmpruntId = @EmpruntId;
END;