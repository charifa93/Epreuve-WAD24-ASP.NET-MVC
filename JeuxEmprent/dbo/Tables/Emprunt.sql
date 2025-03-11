CREATE TABLE [dbo].[Emprunt] (
    [EmpruntId]            UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [PreteurId]            UNIQUEIDENTIFIER NULL,
    [EmprunteurId]         UNIQUEIDENTIFIER NULL,
    [JeuId]                UNIQUEIDENTIFIER NULL,
    [DateEmprunt]          DATE             NOT NULL,
    [DateRetour]           DATE             NULL,
    [EvaluationPreteur]    INT               NULL,
    [EvaluationEmprunteur] INT              NULL,
    PRIMARY KEY CLUSTERED ([EmpruntId] ASC),
    CHECK ([EvaluationEmprunteur]>=(0) AND [EvaluationEmprunteur]<=(5)),
    CHECK ([EvaluationPreteur]>=(0) AND [EvaluationPreteur]<=(5)),
    FOREIGN KEY ([EmprunteurId]) REFERENCES [dbo].[Utilisateur] ([UtilisateurId]),
    FOREIGN KEY ([JeuId]) REFERENCES [dbo].[Jeux] ([JeuId]) ON DELETE CASCADE,
    FOREIGN KEY ([PreteurId]) REFERENCES [dbo].[Utilisateur] ([UtilisateurId])
);

