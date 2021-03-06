USE [flowers_Ermoshina]
GO
/****** Object:  Table [dbo].[supplier]    Script Date: 01/22/2018 13:00:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[supplier](
	[id_supplier] [int] IDENTITY(1,1) NOT NULL,
	[naim] [char](20) NOT NULL,
	[adres] [char](60) NOT NULL,
	[tel] [numeric](11, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_supplier] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[klient]    Script Date: 01/22/2018 13:00:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[klient](
	[id_klient] [int] IDENTITY(1,1) NOT NULL,
	[fio_klient] [char](30) NOT NULL,
	[tel] [numeric](11, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_klient] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VID_TOVARA]    Script Date: 01/22/2018 13:00:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VID_TOVARA](
	[ID_VID] [int] IDENTITY(1,1) NOT NULL,
	[NAIM_VID] [char](20) NOT NULL,
	[VID] [char](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_VID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TOVAR]    Script Date: 01/22/2018 13:00:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TOVAR](
	[ID_TOVAR] [int] IDENTITY(1,1) NOT NULL,
	[NAIM_TOVAR] [char](100) NOT NULL,
	[ID_VID] [int] NOT NULL,
	[KOLVO] [int] NOT NULL,
	[PRICE] [int] NOT NULL,
 CONSTRAINT [PK__TOVAR__F846CF8E0AD2A005] PRIMARY KEY CLUSTERED 
(
	[ID_TOVAR] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[add_klient]    Script Date: 01/22/2018 13:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[add_klient]
@fio_klient char(30),
@tel char(15)
as
begin
insert into klient(FIO_klient,tel) values(@fio_klient,@tel)
end
GO
/****** Object:  StoredProcedure [dbo].[add_supplier]    Script Date: 01/22/2018 13:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[add_supplier]
@naim char(20),
@adres char(60),
@tel numeric(11,0)
as
begin
insert into supplier(NAIM, adres,tel) values(@naim,@adres,@tel)
end
GO
/****** Object:  StoredProcedure [dbo].[add_vid]    Script Date: 01/22/2018 13:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[add_vid]
@naim_vid char(20),
@vid char(15)
as
begin
insert into VID_TOVARA(NAIM_VID,VID) values(@naim_vid,@vid)

end
GO
/****** Object:  StoredProcedure [dbo].[add_tovar]    Script Date: 01/22/2018 13:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[add_tovar]
@naim_tovar char(120),
@id_vid int,
@kolvo int,
@price int
as
begin
insert into TOVAR(NAIM_tovar,ID_VID,KOLVO,PRICE) values(@naim_tovar,@id_vid,@kolvo,@price)
end
GO
/****** Object:  Table [dbo].[sale]    Script Date: 01/22/2018 13:00:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sale](
	[id_sale] [int] IDENTITY(1,1) NOT NULL,
	[data_sale] [date] NOT NULL,
	[kolvo_sale] [int] NOT NULL,
	[id_tovar] [int] NOT NULL,
	[price_sale] [numeric](5, 2) NOT NULL,
 CONSTRAINT [PK__sale__D18B015720C1E124] PRIMARY KEY CLUSTERED 
(
	[id_sale] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[update_tovar]    Script Date: 01/22/2018 13:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[update_tovar]
@id_tovar int,
@kolvo_p int
as
update TOVAR set KOLVO=KOLVO+@kolvo_p
GO
/****** Object:  StoredProcedure [dbo].[price_list]    Script Date: 01/22/2018 13:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[price_list]
as
SELECT     VID_TOVARA.NAIM_VID as[Вид товара], TOVAR.NAIM_TOVAR as[Название товара], TOVAR.KOLVO as[Кол-во], TOVAR.PRICE as [Цена]
FROM         TOVAR INNER JOIN
                      VID_TOVARA ON TOVAR.ID_VID = VID_TOVARA.ID_VID
GO
/****** Object:  Table [dbo].[postavka]    Script Date: 01/22/2018 13:00:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[postavka](
	[id_post] [int] IDENTITY(1,1) NOT NULL,
	[date_post] [date] NOT NULL,
	[kolvo] [int] NOT NULL,
	[price] [numeric](5, 2) NOT NULL,
	[id_supplier] [int] NOT NULL,
	[id_tovar] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_post] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zakaz]    Script Date: 01/22/2018 13:00:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[zakaz](
	[id_zakaz] [int] IDENTITY(1,1) NOT NULL,
	[data_zakaz] [date] NOT NULL,
	[kolvo_zakaz] [int] NOT NULL,
	[adres_zakaz] [char](50) NOT NULL,
	[plan_data] [date] NOT NULL,
	[fakt_data] [date] NULL,
	[status] [int] NOT NULL,
	[id_tovar] [int] NOT NULL,
	[id_klient] [int] NOT NULL,
 CONSTRAINT [PK__zakaz__8FEEE0851A14E395] PRIMARY KEY CLUSTERED 
(
	[id_zakaz] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[zadanie_zakaz]    Script Date: 01/22/2018 13:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[zadanie_zakaz]
@data1 date, @data2 date
as
select VID_TOVARA.NAIM_VID as [Вид], TOVAR.NAIM_TOVAR as [Наименование товара], tovar.KOLVO as [Кол-во в наличии], SUM(zakaz.kolvo_zakaz) as [Кол-во заказанного]
from VID_TOVARA, TOVAR, Zakaz
where TOVAR.ID_VID = VID_TOVARA.ID_VID and zakaz.id_tovar = TOVAR.ID_TOVAR and zakaz.data_zakaz <= @data2 and zakaz.data_zakaz>= @data1 
group by VID_TOVARA.NAIM_VID, TOVAR.NAIM_TOVAR, tovar.KOLVO
GO
/****** Object:  StoredProcedure [dbo].[Update_zakaz]    Script Date: 01/22/2018 13:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Update_zakaz]
@fakt_data date,@ID_zakaz int
AS

UPDATE zakaz SET fakt_data=@fakt_data, status=1 WHERE ID_zakaz=@ID_zakaz
GO
/****** Object:  StoredProcedure [dbo].[report_tovar]    Script Date: 01/22/2018 13:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[report_tovar]
@data1 date, @data2 date
as
SELECT     VID_TOVARA.NAIM_VID as[Вид Товара], TOVAR.NAIM_TOVAR as[Товар], sale.kolvo_sale as[Кол-во проданного товара], sale.price_sale as[Цена проданного товара], SUM(kolvo_sale*price_sale) as Сумма
FROM         TOVAR INNER JOIN
                      VID_TOVARA ON TOVAR.ID_VID = VID_TOVARA.ID_VID INNER JOIN
                      sale ON TOVAR.ID_TOVAR = sale.id_tovar 
where Sale.data_sale>=@data1 and Sale.data_sale<=@data2
group by   VID_TOVARA.NAIM_VID, TOVAR.NAIM_TOVAR, sale.kolvo_sale, sale.price_sale
GO
/****** Object:  StoredProcedure [dbo].[print_zakaz]    Script Date: 01/22/2018 13:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[print_zakaz]
@data1 date, @data2 date
as
SELECT     zakaz.data_zakaz as [Дата заказа], klient.fio_klient as [ФИО клиента], TOVAR.NAIM_TOVAR as [Товар], zakaz.adres_zakaz as [Адрес заказа], zakaz.kolvo_zakaz as [Кол-во заказанных]
FROM         zakaz INNER JOIN
                      klient ON zakaz.id_klient = klient.id_klient INNER JOIN
                      TOVAR ON zakaz.id_tovar = TOVAR.ID_TOVAR
where  zakaz.data_zakaz>=@data1 and zakaz.data_zakaz<=@data2
GO
/****** Object:  StoredProcedure [dbo].[chek_tovar]    Script Date: 01/22/2018 13:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[chek_tovar]
@id_sale int
as
SELECT    data_sale, NAIM_TOVAR, kolvo_sale, price_sale, SUM(kolvo_sale*price_sale) as Summa
FROM         sale INNER JOIN TOVAR ON sale.id_tovar = TOVAR.ID_TOVAR
where id_sale=@id_sale
group by data_sale, NAIM_TOVAR, kolvo_sale, price_sale
GO
/****** Object:  StoredProcedure [dbo].[add_zakaz]    Script Date: 01/22/2018 13:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[add_zakaz]
@data_zakaz date,
@kolvo_zakaz int,
@adres_zakaz char(50),
@plan_data date,
@status int=0,
@id_klient int,
@id_tovar int
as
begin
insert into zakaz(data_zakaz,kolvo_zakaz,adres_zakaz,plan_data,status,id_klient,id_tovar) 
values(@data_zakaz,@kolvo_zakaz,@adres_zakaz,@plan_data, @status,@id_klient,@id_tovar)
end
GO
/****** Object:  StoredProcedure [dbo].[add_sale]    Script Date: 01/22/2018 13:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[add_sale]
@date_sale date,
@id_tovar int,
@kolvo_sale int, 
@price_sale  int
as
begin
insert into sale(data_sale,id_tovar,kolvo_sale,price_sale) values(@date_sale,@id_tovar,@kolvo_sale,@price_sale)
end
GO
/****** Object:  StoredProcedure [dbo].[add_postvaka]    Script Date: 01/22/2018 13:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[add_postvaka]
@date_post date,
@kolvo_post int,
@price_post int,
@id_supplier int,
@id_tovar int
as
begin
insert into postavka(date_post,kolvo,price,id_supplier,id_tovar) values(@date_post,@kolvo_post,@price_post,@id_supplier,@id_tovar)
end
GO
/****** Object:  ForeignKey [FK_postavka_supplier]    Script Date: 01/22/2018 13:00:50 ******/
ALTER TABLE [dbo].[postavka]  WITH CHECK ADD  CONSTRAINT [FK_postavka_supplier] FOREIGN KEY([id_supplier])
REFERENCES [dbo].[supplier] ([id_supplier])
GO
ALTER TABLE [dbo].[postavka] CHECK CONSTRAINT [FK_postavka_supplier]
GO
/****** Object:  ForeignKey [FK_postavka_TOVAR]    Script Date: 01/22/2018 13:00:50 ******/
ALTER TABLE [dbo].[postavka]  WITH CHECK ADD  CONSTRAINT [FK_postavka_TOVAR] FOREIGN KEY([id_tovar])
REFERENCES [dbo].[TOVAR] ([ID_TOVAR])
GO
ALTER TABLE [dbo].[postavka] CHECK CONSTRAINT [FK_postavka_TOVAR]
GO
/****** Object:  ForeignKey [id_tovar]    Script Date: 01/22/2018 13:00:50 ******/
ALTER TABLE [dbo].[sale]  WITH CHECK ADD  CONSTRAINT [id_tovar] FOREIGN KEY([id_tovar])
REFERENCES [dbo].[TOVAR] ([ID_TOVAR])
GO
ALTER TABLE [dbo].[sale] CHECK CONSTRAINT [id_tovar]
GO
/****** Object:  ForeignKey [FK_TOVAR_VID_TOVARA]    Script Date: 01/22/2018 13:00:50 ******/
ALTER TABLE [dbo].[TOVAR]  WITH CHECK ADD  CONSTRAINT [FK_TOVAR_VID_TOVARA] FOREIGN KEY([ID_VID])
REFERENCES [dbo].[VID_TOVARA] ([ID_VID])
GO
ALTER TABLE [dbo].[TOVAR] CHECK CONSTRAINT [FK_TOVAR_VID_TOVARA]
GO
/****** Object:  ForeignKey [FK_zakaz_klient]    Script Date: 01/22/2018 13:00:50 ******/
ALTER TABLE [dbo].[zakaz]  WITH CHECK ADD  CONSTRAINT [FK_zakaz_klient] FOREIGN KEY([id_klient])
REFERENCES [dbo].[klient] ([id_klient])
GO
ALTER TABLE [dbo].[zakaz] CHECK CONSTRAINT [FK_zakaz_klient]
GO
/****** Object:  ForeignKey [FK_zakaz_TOVAR]    Script Date: 01/22/2018 13:00:50 ******/
ALTER TABLE [dbo].[zakaz]  WITH CHECK ADD  CONSTRAINT [FK_zakaz_TOVAR] FOREIGN KEY([id_tovar])
REFERENCES [dbo].[TOVAR] ([ID_TOVAR])
GO
ALTER TABLE [dbo].[zakaz] CHECK CONSTRAINT [FK_zakaz_TOVAR]
GO
