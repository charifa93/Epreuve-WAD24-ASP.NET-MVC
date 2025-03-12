INSERT INTO [dbo].[Utilisateur] ([UtilisateurId], [Email], [MotDePasse], [Salt], [Pseudo], [DateCreation], [DateDesactivation])
VALUES 
  (NEWID(), 'alice.durand@example.com', 'hashed_password_1', NEWID(), 'AliceD', GETDATE(), NULL),
  (NEWID(), 'bob.martin@example.com', 'hashed_password_2', NEWID(), 'BobM', DATEADD(DAY, -10, GETDATE()), NULL),
  (NEWID(), 'charles.dupont@example.com', 'hashed_password_3', NEWID(), 'CharlieD', DATEADD(DAY, -20, GETDATE()), NULL),
  (NEWID(), 'diane.leclerc@example.com', 'hashed_password_4', NEWID(), 'DianeL', DATEADD(DAY, -30, GETDATE()), NULL),
  (NEWID(), 'eric.lambert@example.com', 'hashed_password_5', NEWID(), 'EricL', DATEADD(DAY, -40, GETDATE()), DATEADD(DAY, -5, GETDATE()));
