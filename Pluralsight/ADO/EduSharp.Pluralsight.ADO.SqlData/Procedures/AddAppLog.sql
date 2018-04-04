create procedure AddAppLog
@comment ntext
AS
SET nocount on

insert into dbo.ApplicationLog values(
DEFAULT, 
@comment,
(select app_name()))
