USE [Agenda2015]
GO
/****** Object:  Table [dbo].[persoane]    Script Date: 4/21/2018 3:49:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persoane](
	[idPersoana] [int] IDENTITY(1,1) NOT NULL,
	[nume] [nvarchar](30) NOT NULL,
	[adresa] [nvarchar](100) NULL,
 CONSTRAINT [PK_persoane] PRIMARY KEY CLUSTERED 
(
	[idPersoana] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[telefoane]    Script Date: 4/21/2018 3:49:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[telefoane](
	[idTelefon] [int] IDENTITY(1,1) NOT NULL,
	[idPersoana] [int] NOT NULL,
	[numarTelefon] [varchar](15) NOT NULL,
	[descriere] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_telefoane] PRIMARY KEY CLUSTERED 
(
	[idTelefon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[persoane] ON 

INSERT [dbo].[persoane] ([idPersoana], [nume], [adresa]) VALUES (1, N'popescu', N'Codlea')
INSERT [dbo].[persoane] ([idPersoana], [nume], [adresa]) VALUES (2, N'georgescu', N'Brasov')
INSERT [dbo].[persoane] ([idPersoana], [nume], [adresa]) VALUES (3, N'Ion', N'Bucuresti')
INSERT [dbo].[persoane] ([idPersoana], [nume], [adresa]) VALUES (5, N'Cineva', N'Brasov')
INSERT [dbo].[persoane] ([idPersoana], [nume], [adresa]) VALUES (6, N'qqq', NULL)
SET IDENTITY_INSERT [dbo].[persoane] OFF
SET IDENTITY_INSERT [dbo].[telefoane] ON 

INSERT [dbo].[telefoane] ([idTelefon], [idPersoana], [numarTelefon], [descriere]) VALUES (1, 1, N'1234', N'de acasa')
INSERT [dbo].[telefoane] ([idTelefon], [idPersoana], [numarTelefon], [descriere]) VALUES (2, 1, N'2345', N'de la birou')
INSERT [dbo].[telefoane] ([idTelefon], [idPersoana], [numarTelefon], [descriere]) VALUES (3, 1, N'3456', N'numar de mobil')
INSERT [dbo].[telefoane] ([idTelefon], [idPersoana], [numarTelefon], [descriere]) VALUES (4, 3, N'1234567        ', N'de acasa')
INSERT [dbo].[telefoane] ([idTelefon], [idPersoana], [numarTelefon], [descriere]) VALUES (5, 5, N'123456         ', N'de la birou')
SET IDENTITY_INSERT [dbo].[telefoane] OFF
ALTER TABLE [dbo].[telefoane]  WITH CHECK ADD  CONSTRAINT [FK_telefoane_persoane] FOREIGN KEY([idPersoana])
REFERENCES [dbo].[persoane] ([idPersoana])
GO
ALTER TABLE [dbo].[telefoane] CHECK CONSTRAINT [FK_telefoane_persoane]
GO
/****** Object:  StoredProcedure [dbo].[AddPerson]    Script Date: 4/21/2018 3:49:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddPerson] 
	@nume nvarchar(30),
	@adresa nvarchar(100),
	@idPersoana int output
AS
BEGIN
	insert into persoane(nume, adresa)
	values (@nume, @adresa);
	select @idPersoana = scope_identity();
END
GO
/****** Object:  StoredProcedure [dbo].[AddPerson2]    Script Date: 4/21/2018 3:49:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[AddPerson2]
	@n nvarchar(30),
	@a nvarchar(100)
AS
BEGIN
	insert into persoane values(@n, @a)	
END
GO
/****** Object:  StoredProcedure [dbo].[AddPhoneForPerson]    Script Date: 4/21/2018 3:49:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddPhoneForPerson]
	@idPersoana int,
	@numarTelefon char(15),
	@descriere nvarchar(20),
	@idTelefon int output
AS
BEGIN
	insert into telefoane(idPersoana, numarTelefon, descriere)
	values(@idPersoana, @numarTelefon, @descriere)
	
	select @idTelefon = scope_identity()
END
GO
/****** Object:  StoredProcedure [dbo].[AddPhoneForPerson2]    Script Date: 4/21/2018 3:49:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddPhoneForPerson2]
	@idPersoana int,
	@numarTelefon char(15),
	@descriere nvarchar(20)
AS
BEGIN
	insert into telefoane(idPersoana, numarTelefon, descriere)
	values(@idPersoana, @numarTelefon, @descriere)
END
GO
/****** Object:  StoredProcedure [dbo].[DeletePerson]    Script Date: 4/21/2018 3:49:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeletePerson]
	@idPersoana int
AS
BEGIN
	delete from persoane
	where idPersoana = @idPersoana
END
GO
/****** Object:  StoredProcedure [dbo].[DeletePhone]    Script Date: 4/21/2018 3:49:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeletePhone]
	@idTelefon int
AS
BEGIN
	delete from telefoane
	where IdTelefon = @idTelefon
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllPersons]    Script Date: 4/21/2018 3:49:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllPersons]
AS
BEGIN
	SELECT idPersoana, nume, adresa
	from persoane
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllPersonsWithNoPhone]    Script Date: 4/21/2018 3:49:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllPersonsWithNoPhone] 
AS
BEGIN
	SELECT idPersoana, nume, adresa
	from persoane 
	where idPersoana not in 
	(
		select distinct idPersoana 
		from telefoane
	)
	--se mai poate scrie:

	/*SELECT idPersoana, nume, adresa
	from persoane 
	where not exists
	(
		select 1 
		from telefoane
		where telefoane.idPersoana = persoane.idPersoana
	)*/

	--sau

	/*select persoane.idPersoana, nume, adresa
	from persoane left join telefoane
	on persoane.idPersoana = telefoane.idPersoana
	where numarTelefon is null*/

END
GO
/****** Object:  StoredProcedure [dbo].[GetPhonesForPerson]    Script Date: 4/21/2018 3:49:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPhonesForPerson] 
	@idPersoana int
AS
BEGIN
	SELECT idTelefon, idPersoana, numarTelefon, descriere
	from telefoane
	where idPersoana = @idPersoana
END
GO
/****** Object:  StoredProcedure [dbo].[ModifyPerson]    Script Date: 4/21/2018 3:49:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModifyPerson] 
	@idPersoana int,
	@nume nvarchar(30),
	@adresa nvarchar(100)
AS
BEGIN
	update persoane
	set nume = @nume, adresa = @adresa
	where idPersoana = @idPersoana
END
GO
/****** Object:  StoredProcedure [dbo].[ModifyPhone]    Script Date: 4/21/2018 3:49:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModifyPhone]
	@idPersoana int,
	@numarTelefon char(15),
	@descriere nvarchar(20),
	@idTelefon int
AS
BEGIN
	Update telefoane
	Set idPersoana = @idPersoana, 
		numarTelefon = @numarTelefon, 
		descriere = @descriere
	Where idTelefon = @idTelefon
END
GO