-- Datos de prueba para la base de datos de Películas
-- Script generado para facilitar pruebas y desarrollo

SET IDENTITY_INSERT [dbo].[Generos] ON 
GO
INSERT [dbo].[Generos] ([Id], [Nombre], [FechaCreacion]) VALUES (1, N'Acción', GETDATE())
INSERT [dbo].[Generos] ([Id], [Nombre], [FechaCreacion]) VALUES (2, N'Comedia', GETDATE())
INSERT [dbo].[Generos] ([Id], [Nombre], [FechaCreacion]) VALUES (3, N'Drama', GETDATE())
INSERT [dbo].[Generos] ([Id], [Nombre], [FechaCreacion]) VALUES (4, N'Ciencia Ficción', GETDATE())
INSERT [dbo].[Generos] ([Id], [Nombre], [FechaCreacion]) VALUES (5, N'Fantasía', GETDATE())
INSERT [dbo].[Generos] ([Id], [Nombre], [FechaCreacion]) VALUES (6, N'Terror', GETDATE())
INSERT [dbo].[Generos] ([Id], [Nombre], [FechaCreacion]) VALUES (7, N'Aventura', GETDATE())
INSERT [dbo].[Generos] ([Id], [Nombre], [FechaCreacion]) VALUES (8, N'Animación', GETDATE())
INSERT [dbo].[Generos] ([Id], [Nombre], [FechaCreacion]) VALUES (9, N'Romance', GETDATE())
INSERT [dbo].[Generos] ([Id], [Nombre], [FechaCreacion]) VALUES (10, N'Documental', GETDATE())
SET IDENTITY_INSERT [dbo].[Generos] OFF
GO

SET IDENTITY_INSERT [dbo].[Actores] ON 
GO
INSERT [dbo].[Actores] ([Id], [Nombre], [FotoUrl], [Biografia], [FechaCreacion]) VALUES (1, N'Robert Downey Jr.', N'https://i.pinimg.com/474x/a7/1b/89/a71b895dd5a4b54f2d174499e4cf7520.jpg', N'Actor estadounidense conocido por interpretar a Tony Stark/Iron Man en el Universo Cinematográfico de Marvel.', GETDATE())
INSERT [dbo].[Actores] ([Id], [Nombre], [FotoUrl], [Biografia], [FechaCreacion]) VALUES (2, N'Scarlett Johansson', N'https://cinescopia.com/wp-content/uploads/2011/08/Scarlett-Johansson-scarlett-johansson-8836765-1600-1200.jpg', N'Actriz y cantante estadounidense, famosa por su papel como Natasha Romanoff/Black Widow.', GETDATE())
INSERT [dbo].[Actores] ([Id], [Nombre], [FotoUrl], [Biografia], [FechaCreacion]) VALUES (3, N'Chris Evans', N'https://mx.web.img3.acsta.net/pictures/16/04/26/23/23/229144.jpg', N'Actor estadounidense conocido principalmente por su papel de Steve Rogers/Capitán América.', GETDATE())
INSERT [dbo].[Actores] ([Id], [Nombre], [FotoUrl], [Biografia], [FechaCreacion]) VALUES (4, N'Tom Hanks', N'https://example.com/th.jpg', N'Actor y productor estadounidense, ganador de dos premios Óscar consecutivos.', GETDATE())
INSERT [dbo].[Actores] ([Id], [Nombre], [FotoUrl], [Biografia], [FechaCreacion]) VALUES (5, N'Emma Stone', N'https://i.pinimg.com/564x/f4/4d/27/f44d27ffe1cd7b44a725260ad67dd286.jpg', N'Actriz estadounidense, ganadora de un Premio Óscar por su papel en La La Land.', GETDATE())
INSERT [dbo].[Actores] ([Id], [Nombre], [FotoUrl], [Biografia], [FechaCreacion]) VALUES (6, N'Leonardo DiCaprio', N'https://example.com/ld.jpg', N'Actor, productor y ambientalista estadounidense, ganador del Óscar por El Renacido.', GETDATE())
INSERT [dbo].[Actores] ([Id], [Nombre], [FotoUrl], [Biografia], [FechaCreacion]) VALUES (7, N'Jennifer Lawrence', N'https://example.com/jl.jpg', N'Actriz estadounidense, ganadora del Premio Óscar a la mejor actriz por El lado bueno de las cosas.', GETDATE())
INSERT [dbo].[Actores] ([Id], [Nombre], [FotoUrl], [Biografia], [FechaCreacion]) VALUES (8, N'Brad Pitt', N'https://example.com/bp.jpg', N'Actor y productor de cine estadounidense, ganador del Óscar como productor por 12 años de esclavitud.', GETDATE())
INSERT [dbo].[Actores] ([Id], [Nombre], [FotoUrl], [Biografia], [FechaCreacion]) VALUES (9, N'Meryl Streep', N'https://example.com/ms.jpg', N'Actriz estadounidense, considerada por la crítica como la mejor de su generación.', GETDATE())
INSERT [dbo].[Actores] ([Id], [Nombre], [FotoUrl], [Biografia], [FechaCreacion]) VALUES (10, N'Denzel Washington', N'https://example.com/dw.jpg', N'Actor, director y productor estadounidense, ganador de dos Premios Óscar.', GETDATE())
SET IDENTITY_INSERT [dbo].[Actores] OFF
GO

