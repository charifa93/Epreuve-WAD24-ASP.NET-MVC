CREATE TABLE [dbo].[Jeux] (
    [JeuId]        UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Nom]          NVARCHAR (255)   NOT NULL,
    [Description]  TEXT             NULL,
    [AgeMin]       INT              NOT NULL,
    [AgeMax]       INT              NOT NULL,
    [NbJoueurMin]  INT              NOT NULL,
    [NbJoueurMax]  INT              NOT NULL,
    [DureeMinute]  INT              NULL,
    [DateCreation] DATE             DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([JeuId] ASC),
    CONSTRAINT [CK_Age] CHECK ([AgeMin]<[AgeMax]),
    CONSTRAINT [CK_NbJoueur] CHECK ([NbJoueurMin]<=[NbJoueurMax])
);

