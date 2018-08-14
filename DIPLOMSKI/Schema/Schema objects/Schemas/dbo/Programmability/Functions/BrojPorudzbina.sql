CREATE FUNCTION [dbo].[BrojPorudzbina](@resId int,@datum date) RETURNS int
AS
BEGIN 
declare @brPorudzbina int;
set @brPorudzbina=0;

declare kon_cursor cursor for select Zaposleni.MBR from Zaposleni join Konobar on Zaposleni.MBR=Konobar.MBR where Zaposleni.Restoran_ID=@resId;
declare @k varchar(50);

open kon_cursor;
fetch next from kon_cursor into @k;
while @@FETCH_STATUS=0
BEGIN
	select @brPorudzbina+=count(*) from Porudzbina join Konobar on Porudzbina.Konobar_mbr=Konobar.MBR where cast(Porudzbina.DAT as date)=@datum and Konobar_mbr=@k;
	fetch next from kon_cursor into @k;
END;

	RETURN @brPorudzbina;
END;