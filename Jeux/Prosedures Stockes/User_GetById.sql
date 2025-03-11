﻿CREATE PROCEDURE [dbo].[User_GetById]
	@utilisateurId UNIQUEIDENTIFIER
AS
BEGIN
	SELECT	[UtilisateurId],
			[Pseudo],
			[Email], 
			[DateCreation], 
			[DateDesactivation]

		FROM [Utilisateur]
		WHERE [User_Id] = @user_id
END