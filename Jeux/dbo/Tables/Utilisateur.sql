CREATE TABLE [dbo].[Utilisateur] (
    [UtilisateurId]     UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Email]             NVARCHAR (255)   NOT NULL,
    [MotDePasse]        NVARCHAR (255)   NOT NULL,
    [Salt]              UNIQUEIDENTIFIER NOT NULL,
    [Pseudo]            NVARCHAR (100)   NOT NULL,
    [DateCreation]      DATE             DEFAULT (getdate()) NULL,
    [DateDesactivation] DATE             NULL,
    PRIMARY KEY CLUSTERED ([UtilisateurId] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC),
    UNIQUE NONCLUSTERED ([Pseudo] ASC)
);