SET IDENTITY_INSERT [dbo].[Peliculas] ON 
GO
INSERT [dbo].[Peliculas] ([Id], [Titulo], [Sinopsis], [Anio], [ImagenUrl], [FechaCreacion]) VALUES (1, N'Los Vengadores', N'Los héroes más poderosos de la Tierra deben unirse para detener a Loki y su ejército alienígena de esclavizar a la humanidad.', 2012, N'https://i.pinimg.com/736x/0f/8e/e4/0f8ee469ca84941dd51b3db279a0fdc0.jpg', GETDATE())
INSERT [dbo].[Peliculas] ([Id], [Titulo], [Sinopsis], [Anio], [ImagenUrl], [FechaCreacion]) VALUES (2, N'El Padrino', N'La historia de la familia Corleone bajo el patriarcado de Don Vito Corleone y la transformación de su hijo Michael.', 1972, N'https://i.pinimg.com/736x/b7/6c/8c/b76c8c1a165c057609773fe5f350344b.jpg', GETDATE())
INSERT [dbo].[Peliculas] ([Id], [Titulo], [Sinopsis], [Anio], [ImagenUrl], [FechaCreacion]) VALUES (3, N'Titanic', N'Un joven artista y una aristócrata se enamoran a bordo del Titanic durante su viaje inaugural.', 1997, N'https://m.media-amazon.com/images/I/71ZJ8am0mKL._AC_UF894,1000_QL80_.jpg', GETDATE())
INSERT [dbo].[Peliculas] ([Id], [Titulo], [Sinopsis], [Anio], [ImagenUrl], [FechaCreacion]) VALUES (4, N'El Caballero Oscuro', N'Batman se enfrenta al Joker, un criminal que busca sumir a Ciudad Gótica en el caos.', 2008, N'https://pics.filmaffinity.com/El_caballero_oscuro-628375729-large.jpg', GETDATE())
INSERT [dbo].[Peliculas] ([Id], [Titulo], [Sinopsis], [Anio], [ImagenUrl], [FechaCreacion]) VALUES (5, N'La La Land', N'Un pianista de jazz y una aspirante a actriz se enamoran mientras persiguen sus sueños en Los Ángeles.', 2016, N'https://m.media-amazon.com/images/I/91PaWpDPwkL._AC_UF894,1000_QL80_.jpg', GETDATE())
INSERT [dbo].[Peliculas] ([Id], [Titulo], [Sinopsis], [Anio], [ImagenUrl], [FechaCreacion]) VALUES (6, N'El Rey León', N'Un joven león príncipe huye de su reino solo para aprender el verdadero significado de la responsabilidad y la valentía.', 1994, N'https://i0.wp.com/img-tomatazos.buscafs.com/435152/435152.png', GETDATE())
INSERT [dbo].[Peliculas] ([Id], [Titulo], [Sinopsis], [Anio], [ImagenUrl], [FechaCreacion]) VALUES (7, N'Forrest Gump', N'Las décadas en la vida de Forrest Gump, un hombre con un coeficiente intelectual por debajo de lo normal que participa en eventos históricos clave en Estados Unidos.', 1994, N'https://m.media-amazon.com/images/M/MV5BNDYwNzVjMTItZmU5YS00YjQ5LTljYjgtMjY2NDVmYWMyNWFmXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg', GETDATE())
INSERT [dbo].[Peliculas] ([Id], [Titulo], [Sinopsis], [Anio], [ImagenUrl], [FechaCreacion]) VALUES (8, N'Interestelar', N'Un grupo de exploradores utiliza un agujero de gusano recién descubierto para superar las limitaciones del viaje espacial humano y conquistar las vastas distancias involucradas en un viaje interestelar.', 2014, N'https://m.media-amazon.com/images/M/MV5BYzdjMDAxZGItMjI2My00ODA1LTlkNzItOWFjMDU5ZDJlYWY3XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg', GETDATE())
INSERT [dbo].[Peliculas] ([Id], [Titulo], [Sinopsis], [Anio], [ImagenUrl], [FechaCreacion]) VALUES (9, N'El Resplandor', N'Un escritor con bloqueo creativo y su familia pasan el invierno aislados en un hotel siniestro donde una presencia sobrenatural influye en el padre hacia la violencia.', 1980, N'https://m.media-amazon.com/images/M/MV5BNmM5ZThhY2ItOGRjOS00NzZiLWEwYTItNDgyMjFkOTgxMmRiXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg', GETDATE())
INSERT [dbo].[Peliculas] ([Id], [Titulo], [Sinopsis], [Anio], [ImagenUrl], [FechaCreacion]) VALUES (10, N'Matrix', N'Un hacker descubre la verdadera naturaleza de su realidad y su papel en la guerra contra sus controladores.', 1999, N'https://m.media-amazon.com/images/I/71D8+NFLZmL.jpg', GETDATE())
SET IDENTITY_INSERT [dbo].[Peliculas] OFF
GO

