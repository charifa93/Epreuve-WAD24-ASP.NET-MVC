CREATE TABLE [dbo].[Etat] (
    [EtatId]        UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [UtilisateurId] UNIQUEIDENTIFIER NOT NULL,
    [JeuId]         UNIQUEIDENTIFIER NOT NULL,
    [NomEtat]       NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([EtatId] ASC),
    CHECK ([NomEtat]='Incomplet' OR [NomEtat]='Abimé' OR [NomEtat]='Neuf'),
    FOREIGN KEY ([JeuId]) REFERENCES [dbo].[Jeux] ([JeuId]) ON DELETE CASCADE,
    FOREIGN KEY ([UtilisateurId]) REFERENCES [dbo].[Utilisateur] ([UtilisateurId]) ON DELETE CASCADE
);

