﻿CREATE PROCEDURE [dbo].[User_Delete]

	@utilisateurId UNIQUEIDENTIFIER
AS
BEGIN
	UPDATE [Utilisateur]
		SET [DateDesactivation] = GETDATE()
		WHERE [UtilisateurId] = @utilisateurId;
END