-- Asociaciones entre Películas y Géneros
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (1, 1) -- Vengadores - Acción
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (1, 4) -- Vengadores - Ciencia Ficción
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (1, 7) -- Vengadores - Aventura
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (2, 3) -- El Padrino - Drama
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (3, 3) -- Titanic - Drama
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (3, 9) -- Titanic - Romance
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (4, 1) -- El Caballero Oscuro - Acción
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (4, 3) -- El Caballero Oscuro - Drama
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (5, 3) -- La La Land - Drama
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (5, 9) -- La La Land - Romance
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (6, 8) -- El Rey León - Animación
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (6, 7) -- El Rey León - Aventura
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (7, 3) -- Forrest Gump - Drama
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (7, 2) -- Forrest Gump - Comedia
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (8, 4) -- Interestelar - Ciencia Ficción
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (8, 3) -- Interestelar - Drama
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (9, 6) -- El Resplandor - Terror
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (10, 1) -- Matrix - Acción
INSERT [dbo].[PeliculaGeneros] ([PeliculaId], [GeneroId]) VALUES (10, 4) -- Matrix - Ciencia Ficción
GO

-- Asociaciones entre Películas y Actores
INSERT [dbo].[PeliculaActores] ([PeliculaId], [ActorId], [Personaje]) VALUES (1, 1, N'Tony Stark / Iron Man')
INSERT [dbo].[PeliculaActores] ([PeliculaId], [ActorId], [Personaje]) VALUES (1, 2, N'Natasha Romanoff / Black Widow')
INSERT [dbo].[PeliculaActores] ([PeliculaId], [ActorId], [Personaje]) VALUES (1, 3, N'Steve Rogers / Capitán América')
INSERT [dbo].[PeliculaActores] ([PeliculaId], [ActorId], [Personaje]) VALUES (3, 6, N'Jack Dawson')
INSERT [dbo].[PeliculaActores] ([PeliculaId], [ActorId], [Personaje]) VALUES (5, 5, N'Mia Dolan')
INSERT [dbo].[PeliculaActores] ([PeliculaId], [ActorId], [Personaje]) VALUES (7, 4, N'Forrest Gump')
INSERT [dbo].[PeliculaActores] ([PeliculaId], [ActorId], [Personaje]) VALUES (8, 9, N'Dra. Brand')
INSERT [dbo].[PeliculaActores] ([PeliculaId], [ActorId], [Personaje]) VALUES (10, 2, N'Trinity')
GO

