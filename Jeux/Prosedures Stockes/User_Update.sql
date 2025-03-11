﻿CREATE PROCEDURE [dbo].[User_Update]
	@pseudo NVARCHAR(64),
	@email NVARCHAR(320),
	@utilisateurId UNIQUEIDENTIFIER
AS
BEGIN
	UPDATE [Utilisateur]
		SET	[Pseudo] = @pseudo,
			[Email] = @email
		WHERE [UtilisateurId] = @utilisateurId
END
