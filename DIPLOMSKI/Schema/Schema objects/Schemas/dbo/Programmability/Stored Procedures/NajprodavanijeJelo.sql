CREATE PROCEDURE [dbo].[NajprodavanijeJelo](@datum date, @nazNajprodavanijeg varchar(100) output, @kolNajprodavanijeg int output)
AS 
declare @ukupnaKol int;
declare @idNajprodavanijeg varchar(50);

set @kolNajprodavanijeg=0;
set @idNajprodavanijeg=0;

declare jelo_cursor cursor for select ID from Jelo;
declare @j varchar(50);

BEGIN  
	open jelo_cursor;
	fetch next from jelo_cursor into @j;

	while @@FETCH_STATUS=0
	BEGIN
		select @ukupnaKol=SUM(KOL) from Nalazi_se join Porudzbina on Nalazi_se.Porudzbina_ID=Porudzbina.ID where Nalazi_se.Stavka_menija_ID=@j and cast(Porudzbina.DAT as date)=@datum;
		if @ukupnaKol>@kolNajprodavanijeg
		BEGIN
			set @idNajprodavanijeg=@j;
			set @kolNajprodavanijeg=@ukupnaKol;
		END;
		fetch next from jelo_cursor into @j;
	END;

	select @nazNajprodavanijeg=NAZ from Stavka_menija where ID=@idNajprodavanijeg;
END;