-- Roles y usuarios de prueba (ASP.NET Identity)
-- (Nota: Las contraseñas no están hasheadas, estos datos son solo para generar IDs consistentes)
-- En un entorno real, usar ASP.NET Identity API para crear usuarios/roles con contraseñas seguras

-- Roles básicos
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) 
VALUES (N'1', N'Admin', N'ADMIN', N'9992f35f-0c3f-4ac9-a1f3-db94a96a1300')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) 
VALUES (N'2', N'Usuario', N'USUARIO', N'cb91c64b-5030-4a8c-9e4b-6a1c8d63cc73')

-- Usuarios de prueba
-- (En producción, estas contraseñas deben hashearse usando Identity)
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], 
                               [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], 
                               [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Nombre], [FechaCreacion]) 
VALUES (
    N'7ef98c38-fa1f-478b-9b9a-4b9a146f5826', -- ID
    N'admin@example.com', -- UserName
    N'ADMIN@EXAMPLE.COM', -- NormalizedUserName
    N'admin@example.com', -- Email
    N'ADMIN@EXAMPLE.COM', -- NormalizedEmail
    1, -- EmailConfirmed
    N'AQAAAAIAAYagAAAAEAZLOnoABEu3ZqYBLq9TtH7MgXCYgqmG4CaxphQgL9P+SIrodoYRWnfDCuCGvgZUJw==', -- PasswordHash (Contraseña: Admin123!)
    N'AVKMOVOKJVEZAWEKPODCZXLIDOVNTMMP', -- SecurityStamp 
    N'99f87817-47f9-45e7-b967-e5ede889a354', -- ConcurrencyStamp
    NULL, -- PhoneNumber
    0, -- PhoneNumberConfirmed
    0, -- TwoFactorEnabled
    NULL, -- LockoutEnd
    1, -- LockoutEnabled
    0, -- AccessFailedCount
    N'Administrador', -- Nombre
    GETDATE() -- FechaCreacion
)

INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], 
                               [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], 
                               [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Nombre], [FechaCreacion]) 
VALUES (
    N'3b9c9b6e-9d95-43ca-9254-0b38e1a483fe', -- ID
    N'usuario@example.com', -- UserName
    N'USUARIO@EXAMPLE.COM', -- NormalizedUserName
    N'usuario@example.com', -- Email
    N'USUARIO@EXAMPLE.COM', -- NormalizedEmail
    1, -- EmailConfirmed
    N'AQAAAAIAAYagAAAAEEzdz0Q9w49QgFfIZsNEQqW0oR7HHnp9h9HV/7YUtQVJ5kQpzXvV47qj7lo9d3l/iQ==', -- PasswordHash (Contraseña: Usuario123!)
    N'JCPUIKBZRJ33UBRFCJ6PAZ4QRXQ3ZPVW', -- SecurityStamp 
    N'b9b07ad4-5d95-4b96-bcbc-13a5e0a98633', -- ConcurrencyStamp
    NULL, -- PhoneNumber
    0, -- PhoneNumberConfirmed
    0, -- TwoFactorEnabled
    NULL, -- LockoutEnd
    1, -- LockoutEnabled
    0, -- AccessFailedCount
    N'Usuario Normal', -- Nombre
    GETDATE() -- FechaCreacion
)

-- Asignación de roles a usuarios
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
VALUES (N'7ef98c38-fa1f-478b-9b9a-4b9a146f5826', N'1') -- Admin tiene rol de Admin

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
VALUES (N'3b9c9b6e-9d95-43ca-9254-0b38e1a483fe', N'2') -- Usuario tiene rol de Usuario