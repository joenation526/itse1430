﻿--
-- Gets all the movies.
--
-- PARAMS: None.
-- 
-- RETURNS: The movies.
--
CREATE PROCEDURE [dbo].[GetMovies]	
AS BEGIN
    SET NOCOUNT ON;

    --SELECT * 
    SELECT Id, Name, Description, Genre, ReleaseYear, RunLength, IsClassic
    FROM Movies
END

