CREATE PROCEDURE Top10JeuxEmpruntes
AS
BEGIN
    SELECT TOP 10
	          j.Nom,
			  
			  j.AgeMin,
			  j.AgeMax,
			  j.DateCreation,
			  j.DureeMinute,
			  j.NbJoueurMax,
			  j.NbJoueurMin
	              , COUNT(e.EmpruntId) AS NombreEmprunts
    FROM Emprunt e
    JOIN Jeux j ON e.JeuId = j.JeuId
    GROUP BY j.Nom,
			 
			  j.AgeMin,
			  j.AgeMax,
			  j.DateCreation,
			  j.DureeMinute,
			  j.NbJoueurMax,
			  j.NbJoueurMin
    ORDER BY NombreEmprunts DESC;
END;
