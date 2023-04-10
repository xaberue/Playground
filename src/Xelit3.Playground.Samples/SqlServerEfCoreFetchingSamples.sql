DECLARE @__p_0 as int = 10

-- Multiple elements
--1. Normal Execution
SELECT [t].[Id], [t].[BirthDate], [t].[Name], [t].[OriginId], [t].[Surname], [a].[Id], [a].[CityId], [a].[Line], [a].[PersonId], [a].[Sequence], [p0].[Id], [p0].[AuthorId], [p0].[Text], [p0].[Title]
FROM (
    SELECT TOP(@__p_0) [p].[Id], [p].[BirthDate], [p].[Name], [p].[OriginId], [p].[Surname]
    FROM [Persons_int] AS [p]
) AS [t]
	LEFT JOIN [Addresses_int] AS [a] ON [t].[Id] = [a].[PersonId]
	LEFT JOIN [Posts_int] AS [p0] ON [t].[Id] = [p0].[AuthorId]
ORDER BY [t].[Id], [a].[Id]
	  
--2. Normal exeuction with AsNoTracking, in SQL nothing changes
SELECT [t].[Id], [t].[BirthDate], [t].[Name], [t].[OriginId], [t].[Surname], [a].[Id], [a].[CityId], [a].[Line], [a].[PersonId], [a].[Sequence], [p0].[Id], [p0].[AuthorId], [p0].[Text], [p0].[Title]
FROM (
    SELECT TOP(@__p_0) [p].[Id], [p].[BirthDate], [p].[Name], [p].[OriginId], [p].[Surname]
    FROM [Persons_int] AS [p]
) AS [t]
	LEFT JOIN [Addresses_int] AS [a] ON [t].[Id] = [a].[PersonId]
	LEFT JOIN [Posts_int] AS [p0] ON [t].[Id] = [p0].[AuthorId]
ORDER BY [t].[Id], [a].[Id]

--3. Using SplitQueries only executes a query for users
SELECT TOP(@__p_0) [p].[Id], [p].[BirthDate], [p].[Name], [p].[OriginId], [p].[Surname]
FROM [Persons_int] AS [p]
ORDER BY [p].[Id]

-- Single element
--1. Normal Execution
SELECT [t].[Id], [t].[BirthDate], [t].[Name], [t].[OriginId], [t].[Surname], [a].[Id], [a].[CityId], [a].[Line], [a].[PersonId], [a].[Sequence], [p0].[Id], [p0].[AuthorId], [p0].[Text], [p0].[Title]
FROM (
    SELECT TOP(1) [p].[Id], [p].[BirthDate], [p].[Name], [p].[OriginId], [p].[Surname]
    FROM [Persons_int] AS [p]
) AS [t]
LEFT JOIN [Addresses_int] AS [a] ON [t].[Id] = [a].[PersonId]
LEFT JOIN [Posts_int] AS [p0] ON [t].[Id] = [p0].[AuthorId]
ORDER BY [t].[Id], [a].[Id]

--2. Using SplitQueries only executes a query for users
SELECT TOP(1) [p].[Id], [p].[BirthDate], [p].[Name], [p].[OriginId], [p].[Surname]
FROM [Persons_int] AS [p]
ORDER BY [p].[Id]

SELECT [a].[Id], [a].[CityId], [a].[Line], [a].[PersonId], [a].[Sequence], [t].[Id]
FROM (
    SELECT TOP(1) [p].[Id]
    FROM [Persons_int] AS [p]
) AS [t]
INNER JOIN [Addresses_int] AS [a] ON [t].[Id] = [a].[PersonId]
ORDER BY [t].[Id]

SELECT [p0].[Id], [p0].[AuthorId], [p0].[Text], [p0].[Title], [t].[Id]
FROM (
    SELECT TOP(1) [p].[Id]
    FROM [Persons_int] AS [p]
) AS [t]
INNER JOIN [Posts_int] AS [p0] ON [t].[Id] = [p0].[AuthorId]
ORDER BY [t].[Id]


--3. Using explicit loading only executes a query for users, then for Addresses, subsequent queries will not be captured in the console because you must concatenate Query and Load.
SELECT TOP(1) [p].[Id], [p].[BirthDate], [p].[Name], [p].[OriginId], [p].[Surname]
FROM [Persons_int] AS [p]

DECLARE @__p_1 as int = 4857081

SELECT a.Id, a.CityId, a.Line, a.PersonId, a.Sequence
FROM Addresses_int AS a
WHERE a.PersonId = @__p_1