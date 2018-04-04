create procedure AddAppLog4
@comment ntext
AS
SET nocount on

insert into dbo.ApplicationLog values(
DEFAULT, 
@comment,
(select app_name()))

    RETURN scope_identity()