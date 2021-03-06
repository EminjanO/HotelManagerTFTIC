-- LOAD TABLES

CREATE TABLE [dbo].[profil](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[profil_name] [varchar](20) NOT NULL,
	[description] [varchar](max),
	[isActive] [bit] NOT NULL DEFAULT ((1)))

CREATE TABLE [dbo].[User](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[lastName] [varchar](50) NOT NULL,
	[firstName] [varchar](50) NOT NULL,
	[create_date] [datetime] NOT NULL DEFAULT (getdate()),
	[last_update] [datetime] NOT NULL DEFAULT (getdate()),
	[isActive] [bit] NOT NULL DEFAULT ((1)),
	[id_profil] [int] NOT NULL CONSTRAINT FK_user_profil REFERENCES profil (id))

CREATE TABLE [dbo].[state_room](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[state_name] [varchar](20) NOT NULL,
	[created_at] [datetime] NOT NULL DEFAULT (getdate()),
	[last_update] [datetime] NOT NULL DEFAULT (getdate()))

CREATE TABLE [dbo].[type_room](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[type_name] [varchar](20) NOT NULL,
	[capacity] [int] NOT NULL,
	[price] [decimal](10, 0) NOT NULL,
	[kitchen] [bit] NOT NULL,
	[tub] [bit] NOT NULL,
	[created_at] [datetime] NOT NULL DEFAULT (getdate()),
	[last_update] [datetime] NOT NULL DEFAULT (getdate()),
	[isActive] [bit] NOT NULL DEFAULT ((1)))

CREATE TABLE [dbo].[room](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[num] [varchar](10) NOT NULL CONSTRAINT UK_num_room UNIQUE (num),
	[add_info] [varchar](255),
	[created_at] [datetime] NOT NULL DEFAULT (getdate()),
	[last_update] [datetime] NOT NULL DEFAULT (getdate()),
	[isActive] [bit] NOT NULL DEFAULT ((1)),
	[id_state_room] [int] NOT NULL CONSTRAINT FK_room_state REFERENCES state_room (id), 
	[id_type_room] [int] NOT NULL CONSTRAINT FK_room_type REFERENCES type_room (id))

CREATE TABLE [dbo].[guest](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[firstname] [varchar](50) NOT NULL,
	[lastname] [varchar](50) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[phone] [varchar](50) NOT NULL,
	[add_info] [varchar](255),
	[created_at] [datetime] NOT NULL DEFAULT (getdate()),
	[last_update] [datetime] NOT NULL DEFAULT (getdate()),
	[isActive] [bit] NOT NULL DEFAULT ((1)))

CREATE TABLE [dbo].[booking](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[check_in] [datetime] NOT NULL,
	[check_out] [datetime] NOT NULL,
	[nb_night] [int] NOT NULL,
	[nb_person] [int] NOT NULL,
	[add_info] [varchar](255),
	[created_at] [datetime] NOT NULL DEFAULT (getdate()),
	[last_update] [datetime] NOT NULL DEFAULT (getdate()),
	[isCreated] [bit] NOT NULL DEFAULT ((1)),
	[isActive] [bit] NOT NULL DEFAULT ((1)),
	[hasPayed] [bit] NOT NULL DEFAULT ((0)),
	[id_guest] [int] NOT NULL CONSTRAINT FK_booking_guest REFERENCES guest (id), 
	[id_room] [int] NOT NULL CONSTRAINT FK_booking_room REFERENCES room (id), 
	[id_user] [int] NOT NULL CONSTRAINT FK_booking_user REFERENCES [user] (id)) 