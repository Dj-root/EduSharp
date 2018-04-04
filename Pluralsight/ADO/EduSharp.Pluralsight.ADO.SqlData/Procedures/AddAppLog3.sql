create procedure AddAppLog3
@comment ntext,
@outid int output
AS
SET nocount on

insert into dbo.ApplicationLog values(
DEFAULT, 
@comment,
(select app_name()))

set @outid = scope_identity()