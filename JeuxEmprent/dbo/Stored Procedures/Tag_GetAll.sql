CREATE PROCEDURE Tag_GetAll
AS
BEGIN
    SELECT 
        TagId, 
        NomTag
    FROM Tag
    ORDER BY NomTag;
END;
