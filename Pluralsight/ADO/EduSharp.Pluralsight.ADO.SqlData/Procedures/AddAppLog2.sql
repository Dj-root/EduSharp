create procedure AddAppLog2
@comment ntext
AS
SET nocount on

insert into dbo.ApplicationLog values(
DEFAULT, 
@comment,
(select app_name()))

select scope_identity()